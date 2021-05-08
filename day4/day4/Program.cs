using System;

namespace day4
{
    class Program
    {
        static void tokenizer(string source)
        {
            int index = source.Length;
            while (index < source.Length)
            {
                Console.WriteLine(source[index]);
                index++;
            }
        }
        static void tokenizer2(string source)
        {

            // id -> (letter|underscore) + loop(digit|letter|underscore)
            //float
            //at first print each letter, then try to make it into string.
            // if float has double dot then put error.
            string concat = "";
            int index = source.Length;
            while(index < source.Length)
            {
                if(source[index].Equals("_"))
                {
                    concat += source[index];
                    while(index < source.Length)
                    {
                        if(Char.IsLetterOrDigit(source[index+1]))
                        {
                            concat += source[index + 1];
                        }
                    }
                }
                else if(Char.IsDigit(source[index]))
                {

                }
                else if(Char.IsLetter(source[index]))
                {

                }
                else if(Char.IsWhiteSpace(source[index]))
                {

                }
                else if(source[index].Equals("\\"))
                {
                    // get \n \t \r to continue
                }

                //Console.WriteLine(concat);

            }
        }
        static void Main(string[] args)
        {
            string value = "this is 200, and 75 or 012";

            tokenizer2(value);
            /*
                string value = "this is 200, and 75 or 012";
            string numbers = "";

            for(int i = 0; i < value.Length; i++)
            {
                if(Char.IsDigit(value[i]))
                {
                    numbers += value[i];
                    if (Char.IsDigit(value[i + 1]))
                    {
                        numbers += value[i];
                    }
                }

                List<int> arrayList = new List<int>
                    
                }
            */
        }

        }
}

