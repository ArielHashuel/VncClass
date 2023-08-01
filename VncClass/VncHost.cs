using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncClass.Handlers;

namespace VncClass;

public class VncHost
{
    #region Properties, Fields and Constructors
    private const int MAX_BUFFER = 9216 * 1024; // 9216K
    private readonly Socket Client;
    private readonly NetworkStream Ns;
    private readonly BinaryWriter writer;
    private readonly byte[] VncBytes;
    private readonly Crypto crypto;
    private readonly Rectangle screen;

    private string? ClientPubKey;
    private bool IsFull;
    private bool CaptureScreen;
    private Task recieveTask;
    private Task? sendScreenTask;
    private readonly ClientForm clientForm;

    public Task RecieveTask { get => recieveTask; set => recieveTask = value; }

    public VncHost(Socket client)
    {
        VncBytes = new byte[MAX_BUFFER];
        Client = client;
        Ns = new(client, true);
        writer = new BinaryWriter(Ns);
        Client.ReceiveBufferSize = MAX_BUFFER;
        crypto = new Crypto();
        screen = Screen.AllScreens[0].WorkingArea;
        IsFull = false;
        CaptureScreen = true;
        InputHandler.Host = this;
        clientForm = (ClientForm)Application.OpenForms[nameof(ClientForm)];
        recieveTask = new Task(async () => await ReceiveMessage());
        RecieveTask.Start();
    }
    #endregion

    /// <summary>
    /// Read messages from client.
    /// </summary>
    /// <returns>an <see langword="async"/> <see langword="Task"/></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task ReceiveMessage()
    {
        try
        {
            using MemoryStream ms = new();
            using BinaryWriter br = new(ms);

            MessageType type = (MessageType)Ns.ReadByte();

            int bytesNeeded = 0;
            byte[] len = new byte[4];
            if (type is MessageType.Screen1080p)
            {
                CaptureScreen = IsFull = true;
                if (sendScreenTask?.IsCompleted ?? true)
                {
                    sendScreenTask = Task.Run(async () => await SendScreen());
                }
            }
            else if (type is MessageType.Screen720p)
            {
                CaptureScreen = true;
                IsFull = false;
                if (sendScreenTask?.IsCompleted ?? true)
                {
                    sendScreenTask = Task.Run(async () => await SendScreen());
                }
            }
            else if (type is MessageType.StopScreen)
            {
                CaptureScreen = false;
            }
            else if (type is MessageType.InputState)
            {
                _ = Ns.Read(len, 0, 1);
                InputHandler.ChangeState(len[0]);
            }
            else
            {
                _ = Ns.Read(len, 0, 4);
                bytesNeeded = BitConverter.ToInt32(len);
                int read = 0;
                do
                {
                    if (Ns.DataAvailable)
                    {
                        int bytesToRead = bytesNeeded;

                        // the byteToRead should never exceed the MAX_BUFFER
                        if (bytesToRead > MAX_BUFFER)
                        {
                            bytesToRead = MAX_BUFFER;
                        }

                        // try reading bytes (read in 1024 byte chunks) - improvement for slow connections
                        int toRead = bytesToRead > 1024 ? 1024 : bytesToRead;
                        int bytesRead = 0;
                        try
                        {
                            read += bytesRead = Ns.Read(VncBytes, bytesRead, toRead);
                        }
                        catch { }

                        // lower the bytesNeeded with the bytesRead.
                        bytesNeeded -= bytesRead;

                        // write the readed bytes to the decompression stream.
                        br.Write(VncBytes, 0, bytesRead);
                    }
                    else
                    {
                        await Task.Delay(100);
                    }
                } while (bytesNeeded > 0);

                byte[] msg = ms.ToArray()[0..read] ?? throw new ArgumentNullException("ms.ToArray()");
                byte[] data = type is MessageType.PublicKey ? msg : await crypto.DecryptRij(msg);

                switch (type)
                {
                    case MessageType.PublicKey:
                        {
                            ClientPubKey = Encoding.UTF8.GetString(msg);
                            List<byte> clear = new();
                            List<byte> keys = new();

                            clear.Add((byte)MessageType.KeyIV);
                            keys.AddRange(crypto.Key);
                            keys.AddRange(crypto.IV);
                            byte[] enckeys = crypto.EncryptRsa(keys.ToArray(), ClientPubKey);
                            clear.AddRange(BitConverter.GetBytes(enckeys.Length));
                            clear.AddRange(enckeys);
                            writer.Write(clear.ToArray());
                            break;
                        }
                    case MessageType.PopupMsg:
                        MessageBox.Show(Encoding.UTF8.GetString(data), "Message From Administrator:");
                        ClientForm cform = (ClientForm)Application.OpenForms[nameof(ClientForm)];
                        cform.Invoke(delegate { cform.UpdateLog($"(p) Administrator> {Encoding.UTF8.GetString(data)}"); });
                        break;
                    case MessageType.RegularMsg:
                        ClientForm form = (ClientForm)Application.OpenForms[nameof(ClientForm)];
                        form.Invoke(delegate { form.UpdateLog($"Administrator> {Encoding.UTF8.GetString(data)}"); });
                        break;
                    case MessageType.MouseMove:
                        _ = Task.Run(() => Move(data));
                        break;
                    case MessageType.MouseLClick:
                    case MessageType.MouseRClick:
                        InputHandler.Click(type);
                        break;
                    case MessageType.Keyboard:
                        for (int i = 0; i < data.Length; i++)
                        {
                            InputHandler.VirtualKeyShort key = (InputHandler.VirtualKeyShort)(Keys)data[i];

                            if (key is InputHandler.VirtualKeyShort.CONTROL or InputHandler.VirtualKeyShort.SHIFT or InputHandler.VirtualKeyShort.MENU) // Menu is alt
                            {
                                InputHandler.VirtualKeyShort[] keys = data[i..].Select(i => (InputHandler.VirtualKeyShort)(Keys)i).ToArray();
                                InputHandler.SendKeys(keys);
                            }
                            else
                            {
                                InputHandler.SendKeys(key);
                            }
                        }
                        break;
                    case MessageType.ManagerScreen:
                        clientForm.Invoke(delegate { clientForm.Screen.Image = Image.FromStream(new MemoryStream(data)); });
                        break;
                }
            }
        }
        catch (Exception ex)
        {
#if DEBUG
            if (!ex.Message.Contains("The operation completed successfully"))
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
#endif
        }
        writer.Flush();
        await Ns.FlushAsync();
        if (Client.Connected)
        {
            Array.Clear(VncBytes);
            RecieveTask = Task.Run(async () => await ReceiveMessage());
        }
    }

