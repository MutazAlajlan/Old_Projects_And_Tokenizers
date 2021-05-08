using System;
using System.Collections.Generic;
namespace DataNReference
{
    class HTMLTags
    {
        //data
        public string name;
        public bool hasEnd;
        public string innerText;

        //references:
        public HTMLTags parent;
        public List<HTMLTags> children;

        public void addChild(HTMLTags child) { }
        public void removeChild(HTMLTags child) { }
        public void addChild(string name, bool hasEnd, string innerText) { }
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
