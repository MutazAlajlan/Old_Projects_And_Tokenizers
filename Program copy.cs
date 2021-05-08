using System;
using System.Collections.Generic;

namespace AnotherToken
{
    class Program
    {
        public class Token
        {
            public string type;
            public string value;
            public int position;
            public int lineNumber;
        }

        public abstract class Tokenizable
        {
            public abstract bool tokenizable(Tokenizer t);
            public abstract Token tokenize(Tokenizer t);
        }
        //public class IdTokenizer

        //public class NumberTokenizer : Tokenizable
        //{
        //    public override bool token
        // }
        public class Tokenizer //(string input)
        {
            //this.input = input;
            //this.currentPosition = -1;
            //this.lineNumber = 1;
            public string input;
            public int currentPosition;
            public int lineNumber;

            public char peek() ////int numbOfPosition = 1 as argument, it will cause out of bounds? on return
            {
                if (this.hasMore())
                {
                    //here will be 
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
                if (currentChar == '\n')
                {
                    this.lineNumber++;
                }
                return currentChar;
            }
            public bool hasMore()
            {
                return (this.currentPosition + 1) < this.input.Length;
            }

            public Token tokenizer(Tokenizable[] handlers)
            {
                foreach (var t in handlers)
                {
                    if (t.tokenizable(this))
                    {
                        return t.tokenize(this);
                    }
                }
                return null;
            }
        }


    public class NumberTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizable t)
        {
            return t.hasMore() && Char.IsDigit(t.peek());
        }

        public override NumberTokenizer tokenize(NumberTokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "number";
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;

            while(t.hasMore() && Char.IsDigit(t.peek()))
            {
                token.value += t.next();
            }
            return token;
        }
    }
    public class WhiteSpace : Tokenizable
    {
        //public override bool tokenizable(Tokenizable t)
        //{
        //    return t.hasMore() && Char.IsDigit(t.peek());
        //}

        //public override NumberTokenizer tokenize(NumberTokenizer t)
        //{
        //    Token token = new Token();
        //    token.value = "";
        //    token.type = "number";
        //    token.position = t.currentPosition;
        //    token.lineNumber = t.lineNumber;

        //    while (t.hasMore() && Char.IsDigit(t.peek()))
        //    {
        //        token.value += t.next();
        //    }
        //    return token;
        //}
    }
    public class IdTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizable t)
        {
            return t.hasMore() && Char.IsLetter(t.peek());
        }

        public override NumberTokenizer tokenize(NumberTokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "id";
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;

            while (t.hasMore() && Char.IsLetterOrDigit(t.peek()) || t.pee)
            {
                token.value += t.next();
            }
            return token;
        }
    }
    static void Main(string[] args)
        {
        //creat whitespace tokenizer
            Console.WriteLine("Hello World!");
        // use while(!= null)

        Tokenizer t = new Tokenizer("1234");
        Tokenizable[] handlers = new Tokenizable[] { new NumberTokenizer(), new IdTokenizer() };
        Token token = t.tokenize
            //(new Tokenizable[] { new NumberTokenizer() });
        while(token != null)
        {
                //peek can take default 1 and caller can specifiy the length to solve "//" problem.

                //call and print

                token = t.tokenizer(handlers);
        }
        }
    }
}