    public void SendMessage(string text, MessageType type = MessageType.RegularMsg, bool Encrypt = true)
    {
        SendData(Encoding.UTF8.GetBytes(text), type, Encrypt);
    }
    public async void SendData(byte[] data, MessageType type, bool Encrypt = true)
    {
        try
        {
            List<byte> send = new();
            send.Add((byte)type);
            byte[]? enc = Encrypt ? await crypto.EncryptRij(data) : data;
            send.AddRange(BitConverter.GetBytes(enc.Length));
            send.AddRange(enc);
            writer.Write(send.ToArray());

            writer.Flush();
            await Ns.FlushAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    /// <summary>
    /// Used to send current screen to the client.
    /// </summary>
    /// <returns>an async Task</returns>
    public async Task SendScreen()
    {
        if (CaptureScreen)
        {
            using Bitmap bit = new(screen.Width, screen.Height);
            using Graphics g = Graphics.FromImage(bit);

            g.CopyFromScreen(0, 0, 0, 0, new Size(screen.Width, screen.Height));
            using MemoryStream s = new();
            if (IsFull)
            {
                bit.Save(s, ImageFormat.Jpeg);
            }
            else
            {
                using Bitmap resizedImg = new(1280, 720);
                using Graphics res = Graphics.FromImage(resizedImg);
                res.DrawImage(bit, 0, 0, 1280, 720);
                resizedImg.Save(s, ImageFormat.Jpeg);
            }

            byte[] enc = await crypto.EncryptRij(s.ToArray());
            List<byte> Send = new() { (byte)MessageType.Screen1080p };
            Send.AddRange(BitConverter.GetBytes(enc.Length));
            Send.AddRange(enc);
            writer.Write(Send.ToArray());

            // Clear memory
            writer.Flush();
            await Ns.FlushAsync();
            // recursion but the current method finishes.
            // let it clear memory with the using statement.
            sendScreenTask = Task.Run(async () => await SendScreen());
        }
    }

    /// <summary>
    /// Simulate mouse move
    /// </summary>
    /// <param name="data">byte[] contains the mouse coordinates related to the client's screen</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">if data is null</exception>
    public void Move(byte[]? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }
        List<int>? mouseBit = data.Select((x, i) => new { Index = i, Value = x })
                             .GroupBy(x => x.Index / 4)
                             .Select(x => BitConverter.ToInt32(x.Select(v => v.Value).ToArray())).ToList();

        Cursor.Position = new
            ((int)(mouseBit[0] / (float)mouseBit[2] * screen.Width),
            (int)(mouseBit[1] / (float)mouseBit[3] * screen.Height));
    }
}