
using System;
using System.Security.Cryptography;
using System.Text;

namespace ogm.account
{
    public class Utility
    {
        public static string WrapPassword(string _password)
        {
            string password = reverseString(_password);
            password = toSHA512(password).ToUpper();
            password = reverseString(password);
            password = toMd5(password).ToUpper();
            return password;
        }

        private static string toMd5(string _value)
        {
            MD5 md5 = MD5.Create();
            byte[] byteOld = Encoding.UTF8.GetBytes(_value);
            byte[] byteNew = md5.ComputeHash(byteOld);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        private static string toSHA512(string _value)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] byteOld = Encoding.UTF8.GetBytes(_value);
            byte[] byteNew = sha512.ComputeHash(byteOld);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


        private static string reverseString(string _value)
        {
            char[] cs = _value.ToCharArray();
            Array.Reverse(cs);
            return new string(cs);
        }
    }

    public class Reply
    {
        public class Status
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public Status status { get; set; }

        public Reply()
        {
            status = new Status();
        }
    }

    public class AccountEntity
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public long createdAt { get; set; }

        public string _createdAt { get; set; }
    }

    public class QueryListReply : Reply
    {
        public long total { get; set; }
        public AccountEntity[] account { get; set; }

        public QueryListReply() : base()
        {
            account = new AccountEntity[0];
        }
    }

    public class QuerySingleReply : Reply
    {
        public AccountEntity account { get; set; }
    }

}
