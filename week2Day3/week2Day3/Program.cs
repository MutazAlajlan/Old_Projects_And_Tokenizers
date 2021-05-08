#define school
using System;

namespace week2Day3
{
//#if school
    #region studentClass
    public class Student
    {
        int age;
        string name;
        string lastName;

        public Student()
        {
            this.age = 10;
            this.name = "First";
            this.lastName = "The last";
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
#if school
            Console.WriteLine("Hello");
#endif
#warning We are skipping Hello.
#error THIS IS AN ERROR!!!!.

            Console.WriteLine("Hello World!");
        }
    }
}
