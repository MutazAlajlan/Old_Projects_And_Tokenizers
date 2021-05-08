using System;
using System.Collections.Generic;
namespace TokenizerDesign
{
    class Program
    {
        static List<string> OldTokenizer(string input)
        {
            //check input
            //do action
            //get output
            List<string> tokens = new List<string>();
            //string[] tokens = new string[] { };
            string token = null; //_424jjj
            int i = 0;
            //int count = 0;
            while(i < input.Length)
            {
                if(input[i] == '_' || Char.IsLetter(input[i]))
                {
                    token += input[i++];
                    //int count = 1;
                    while(i < input.Length && !Char.IsWhiteSpace(input[i]))
                    {
                        if(Char.IsLetterOrDigit(input[i]))
                        {
                            token += input[i++];
                        }
                    }
                    tokens.Add(token);
                    continue;
                    //count++;
                }
                else if(Char.IsDigit(input[i]))
                {
                    token += input[i++];
                    while(i < input.Length && Char.IsDigit(input[i]))
                    {
                        token += token;
                    }
                    tokens.Add(token);
                    //count++;
                }
                i++;
            }
            return tokens;
        }

        static List<string> tokenizer (string input)
        {
            if (input == null || input.Trim().Length == 0)
                return null;

            List<string> tokens = new List<string>();
            int i = 0;
            string token = null;

            while (i < input.Length)
            {
                token = "";
                if (Char.IsLetter(input[i]) || input[i] == '_')
                {
                    token += input[i++];
                    while ((i < input.Length) && (Char.IsLetterOrDigit(input[i])) || input[i] == '_')
                    {
                        token += input[i++];
                    }
                    tokens.Add(token);
                    continue;
                }
                else if (Char.IsDigit(input[i]))
                {
                    token += input[i++];
                    while ((i < input.Length) && Char.IsDigit(input[i]))
                    {
                        token += input[i++];
                    }
                    tokens.Add(token);
                    continue;
                }
                else if (Char.IsWhiteSpace(input[i]))
                {
                    token += input[i++];
                    while ((i < input.Length) && Char.IsWhiteSpace(input[i]))
                    {
                        token += input[i++];
                    }

                    tokens.Add(token);
                    continue;
                }
                i++;
            }
            return tokens;
           
        }
        static List<string> tokenizer3(string input)
        {
            if (input == null || input.Trim().Length == 0)
                return null;
            List<string> tokens = new List<string>();
            int i = 0;
            string token = null;
            while (i < input.Length)
            {
                token = "";
                if (Char.IsLetter(input[i]) || input[i] == '_')
                {
                    token += input[i++];
                    while ((i < input.Length) && (Char.IsLetterOrDigit(input[i]) || input[i] == '_'))
                    {
                        token += input[i++];
                    }
                    tokens.Add(token);
                    continue;
                }
                else if (Char.IsDigit(input[i]))
                {
                    token += input[i++];
                    while ((i < input.Length) && Char.IsDigit(input[i]))
                    {
                        token += input[i++];
                    }
                    tokens.Add(token);
                    continue;
                }
                else if (Char.IsWhiteSpace(input[i]))
                {
                    token += input[i++];
                    while ((i < input.Length) && Char.IsWhiteSpace(input[i]))
                    {
                        token += input[i++];
                    }
                    tokens.Add(token);
                    continue;
                }
                i++;
            }
            return tokens;
        }



        static void Main(string[] args)
        {
            //Console.WriteLine(Tokenizer("Hello World!"));
            string t = "age = 22; 123if";
            List<string> tokeni = tokenizer3(t);
            //string text = "123.f";
                foreach (string element in tokeni)
            {
                Console.WriteLine(element);
            }
        }
    }
}
