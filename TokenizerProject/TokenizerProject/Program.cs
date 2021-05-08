using System;

namespace TokenizerProject
{
    class Program
    {
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
                if (this.hasMore())
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

            public Token tokenize(Tokenizable[] handlers)
            {
                foreach (var t in handlers)
                {
                    if (t.tokenizable(this))
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

                while (t.hasMore() && Char.IsDigit(t.peek()))
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
            //creat whitespace tokenizer
            Console.WriteLine("Hello World!");
            // use while(!= null)

            //Tokenizer t = new Tokenizer("1234");
            // Tokenizable[] handlers = new Tokenizable[] { new NumberTokenizer(), new IdTokenizer() };
            // Token token = t.tokenize
            //(new Tokenizable[] { new NumberTokenizer() });
            // while (token != null)
            {
                //peek can take default 1 and caller can specifiy the length to solve "//" problem.

                //call and print

                //token = t.tokenizer(handlers);
            }
        }
    }
}
