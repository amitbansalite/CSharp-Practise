using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Arbit
{
    public class Inheritance
    {
        public class Base
        {
            public void Print() { Console.WriteLine(" Base class"); }
        }

        public class Child : Base
        {
            public void Print() { Console.WriteLine(" Child class"); }
        }

        public void Test(string[] args)
        {
            // Declare an instance of the SampleCollection type.
            Base obj = new Child();

            obj.Print();
            Console.ReadLine();
        }
    }

}
