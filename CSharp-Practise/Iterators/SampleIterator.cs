using System;
using System.Collections;

namespace ConsoleApplication1.Iterators
{
    public class SampleIterator
    {
        public void test()
        {
            foreach (var item in SomeNumbers())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        // The return type of an iterator method or get accessor can be IEnumerable, IEnumerable<T>, IEnumerator, or IEnumerator<T>.
        public static IEnumerable SomeNumbers()
        {
            yield return 3;
            yield return 5;
            yield return 8;
        }
    }
}
