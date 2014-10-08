using System;

namespace ConsoleApplication1.Generics
{
    public class GenericClasses<T>
    {
        private readonly T _value;

        public GenericClasses(T value)
        {
            this._value = value;
        } 

        public void Show()
        {
            Console.WriteLine("value : {0}", _value);
        }

        public void Show(T temp)
        {
            Console.WriteLine("{0} : {1}", temp, _value);
        }

        public T GetValue()
        {
            return _value;
        }
    }

    public class Test_genericClasses
    {
        public Test_genericClasses()
        {
            var obj = new GenericClasses<int>(100);

            obj.Show();
            obj.Show(10);

            var x = "Hello";
            //obj.Show<string>(x);        // not allowed, compile time error

            var a = 50;
            obj.Show(a);

            Console.WriteLine(obj.GetValue());

            Console.ReadLine();
        }
    }
}
