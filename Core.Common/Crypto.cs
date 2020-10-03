using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Core.Common
{
    public class Crypto
    {
        public static string Sha512Encode(String sInp)
        {
            String strpass = "";
            SHA512 shaM = SHA512.Create();
            ASCIIEncoding enc = new ASCIIEncoding();
            int i;
            shaM.ComputeHash(enc.GetBytes(sInp));
            for (i = 0; i <= shaM.Hash.Length - 1; i++)
                strpass += shaM.Hash[i].ToString("X");
            return strpass;
        }
    }
}
