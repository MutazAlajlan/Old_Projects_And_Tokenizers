using System;

namespace Tokenizzzer
{
    class Program
    {
        static void tokenizer(string source)
        {
            int index = 0;

            //Console.WriteLine(" inside loop ");
            
            while(index < source.Length)
            {
                //Console.WriteLine("inside while");
                string concat = "";
                if(source[index].Equals('#'))
                {
                    //Console.WriteLine("found #");
                    int i = 1;
                    while(Char.IsLetter(source[index+1]) && index < source.Length)
                    {
                        if(i < 7)
                        {
                            concat += source[index + 1];
                            i++;
                            index++;
                        }
                        
                    }

                    if(i < 7)
                    {
                        while(i < 7)
                        {
                            concat += "0";
                            i++;
                        }
                    }

                }
                index++;
                Console.WriteLine(concat);
            }
        }
        static void Main(string[] args)
        {

            string value9 = "this color is #F2AYBC #f #12C";
            tokenizer(value9);
            Console.WriteLine("Hello World!");
            tokenizer(value9);
        }
    }
}
