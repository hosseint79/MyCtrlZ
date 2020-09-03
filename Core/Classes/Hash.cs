using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace Core
{
    public class Hash
    {
        public static string MD5hash(string pass)
        {
            byte[] passbyte;
            byte[] encodebyte;


            MD5 md = new MD5CryptoServiceProvider();

            passbyte = ASCIIEncoding.Default.GetBytes(pass);
            encodebyte = md.ComputeHash(passbyte);


            return BitConverter.ToString(encodebyte);
        }
    }
}
