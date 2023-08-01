using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace VncClassManager.Handlers;

public static class DatabaseHandler
{
    private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ariel\Documents\Projects\VncClass\VncClassManager\Users.mdf;Integrated Security=True";
    private static readonly SqlConnection Connection;
    private static readonly SqlCommand Cmd;


    static DatabaseHandler()
    {
        Connection = new(connectionString);
        Cmd = new();
        Cmd.Connection = Connection;
    }


    public static bool IsExist(string username)
    {
        Cmd.CommandText = $"SELECT COUNT(*) FROM Users WHERE username = '{username}'";
        Connection.Open();
        int x = (int)Cmd.ExecuteScalar();
        Connection.Close();
        return x > 0;
    }

    public static bool IsExist(string username, string pass)
    {

        Cmd.CommandText = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}' AND Password = '{Sha256(pass)}'";
        Connection.Open();
        int x = (int)Cmd.ExecuteScalar();
        Connection.Close();
        return x > 0;
    }

    public static bool Insert(string username, string pass, string name, string mail)
    {
        if (!IsExist(username))
        {
            Cmd.CommandText = $"INSERT INTO Users (Username, Password, FName, Mail) VALUES('{username}', '{Sha256(pass)}', '{name}', '{mail}')";
            Connection.Open();
            bool x = Cmd.ExecuteNonQuery() == 1;
#if DEBUG
            string deb = x ? $"user {username} Inserted" : $"Insert user {username} failed";
            VncView.UpdateDebugBox(deb);
            Debug.WriteLine(deb);
#endif
            Connection.Close();
            return x;
        }

        Debug.WriteLine($"user {username} already exists");
        return false;
    }


    public static string GetMail(string username)
    {
        Cmd.CommandText = $"SELECT Mail FROM Users WHERE Username = '{username}'";
        Connection.Open();
        string x = (string)Cmd.ExecuteScalar();
        Connection.Close();
        return x;
    }


    public static string Sha256(string source)
    {
        using SHA256 sha256Hash = SHA256.Create();
        return GetHash(sha256Hash, source);
    }


    private static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {
        // Convert the input string to a byte array and compute the hash.
        byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder? sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    // Verify a hash against a string.
    //private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
    //{
    //    // Hash the input.
    //    var hashOfInput = GetHash(hashAlgorithm, input);

    //    // Create a StringComparer an compare the hashes.
    //    StringComparer comparer = StringComparer.OrdinalIgnoreCase;

    //    return comparer.Compare(hashOfInput, hash) == 0;
    //}

}