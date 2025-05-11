using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace VncClassManager.Handlers;

public static class DatabaseHandler
{
    private static string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DB_PATH};Integrated Security=True";
    private static readonly SqlConnection Connection;
    private static readonly SqlCommand Cmd;

    public static string? DB_PATH => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Users.mdf");
            
        
    

    static DatabaseHandler()
    {
        Connection = new(connectionString);
        Cmd = new()
        {
            Connection = Connection
        };
    }


    public static bool IsExist(string username)
    {
        Cmd.CommandText = $"SELECT COUNT(*) FROM [dbo].[Users] WHERE username = '{username}'";
        Connection.Open();
        int x = (int)Cmd.ExecuteScalar();
        Connection.Close();
        return x > 0;
    }

    public static bool IsExist(string username, string pass)
    {

        Cmd.CommandText = $"SELECT COUNT(*) FROM [dbo].[Users] WHERE Username = '{username}' AND Password = '{Sha256(pass)}'";
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
        Cmd.CommandText = $"SELECT Mail FROM [dbo].[Users] WHERE Username = '{username}'";
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

    public static void CreateDB()
    {
        using SqlConnection myConn = new($"Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=False");
        SqlCommand file_cmd = new($@" CREATE DATABASE Users ON (
                                   NAME='Users', 
                                   FILENAME='{DB_PATH}')", myConn);
        using SqlConnection myConn1 = new(connectionString);
        
        try
        {
            myConn.Open();
            file_cmd.ExecuteNonQuery();
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }

            SqlCommand tbl_cmd = new(@"
            CREATE TABLE [dbo].[Users] (
            [Id]       INT            IDENTITY (1, 1) NOT NULL,
            [FName]    NVARCHAR (MAX) NOT NULL,
            [Username] NVARCHAR (MAX) NOT NULL,
            [Password] NVARCHAR (MAX) NOT NULL,
            [Mail]     NVARCHAR (MAX) NOT NULL,
            PRIMARY KEY CLUSTERED ([Id] ASC));", myConn1);
            myConn1.Open();
            tbl_cmd.ExecuteNonQuery();

            Debug.WriteLine("DB created");
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        finally
        {
            if (myConn.State == ConnectionState.Open)
            {
                myConn.Close();
            }
            if (myConn1.State == ConnectionState.Open)
            {
                myConn1.Close();
            }
        }

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