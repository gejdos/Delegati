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
        string datetime = DateTime.Now.ToString();

        public ProcessPasswordFile()
        {
            ReadText();
        }

        private void ReadText()
        {
            string[] textfile = File.ReadAllLines(@"..\..\textfile.txt");

            foreach (string s in textfile)
            {
                string uzivatel = s.Substring(0, s.IndexOf(" "));

                try
                {
                    Skontroluj(s);
                }
                catch (TextNotInCorrectFormatException ex)
                {
                    Console.WriteLine("{0} uzivatel: {1}, '{2}'", datetime, uzivatel, ex.Message.ToString());
                    File.AppendAllText(@"..\..\log.txt", datetime + " " + uzivatel +
                        " " + ex.Message.ToString() + Environment.NewLine);
                }

                Console.WriteLine();

                //VytvorNovySubor(s.Substring(0, s.IndexOf(" ")), Hash(s.Substring(s.IndexOf(" ") + 1)));
            }
            
        }

        private void Skontroluj(string input)
        {
            Regex reg = new Regex(@"^\w+?\s\w+$");

            if (!reg.IsMatch(input))
            {
                throw new TextNotInCorrectFormatException("Zaznam nebol v pozadovanom formate.");
            }
        }

        private void VytvorHash(string heslo)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(heslo));
            byte[] hashedPassword = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < hashedPassword.Length; i++)
            {
                //2 hexadecimal digits
                //for each byte
                strBuilder.Append(hashedPassword[i].ToString("x2"));
            }
            
        }
        
    }
}
