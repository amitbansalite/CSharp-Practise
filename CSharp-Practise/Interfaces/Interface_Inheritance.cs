using System;

namespace ConsoleApplication1.Interfaces
{
    public interface IPrint
    {
        void PrintSomething();
        void PrintVirtual();
    }

    public class Base : IPrint
    {
        public void PrintSomething()
        {
            Console.WriteLine("I am base.");
        }

        public virtual void PrintVirtual()
        {
            Console.WriteLine("I am base.");
        }

        public virtual void PrintName()
        {
            Console.WriteLine("My name is Base.");
        }
    }

    public class Child : Base
    {
        public void PrintSomething()
        {
            Console.WriteLine("I am Child");
        }

        public override void PrintVirtual()
        {
            Console.WriteLine("I am Child.");
        }

        public override void PrintName()
        {
            Console.WriteLine("My name is Child.");
        }
    }

    public class Solution
    {
        public static void Test(String[] args)
        {
            var baseObj = new Base();
            baseObj.PrintSomething();
            baseObj.PrintVirtual();
            baseObj.PrintName();

            Console.WriteLine();

            var childObj = new Child();
            childObj.PrintSomething();
            childObj.PrintVirtual();
            childObj.PrintName();

            Console.WriteLine();

            IPrint iobj = new Base();
            iobj.PrintSomething();
            iobj.PrintVirtual();
            Console.WriteLine();

            Base obj = new Child();
            obj.PrintSomething();
            obj.PrintVirtual();
            obj.PrintName();

            Console.ReadLine();
        }
    }
}
