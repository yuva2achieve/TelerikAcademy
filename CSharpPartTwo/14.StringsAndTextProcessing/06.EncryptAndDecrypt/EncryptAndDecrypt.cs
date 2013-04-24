using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.EncryptAndDecrypt
{
    class EncryptAndDecrypt
    {
        static void Main(string[] args)
        {
            string inputText = "some text";
            string cypher = "code";
            string encryptedText = "";
            string decryptedText = "";
            StringBuilder tempVariable = new StringBuilder();
            tempVariable.Append(cypher);
            while (cypher.Length != inputText.Length)
            {
                foreach (var item in cypher)
                {
                    tempVariable.Append(item);
                }
            }
            Console.WriteLine(tempVariable);
        }

        //static string Encrypt(string input, string cypherCode)
        //{
        //    string result = "";
        //}
    }
}
