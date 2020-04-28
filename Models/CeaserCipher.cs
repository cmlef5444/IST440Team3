using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST440Team3.Models
{
    public class CeaserCipher
    {
        public CeaserCipher()
        {

        }        

        ArrayList outputArray = new ArrayList();

        static char Encrypt(char ch, int code)
        {
            if (!char.IsLetter(ch)) return ch;

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((ch + code - offset) % 26 + offset);
        }

        static string Encrypt(string input, int code)
        {
            return new string(input.Select(ch => Encrypt(ch, code)).ToArray());
        }

        public ArrayList Decrypt(string input)
        {
            //string input = "Elix. Jb iixjl Fkfdl Jlkqlvx. Jxqxpqb x jf mxaob. Mobmxoxqb mxox jlofo."; //FIX_ME testing code, omit on Final 

            int code = 0;
            while (code < 26)
            {                
                outputArray.Add(Encrypt(input, 26 - code));               
                code++;
            } 
            foreach(string str in outputArray)
                {
                //Console.WriteLine(str) ;  //FIX_ME testing code, omit on Final
                }
            return outputArray;            
        }
    }
}
