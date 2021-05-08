﻿using System;
// Mutaz test.
namespace InputProgram
{
    class Program
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
            public bool Compare()
            {
                if(this.Pos)
            }
            public Input reset() { return this; }
            public char peek(int numOfSteps = 1) { return '\0'; }
            //public bool hasMore(int numOfSteps=1) { return true; }
        }
        static void Main(string[] args)
        {
            Input inp = new Input("Hello World!");
            char ch = inp.step().step().Character;
            Console.WriteLine(ch);
        }
    }
}
