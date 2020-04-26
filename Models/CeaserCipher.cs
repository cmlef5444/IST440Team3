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
          //Decrypt();
        }
        //string inputText = "Khoor Zruog";       

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

        public ArrayList Decrypt()
        {
            string input = "Elix. Jb iixjl Fkfdl Jlkqlvx. Jxqxpqb x jf mxaob. Mobmxoxqb mxox jlofo.";

            int code = 1;
            while (code < 26)
            {                
                outputArray.Add(Encrypt(input, 26 - code));               
                code++;
            } 
            foreach(string str in outputArray)
                {
                Console.WriteLine(str) ;
                }

            return outputArray;            
        }
    }







        //take input file (txt) from tesseract
        //public CeaserCipher()
        //{
        //    string textData; //will be txt file later
        //    int num;
        //}

        //public static char cipher(char ch, int key)
        //{
        //    if (!char.IsLetter(ch))
        //    {

        //        return ch;
        //    }

        //    char d = char.IsUpper(ch) ? 'A' : 'a';
        //    return (char)((((ch + key) - d) % 26) + d);


        //}


        //public static string Encipher(string input, int key)
        //{
        //    string output = string.Empty;

        //    foreach (char ch in input)
        //        output += cipher(ch, key);

        //    return output;
        //}

        //public static string Decipher(string input, int key)
        //{
        //    return Encipher(input, 26 - key);
        //}


        //public static void runProgram()
        //{

        //    Console.WriteLine("Type a string to encrypt:");
        //    string UserString = Console.ReadLine();

        //    Console.WriteLine("\n");

        //    Console.Write("Enter your Key");
        //    int key = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("\n");


        //    Console.WriteLine("Encrypted Data");

        //    string cipherText = Encipher(UserString, key);
        //    Console.WriteLine(cipherText);
        //    Console.Write("\n");

        //    Console.WriteLine("Decrypted Data:");

        //    string t = Decipher(cipherText, key);
        //    Console.WriteLine(t);
        //    Console.Write("\n");




        //    Console.ReadKey();

        //}


    
}
