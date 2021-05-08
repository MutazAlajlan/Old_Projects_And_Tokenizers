using System;
using System.Collections.Generic;

namespace AdvancedTokenizere
{
    class Program
    {
        //class Tokenizer
        //{
        //    private string ExtractNumberToken(ref int startIndex, string source)
        //    {
        //        //int i = startIndex;
        //        string token = "";
        //        while (startIndex < source.Length /*&& !char.IsWhiteSpace(source[i])*/
        //                    // take only integer numbers
        //                    && char.IsDigit(source[startIndex]))
        //        {
        //            token += source[startIndex++];
        //        }

        //        return token;
        //    }
        //    private string ExtractStringToken(ref int startIndex, string source)
        //    {
        //        //int i = startIndex;
        //        string token = "";

        //        while (startIndex < source.Length /*&& !char.IsWhiteSpace(source[i])*/
        //                    && (char.IsLetterOrDigit(source[startIndex]) || source[startIndex] == '_'))
        //        {
        //            token += source[startIndex++];
        //        }

        //        return token;
        //    }
        //    public List<string> Token(string source)
        //    {
        //        int i = 0;
        //        //string token = "";
        //        List<string> tokens = new List<string>();
        //        while (i < source.Length)
        //        {
        //            //token = "";
        //            // number
        //            if (char.IsDigit(source[i]))
        //            {
        //                //while(i<source.Length /*&& !char.IsWhiteSpace(source[i])*/
        //                //    // take only integer numbers
        //                //    && char.IsDigit(source[i]))
        //                //{
        //                //    token += source[i++];
        //                //}
        //                //tokens.Add(token);
        //                tokens.Add(ExtractNumberToken(ref i, source));
        //                continue;
        //            }

        //            // identifier
        //            if (char.IsLetter(source[i]) || source[i] == '_'
        //                    // take only letters, numbers and _
        //                    && (char.IsLetterOrDigit(source[i]) || source[i] == '_'))
        //            {
        //                //while(i<source.Length /*&& !char.IsWhiteSpace(source[i])*/
        //                //    && (char.IsLetterOrDigit(source[i]) || source[i] == '_'))
        //                //{
        //                //    token += source[i++];
        //                //}
        //                //tokens.Add(token);
        //                tokens.Add(ExtractStringToken(ref i, source));
        //                continue;
        //            }
        //            i++;
        //        }
        //        return tokens;
        //    }
        //    public List<string> TokenOrigin(string source)
        //    {
        //        int i = 0;
        //        string token = "";
        //        List<string> tokens = new List<string>();
        //        while (i < source.Length)
        //        {
        //            token = "";
        //            // number
        //            if (char.IsDigit(source[i]))
        //            {
        //                while (i < source.Length /*&& !char.IsWhiteSpace(source[i])*/
        //                    // take only integer numbers
        //                    && char.IsDigit(source[i]))
        //                {
        //                    token += source[i++];
        //                }
        //                tokens.Add(token);
        //                //tokens.Add(ExtractNumberToken(ref i, source));
        //                continue;
        //            }

        //            // identifier
        //            if (char.IsLetter(source[i]) || source[i] == '_'
        //                    // take only letters, numbers and _
        //                    && (char.IsLetterOrDigit(source[i]) || source[i] == '_'))
        //            {
        //                while (i < source.Length /*&& !char.IsWhiteSpace(source[i])*/
        //                    && (char.IsLetterOrDigit(source[i]) || source[i] == '_'))
        //                {
        //                    token += source[i++];
        //                }
        //                tokens.Add(token);
        //                //tokens.Add(ExtractStringToken(ref i, source));
        //                continue;
        //            }
        //            i++;
        //        }
        //        return tokens;
        //    }
        //}

        //static List<string> tokenizer_before_refactoring(string input)
        //{
        //    if (input == null || input.Trim().Length == 0)
        //        return null;

        //    List<string> tokens = new List<string>();
        //    int i = 0;
        //    string token = null;

        //    while (i < input.Length)
        //    {
        //        token = "";
        //        if (Char.IsLetter(input[i]) || input[i] == '_')
        //        {
        //            token += input[i++];
        //            while ((i < input.Length) && (Char.IsLetterOrDigit(input[i]) || input[i] == '_'))
        //            {
        //                token += input[i++];
        //            }

        //            tokens.Add(token);
        //            continue;
        //        }
        //        else if (Char.IsDigit(input[i]))
        //        {
        //            token += input[i++];
        //            while((i < input.Length) && Char.IsDigit(input[i]))
        //            {
        //                token += input[i++];
        //            }

        //            tokens.Add(token);
        //            continue;
        //        }
        //        else if (Char.IsWhiteSpace(input[i]))
        //        {
        //            token += input[i++];
        //            while((i < input.Length) && Char.IsWhiteSpace(input[i]))
        //            {
        //                token += input[i++];
        //            }

        //            tokens.Add(token);
        //            continue;
        //        }

        //        i++;
        //    }

        //    return tokens;
        //}

        /*==============================================================*/
        /*==============================================================*/
        /*==============================================================*/
        /*==============================================================*/

        public class Token
        {
            public string type; // id | number
            public string value;
            public int position;
            public int lineNumber;

        }

        public abstract class Tokenizable
        {
            public abstract bool tokenizable(Tokenizer t);
            public abstract Token tokenize(Tokenizer t);

        }

        public class Tokenizer
        {
            public string input;
            public int currentPosition;
            public int lineNumber;

            public char peek()
            {
                if(this.hasMore())
                {
                    return this.input[this.currentPosition + 1];
                }
                else
                {
                    return '\0';
                }
            }

            public char next()
            {
                char currentChar = this.input[++this.currentPosition];
                if(currentChar == '\n')
                {
                    this.lineNumber++;
                }

                return currentChar;
            }

            public bool hasMore()
            {
                return (this.currentPosition + 1) < this.input.Length;
            }

            public Token tokenize(Tokenizable[] handlers)
            {
                foreach (var t in handlers)
                {
                    if(t.tokenizable(this))
                    {
                        return t.tokenize(this);
                    }
                }

                throw new Exception("Unexpected token");
            }

        }

        public class NumberTokenizer : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && Char.IsDigit(t.peek());
            }

            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "number";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;

                while(t.hasMore() && Char.IsDigit(t.peek()))
                {
                    token.value += t.next();
                }

                return token;
            }
        }

        public class WhiteSpaceTokenizer : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && Char.IsWhiteSpace(t.peek());
            }

            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "whitespace";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;

                while (t.hasMore() && Char.IsWhiteSpace(t.peek()))
                {
                    token.value += t.next();
                }

                return token;
            }
        }

        static void Main(string[] args)
        {
            //Tokenizer t = new Tokenizer();
            ////string s = "_one two 123, fsd43";
            //string s = "hi rio _thisWeek 1233f _ f 8";
            //foreach (var item in t.Token(s))
            //{
            //    Console.WriteLine(item);
            //}

            /////////////
            /// Before refactoring test
            /// 
            //List<string> tokens = tokenizer("age = 22; 123if");

            //foreach (var token in tokens)
            //{
            //    Console.WriteLine(token);
            //}

            /////////////
            

            /////////////
            /// After refactoring test
            
            
            /////////////
        }
    }
}
