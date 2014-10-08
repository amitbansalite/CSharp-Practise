using System;

namespace ConsoleApplication1.Arbit
{
    public class Person
    {
        public string first;
        public string last;

        public Person(string first, string last)
        {
            this.first = first;
            this.last = last;
        }
    }

    public class Equality
    {
        public Equality()
        {
            var a = new Person("Amit", "Agarwal");
            var b = new Person("Amit", "Agarwal");

            if(a==b)
                Console.WriteLine("var a == var b");
            else
                Console.WriteLine("var a != var b");        // will be printed

            var c = a;
            if (c == a)
                Console.WriteLine("var a == var c");        // will be printed
            else
                Console.WriteLine("var a != var c");
        }
    }
}
