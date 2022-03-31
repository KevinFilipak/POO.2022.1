using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POO._2022._1.ED.Classes
{
    public static class Crypto
    {
        public static string MD5Hash(string value)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        //https://bitcoin.stackexchange.com/questions/5829/how-do-i-base58-checked-encode-decode-an-address-in-c-what-does-normalize-l

        public static String sBase58Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        public static String EncodeBase58(BigInteger numberToShorten)
        {
            const int sizeWalletImportFormat = 51;

            char[] result = new char[33];

            Int32 iAlphabetLength = sBase58Alphabet.Length;
            BigInteger iAlphabetLength2 = BigInteger.Parse(iAlphabetLength.ToString());

            int i = 0;
            while (numberToShorten >= 0 && result.Length > i)
            {
                var lNumberRemainder = BigInteger.Remainder(numberToShorten, iAlphabetLength2);
                numberToShorten = numberToShorten / iAlphabetLength;
                result[result.Length - 1 - i] = sBase58Alphabet[(int)lNumberRemainder];
                i++;
            }

            return new string(result);
        }
    }
}
