using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generics
{
    public class GenericMethdos
    {
        public void Show<T>(T obj)
        {
            Console.WriteLine(obj);
        }

        public void Show<T>(string msg, T value)
        {
            Console.WriteLine("{0} : {1}", msg, value);
        }

        public void Show<T1, T2>(T1 a, T2 b)
        {
            Console.WriteLine("{0} : {1}", a, b);
        }

        // genric type variable cannot have default values
        //public void Show<T>(T a = null, int value = 100)
        //{
            
        //}

        // named arguments
        public void Evaluate<T>(T right, T left, char operation)
        {
            Console.WriteLine("{0} {1} {2}", left, right, operation);
        }

    }

    public class Test_GenericMethods
    {
        public Test_GenericMethods()
        {
            var obj = new GenericMethdos();

            var a = 10;
            obj.Show(a);
            obj.Show<int>(a);

            var b = "Amit";
            obj.Show<string>(b);

            var c = 35.567;
            obj.Show<double>(c);

            obj.Show("Hello",c);
            obj.Show<int>("Hi", a);

            obj.Show(a,b);

            obj.Show<int,string>(a,b);

            obj.Evaluate(right:a, left:20, operation:'.');
            
            obj.Evaluate(a, left:30, operation:'*');

            Console.ReadLine();

        }
        
    }
}
