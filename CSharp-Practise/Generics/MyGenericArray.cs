using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generics
{
    public class MyGenericArray<T>
    {
        private T[] array;

        public MyGenericArray(int size)
        {
            array = new T[size+1];
        }

        public T GetItem(int index)
        {
            return array[index];
        }

        public void SetItem(int index, T value)
        {
            array[index] = value;
        }
    }

    public class Tester
    {
        public Tester()
        {
            var intArray = new MyGenericArray<int>(10);

            for (int i = 0; i < 10; i++)
            {
                intArray.SetItem(i, i*10);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(intArray.GetItem(i));
            }

            var charArray = new MyGenericArray<char>(10);

            for (int i = 0; i < 10; i++)
            {
                charArray.SetItem(i, (char)(i + 97));
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(charArray.GetItem(i));
            }

            Console.ReadLine();
        }
    }


}
