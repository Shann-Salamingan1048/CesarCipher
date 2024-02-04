using System;
using System.Text;

namespace CesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            CesarCip cc = new CesarCip(10);
            Console.WriteLine('l' - 'a');
            Console.WriteLine((char)108);
            Console.WriteLine((char)98);
            string text = "shann delfin c salamingan b";
            string Encripted = cc.Encrypt(text);
            string Decrypted = cc.Decrypt(Encripted);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Encripted: {0}",Encripted);
            Console.WriteLine("Decrypted: {0}", Decrypted);
            Console.ReadKey();
        }
    }
    class CesarCip
    {
        private int Gap;
        public CesarCip(int Gap)
        {
            this.Gap = Gap;
        }
        /*
         This Cesar Cipher only Encrypt lower case only otherwise if you input upper case, the result will not be as expected.
        If you want upper case then change all "'a'" to upper case and the input should be in Upper case as well
         */
        public string Encrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            /*
             Use StringBuilder in Concenating Strings or char to avoid memory leaks
             */
            foreach(char c in text)
            {
                if (c.Equals(' ')) // ignore space
                {
                    sb.Append(c);
                    continue;
                }
                sb.Append((char)( (c - 'a' + this.Gap) % 26 + 'a'));
                /*
                 if c is 'b' then 'b' - 'a' = 1. 
                 1 + 10(gap) = 11. 
                 11 % 26 = 11.
                 11 + 'a' = 108. 'a' is equal to 97
                (char)108 = l.
                 */
            }
            return sb.ToString();
        }
        public string Decrypt(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (c.Equals(' ')) // ignore space
                {
                    sb.Append(c);
                    continue;
                }
                sb.Append((char)( ((c - 'a' - this.Gap) + 26 )% 26 + 'a'));
                /*
                 if c is 'l' then 'l' - 'a' = 2.
                 11 - 10 = 1.
                 1 + 26 = 27.
                 27 % 26 = 1.
                 1 + 'a' = 98.
                 (char)98 = b.
                 */
            }
            return sb.ToString();
        }
    }
}
