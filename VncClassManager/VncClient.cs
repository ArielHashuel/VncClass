using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VncClassManager.Handlers;

namespace VncClassManager
{

    /// <summary>
    /// Handels connections to the server.
    /// <para> Recieving and sending data using <see cref="TcpClient"/> protocol.</para> 
    /// </summary>
    public class VncClient
    {
        #region Properties, Fields and Constructors
        private const int MAX_BUFFER = 9216 * 1024; // 9216K
        private readonly Socket Client;
        private readonly byte[] VncBytes;
        private readonly Crypto crypto;
        public ScreenView? VncScreen;

        private readonly BinaryWriter writer;
        private readonly NetworkStream Ns;

        private Task RecieveTask;

        public bool StreamTask { get; set; }
        public string ClientIp { get; set; }


        private bool updateScreen;
        public bool UpdateScreen
        {
            get => updateScreen;
            set
            {
                updateScreen = value;
                if (value && RecieveTask.IsCompleted)
                {
                    RecieveTask = Task.Run(async () => await ReceiveMessage());
                }
                ScreenState(value);
            }
        }

        public VncClient(Socket client)
        {
            Client = client;
            crypto = new Crypto();
            Ns = new(client, true);
            writer = new BinaryWriter(Ns);
            ClientIp = ((IPEndPoint?)(client.RemoteEndPoint ?? client.LocalEndPoint))?.Address.ToString() ?? "";
            VncBytes = new byte[MAX_BUFFER];
            Client.ReceiveBufferSize = MAX_BUFFER;
            updateScreen = true;
            RecieveTask = new Task(async () => await ReceiveMessage());
            RecieveTask.Start();
            SendEncryptionKeys();
        }
        #endregion

        /// <summary>
        /// Send <see cref="System.Security.Cryptography.RSA"/> encryption keys to the Server,
        /// in order to Encrypt the <see cref="System.Security.Cryptography.Aes"/> keys.
        /// </summary>
        private void SendEncryptionKeys()
        {
            List<byte> msg = new() { (byte)MessageType.PublicKey };
            byte[] pubkey = Encoding.UTF8.GetBytes(crypto.PublicKey);
            msg.AddRange(BitConverter.GetBytes(pubkey.Length));
            msg.AddRange(pubkey);
            writer.Write(msg.ToArray());
            writer.Flush();
            Ns.Flush();
        }

        /// <summary>
        /// Read messages from the server.
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
                byte[] len = new byte[4];
                _ = Ns.Read(len, 0, 4);
                int bytesNeeded = BitConverter.ToInt32(len);

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
                        int toRead = (bytesToRead > 1024) ? 1024 : bytesToRead;
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
                        // there isn't any data atm. let's give the processor some time.
                        await Task.Delay(100); // increased to 100ms for slow connections
                    }
                } while (bytesNeeded > 0);

                byte[] msg = type == MessageType.KeyIV ? crypto.DecryptRsa(ms.ToArray()[0..read]) : await crypto.DecryptRij(ms.ToArray()[0..read]);
                switch (type)
                {
                    case MessageType.KeyIV:
                        crypto.Key = msg[0..32];
                        crypto.IV = msg[32..];
                        if (VncScreen is not null)
                        {
                            writer.Write((byte)(VncScreen.IsFull ? MessageType.Screen1080p : MessageType.Screen720p));
                        }
                        break;
                    case MessageType.Screen1080p:
                    case MessageType.Screen720p:
                        {
                            if (VncScreen?.IsHandleCreated ?? false && UpdateScreen)
                            {
                                Image? img = Image.FromStream(new MemoryStream(msg));
                                VncScreen?.Invoke(delegate { VncScreen?.SetImg(img); });
                            }
                            break;
                        }
                    case MessageType.RegularMsg:
                        {
                            VncScreen?.Invoke(delegate
                            {
                                VncScreen?.DataBox.AppendText($"{ClientIp}> {Encoding.UTF8.GetString(msg)}");
                                if (!(VncScreen?.IsMessageShow ?? true))
                                {
                                    VncScreen.Messages++;
                                    ((VncView)Application.OpenForms[nameof(VncView)]).Messages++;
                                }
                            });
                            break;
                        }
#if DEBUG
                    default:
                        throw new NotSupportedException($"Message type {type} not supported");
#endif
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
#endif
            }
            Array.Clear(VncBytes);
            writer.Flush();
            await Ns.FlushAsync();
            if (Client.Connected && updateScreen)
            {
                RecieveTask = Task.Run(async () => await ReceiveMessage());
            }
        }

        public async void SendScreen()
        {
            Rectangle screen = Screen.AllScreens[0].WorkingArea;
            using Bitmap bit = new(screen.Width, screen.Height);
            using Graphics g = Graphics.FromImage(bit);

            g.CopyFromScreen(0, 0, 0, 0, new Size(screen.Width, screen.Height));
            using MemoryStream s = new();
            bit.Save(s, ImageFormat.Jpeg);

            byte[] enc = await crypto.EncryptRij(s.ToArray());
            List<byte> Send = new() { (byte)MessageType.ManagerScreen };
            Send.AddRange(BitConverter.GetBytes(enc.Length));
            Send.AddRange(enc);
            writer.Write(Send.ToArray());

            // Clear memory
            writer.Flush();
            await Ns.FlushAsync();
        }

        public void StreamScreen()
        {
            SendScreen();
            if (StreamTask)
            {
                Task.Run(StreamScreen);
            }
        }

        public void ChangeInputState(bool Enabled)
        {
            try
            {
                byte[] send = new byte[2];
                send[0] = (byte)MessageType.InputState;
                send[1] = (byte)(Enabled ? 1 : 0);
                lock (Ns)
                {
                    lock (writer)
                    {
                        writer.Write(send);
                    }
                }
                writer.Flush();
                Ns.Flush();

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public void UpdateScreenRes(MessageType res)
        {
            try
            {
                lock (Ns)
                {
                    lock (writer)
                    {
                        writer.Write((byte)res);
                    }
                }
                writer.Flush();
                Ns.Flush();

            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public void SendKeyboard(params Keys[] key)
        {
            SendData(key.Select(i => (byte)i).ToArray(), MessageType.Keyboard);
        }

        public void SendMessage(string text, MessageType type = MessageType.RegularMsg, bool Encrypt = true)
        {
            SendData(Encoding.UTF8.GetBytes(text), type, Encrypt);
        }

        public void ScreenState(bool Enabled)
        {
            try
            {
                lock (Ns)
                {
                    lock (writer)
                    {
                        writer.Write((byte)(Enabled ? (VncScreen?.IsFull ?? true ? MessageType.Screen1080p : MessageType.Screen720p) : MessageType.StopScreen));
                    }
                }
                writer.Flush();
                Ns.Flush();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }


        /// <summary>
        /// send data to the Server.
        /// </summary>
        /// <param name="data">byte[] contains Data to send</param>
        /// <param name="type">type of the data. see <see cref="MessageType"/></param>
        /// <param name="Encrypt">boolean flag which indicates whether to encrypt the message. Default is true</param>
        public async void SendData(byte[] data, MessageType type, bool Encrypt = true)
        {
            try
            {
                List<byte> send = new();
                send.Add((byte)type);
                byte[]? enc = Encrypt ? await crypto.EncryptRij(data) : data;
                send.AddRange(BitConverter.GetBytes(enc.Length));
                send.AddRange(enc);
                lock (Ns)
                {
                    lock (writer)
                    {
                        writer.Write(send.ToArray());
                    }
                }
                writer.Flush();
                await Ns.FlushAsync();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }
}