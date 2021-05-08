using System;
using System.Collections.Generic;
namespace First
{
    public class Input
    {
        private readonly string input;
        private readonly int length;
        private int position;
        private int lineNumber;
        //Properties
        public int Length
        {
            get
            {
                return this.length;
            }
        }
        public int Position
        {
            get
            {
                return this.position;
            }
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
        public char Character
        {
            get
            {
                if (this.position > -1) return this.input[this.position];
                else return '\0';
            }
        }
        public Input(string input)
        {
            this.input = input;
            this.length = input.Length;
            this.position = -1;
            this.lineNumber = 1;
        }
        public bool hasMore(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return (this.position + numOfSteps) < this.length;
        }
        public bool hasLess(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return (this.position - numOfSteps) > -1;
        }
        //callback -> delegate
        public Input step(int numOfSteps = 1)
        {
            if (this.hasMore(numOfSteps))
                this.position += numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public Input back(int numOfSteps = 1)
        {
            if (this.hasLess(numOfSteps))
                this.position -= numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public Input reset() { return this; }
        public char peek(int numOfSteps = 1)
        {
            if (this.hasMore()) return this.input[this.NextPosition];
            return '\0';
        }
        //public bool hasMore(int numOfSteps=1) { return true; }
    }
    public class Token
    {
        public int Position { set; get; }
        public int LineNumber { set; get; }
        public string Type { set; get; }
        public string Value { set; get; }
        public Token(int position, int lineNumber, string type, string value) { }
    }
    public abstract class Tokenizable
    {
        public abstract bool tokenizable(Tokenizer tokenizer);
        public abstract Token tokenize(Tokenizer tokenizer);
        /*
          loop
         */
    }
    public class Tokenizer
    {
        public List<Token> tokens;
        public bool enableHistory;
        public Input input;
        public Tokenizable[] handlers;
        public Tokenizer(string source, Tokenizable[] handlers)
        {
            this.input = new Input(source);
            this.handlers = handlers;
        }
        public Tokenizer(Input source, Tokenizable[] handlers)
        {
            this.input = source;
            this.handlers = handlers;
        }
        public Token tokenize()
        {
            foreach (var handler in this.handlers)
                if (handler.tokenizable(this)) return handler.tokenize(this);
            return null;
        }
        public List<Token> all() { return null; }
    }
    public class IdTokenizer : Tokenizable
    {
        private List<string> keywords = new List<string> {
            "let","var","if","else","for","while","fun","return"
        };
        private bool isKeyword(string value)
        {
            return this.keywords.Contains(value);
        }
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            //Console.WriteLine(currentCharacter);
            return Char.IsLetter(currentCharacter) || currentCharacter == '_';
        }
        public override Token tokenize(Tokenizer t)
        {
            //1. initialize token
            Token token = new Token(t.input.Position, t.input.LineNumber, "identifier", "");
            //2. do action
            //loop
            char currentCharacter = t.input.peek();
            while (t.input.hasMore() && (Char.IsLetterOrDigit(currentCharacter) || currentCharacter == '_'))
            {
                token.Value += t.input.step().Character;
                currentCharacter = t.input.peek();
            }
            //3. return token
            if (this.isKeyword(token.Value))
                token.Type = "keyword";
            return token;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer t = new Tokenizer(new Input("how are you"), new Tokenizable[] {
                new IdTokenizer()
            });
            Console.WriteLine(t.tokenize().Value);
        }
    }
}