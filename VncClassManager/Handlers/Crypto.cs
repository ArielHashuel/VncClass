using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VncClassManager.Handlers
{
    public class Crypto
    {
        public Aes Rij { internal set; get; }

        private readonly RSACryptoServiceProvider Rsa;

        public readonly string PublicKey;
        public readonly string PrivateKey;
        public bool IVset = false;
        public byte[] Key
        {
            get => Rij.Key;
            set => Rij.Key = value;
        }
        public byte[] IV
        {
            get => Rij.IV;
            set
            {
                IVset = true;
                Rij.IV = value;
            }
        }

        public Crypto()
        {
            Rij = Aes.Create();
            Rij.Mode = CipherMode.CBC;
            Rij.Padding = PaddingMode.PKCS7;

            Rsa = new();
            Rsa.PersistKeyInCsp = false;

            PrivateKey = Rsa.ToXmlString(true);
            PublicKey = Rsa.ToXmlString(false);
        }

        public byte[] DecryptRsa(byte[] data, string? privateKey = null)
        {
            if (!string.IsNullOrEmpty(privateKey))
            {
                Rsa.FromXmlString(privateKey);
            }

            return Rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
        }

        public byte[] EncryptRsa(string data, string? publicKey = null)
        {
            return EncryptRsa(Encoding.UTF8.GetBytes(data), publicKey);
        }

        public byte[] EncryptRsa(byte[] data, string? publicKey = null)
        {
            RSACryptoServiceProvider rsa = new();
            if (!string.IsNullOrEmpty(publicKey))
            {
                rsa.PersistKeyInCsp = false;
                rsa.FromXmlString(publicKey);
                return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            }

            return Rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
        }

        public async Task<byte[]> EncryptRij(string data)
        {
            return await EncryptRij(Encoding.UTF8.GetBytes(data));
        }

        public async Task<byte[]> EncryptRij(byte[] data)
        {
            return await PerformCryptography(Rij.CreateEncryptor(), data);
        }

        public async Task<byte[]> DecryptRij(byte[] data)
        {
            return await PerformCryptography(Rij.CreateDecryptor(), data);
        }


        private static async Task<byte[]> PerformCryptography(ICryptoTransform cryptoTransform, byte[] data)
        {
            using MemoryStream? memoryStream = new();
            using CryptoStream? cryptoStream = new(memoryStream, cryptoTransform, CryptoStreamMode.Write);
            await cryptoStream.WriteAsync(data);
            await cryptoStream.FlushFinalBlockAsync();
            cryptoTransform.Dispose();
            memoryStream.Dispose();
            cryptoStream.Dispose();
            return memoryStream.ToArray();
        }
    }

    /// <summary>
    /// Various Server's message types.
    /// </summary>
    public enum MessageType : byte
    {
        PublicKey,
        KeyIV,
        Screen1080p,
        Screen720p,
        StopScreen,
        MouseMove,
        MouseLClick,
        MouseRClick,
        Keyboard,
        PopupMsg,
        RegularMsg,
        InputState,
        ManagerScreen
    }
}