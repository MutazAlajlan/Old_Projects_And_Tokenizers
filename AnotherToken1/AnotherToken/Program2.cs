using System;
using System.Collections.Generic;
namespace AdvancedTokenizere
{
    class Program
    {
        public class Input
        {
            private readonly string input;
            private readonly int length;
            public int position;
            // public int nextPosition;
            public int lineNumber;
            public char currentValue;
            private int value;

            //Properties

            public int Length
            {
                get
                {
                    return this.Length;
                }
            }
            public int Position
            {
                get
                {
                    return this.position;
                }
                //set
                //{
                //    this.position = value;
                //}
            }
            public int NextPosition
            {
                get
                {
                    return this.position + 1;
                }
            }


            public int LineNumber
            {
                get
                {
                    return this.lineNumber;
                }
            }

            public bool HasMore
            {
                get
                {
                    return this.NextPosition < this.length;
                }
            }
            public char Character
            {
                get
                {
                    if (this.HasMore) return this.input[this.position];
                    else return '\0';
                }
            }


            public Input(string input)
            {
                this.input = input;
                this.length = input.Length;
                this.position = -1;
                this.nextPosition = 0;
                this.lineNumber = 1;
                this.currentValue = '\0';

            }

            public Input step(int numOfSteps = 1) { return this; }
            public Input reset() { return this; }
            public char peek(int numOfSteps = 1) { return '\0'; }
            public bool hasMore(int numOfSteps = 1) { return true; }
        }
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
            public Tokenizer(string input)
            {
                this.input = input;
                this.currentPosition = -1;
                this.lineNumber = 1;
            }
            public char peek(int pos = 1)
            {
                if (this.hasMore())
                {
                    return this.input[this.currentPosition + pos];
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
            public bool hasMore(int numOfChar = 1)
            {
                return (this.currentPosition + numOfChar) < this.input.Length;
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
                //throw new Exception("Unexpected token");
                return null;
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
        public class IdTokenizer : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && (Char.IsLetter(t.peek()) || t.peek() == '_');
            }
            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "id";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;
                while (t.hasMore() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '_'))
                {
                    token.value += t.next();
                }
                return token;
            }
        }
        public class CommentTokenizer : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && (t.peek() == '/' && t.peek(2) == '/');
            }
            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "comment";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;
                while (t.hasMore(2) && t.peek() == '/')
                {
                    token.value += t.next();
                }
                return token;
            }
        }
        public class HashTokenizer : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && (Char.IsLetter(t.peek()) || t.peek() == '#');
            }
            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "hash";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;
                while (t.hasMore() && (Char.IsLetter(t.peek()) || t.peek() == '#'))
                {
                    token.value += t.next();
                }
                return token;
            }
        }
        public class AtTokenizer : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '@');
            }
            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "At";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;
                while (t.hasMore() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '@'))
                {
                    token.value += t.next();
                }
                return token;
            }
        }
        public class SingleQ : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '\'');
            }
            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "single quotation";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;
                int count = 0;
                while (t.hasMore() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '\''))
                {

                    if (t.peek() == '\'')
                    {
                        token.value += t.next();
                        count++;
                        if (count == 2)
                        {
                            return token;
                        }
                    }
                    else
                    {
                        token.value += t.next();
                    }
                }
                if (count % 2 != 0)
                {
                    token.value = "Error, uneven count of quotations.";
                }
                return token;
            }
        }
        public class Double : Tokenizable
        {
            public override bool tokenizable(Tokenizer t)
            {
                return t.hasMore() && (Char.IsDigit(t.peek()) || t.peek() == '.');
            }
            public override Token tokenize(Tokenizer t)
            {
                Token token = new Token();
                token.type = "single quotation";
                token.value = "";
                token.position = t.currentPosition;
                token.lineNumber = t.lineNumber;
                int count = 0;
                while (t.hasMore() && (Char.IsDigit(t.peek()) || t.peek() == '.'))
                {
                    if (count <= 1)
                    {
                        if (t.peek() == '.')
                        {
                            ++count;
                            token.value += t.next();

                        }
                        else
                        {
                            token.value += t.next();
                        }
                    }
                    else if (count >= 2)
                    {
                        token.value = "Error, there is more than one decimal.";
                        return token;
                    }

                }
                return token;
            }
        }
        static void Main(string[] args)
        {
            string testCase = "123 3456 // _myusername n// _ j #Adel @gf66 8u gf66 '8''a' 'b' 'c' '1.1 1234.54 2324.42412 1..2";
            Tokenizer t = new Tokenizer(testCase);
            Tokenizable[] handlers = new Tokenizable[] {
                new CommentTokenizer(),
                new Double(),
                new NumberTokenizer(),
                new WhiteSpaceTokenizer(),
                new IdTokenizer(),
                new HashTokenizer(),
                new AtTokenizer(),
                new SingleQ()

            };
            Token token = t.tokenize(handlers);
            while (token != null)
            {
                Console.WriteLine("Token Value : " + token.value + " Num of chars " + token.value.Length);
                token = t.tokenize(handlers);
            }
        }
    }
}