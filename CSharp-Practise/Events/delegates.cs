using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Events
{
    public delegate void MyDelegate(int a, int b);

    public class delegates
    {
        public delegates()
        {
            MyDelegate obj = new MyDelegate(Add);

            obj += Multiply;

            obj += Divide;

            obj(10, 5);
        }

        public void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        public void Multiply(int a, int b)
        {
            Console.WriteLine(a*b);
        }
        
        public void Divide(int a, int b)
        {
            Console.WriteLine(a/b);
        }
    }

    public class Test_delegates
    {
        public Test_delegates()
        {
            var obj = new delegates();

            Console.ReadLine();

        }
    }

    


}
