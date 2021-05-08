using System;

namespace Week2Day4
{
    public static class Util
    {
        public static void Powers(ref this int num)
    {
           num *= num;
    }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            x.Powers();
            x.Powers();
            x.Powers();
            Console.WriteLine(x);
        }
    }
}
