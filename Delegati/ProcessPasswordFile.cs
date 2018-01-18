using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Delegati
{
    class ProcessPasswordFile
    {
        public ProcessPasswordFile()
        {
            ReadText();
        }

        private void ReadText()
        {
            string[] textfile = File.ReadAllLines(@"C:\Users\Jakub\source\repos\Delegati\Delegati\textfile.txt");
            
            foreach (string s in textfile)
            {
                //Console.WriteLine(s);
                try
                {
                    Skontroluj(s);
                }
                catch (StringNotInCorrectFormatException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                
                Console.WriteLine();
                //VytvorNovySubor(s.Substring(0, s.IndexOf(" ")), Hash(s.Substring(s.IndexOf(" ") + 1)));
            }
            
        }

        public static void Skontroluj(string input)
        {
            Regex reg = new Regex(@"^\w+?\s\w+$");

            if (!reg.IsMatch(input))
            {
                throw new StringNotInCorrectFormatException("Zaznam nebol v pozadovanom formate.");
            }
        }

        private string Hash(string heslo)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(heslo));
            byte[] hashedPassword = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < hashedPassword.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(hashedPassword[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        private void VytvorNovySubor(string uzivatel, string hash)
        {
            Console.WriteLine(uzivatel + " " + hash);
        }

    }
}
