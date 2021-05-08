using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
namespace Week1Day1Night
{
    class Program
    {
        static int[] rotate(int[] array, int count)
        {
            int saved = 0;
            int swap = 0;
            int maxLength = array.Length;
            int temp = 0;
            int[] Ar;
            for(int i = 0; i < count; i++)
            {
                saved = array[count - 1];
                
                for(int ii = 0; i < array.Length; ii++)
                {
                   // Ar =
                }
            }

            return null;
        }

        static int[] rotate2(int[] array, int count, bool direction)
        {
            return null;





        }




        class EasyMath
        {
            int firstValue;
        }
        static string WhichPart(string input)
        {
            char[] inputChar = input.ToCharArray();
            string output = "";
            string aM = "ABCDEFGHIJKLMabcdefghijklm";
            string nZ = "NOPQRSTUVWXYZnopqrstuvwxyz";
            foreach()
            if (input.Contains(aM))
                {
                output = output + "o";
            }
            else if (input.Contains(nZ))
            {
                output = output + "t";
            }
            else
            {
                output = output + ".";
            }
            return output;
        }
        static void Main(string[] args)
        {
            string value = "Do not use your bag";
            Console.WriteLine("Hello World!");
            SHA1 sha = SHA1.Create();
            byte[] convertUTF = Encoding.UTF8.GetBytes(value);
            byte[] byteHash = sha.ComputeHash(convertUTF);
            string hashString = BitConverter.ToString(byteHash);
            Console.WriteLine(hashString.Replace("-", String.Empty));
            string znzn = "Welcome to C#";
            string ou = WhichPart(znzn);
            Console.WriteLine(ou);
        }
    }
}
