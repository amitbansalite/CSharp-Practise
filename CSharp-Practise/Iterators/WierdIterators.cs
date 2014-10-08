using System;
using System.Collections.Generic;

// https://msmvps.com/blogs/jon_skeet/archive/2010/07/27/iterate-damn-you.aspx

namespace ConsoleApplication1.Iterators
{
    public class WierdIterators
    {
        static void ShowNext(IEnumerator<int> iterator)
        {
            if (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
            else
            {
                Console.WriteLine("Done");
            }
        }

        public void test()
        {
            List<int> values = new List<int> { 1, 2 };
            using (var iterator = values.GetEnumerator())
            {
                ShowNext(iterator);//1
                ShowNext(iterator);//2
                ShowNext(iterator);//done
            }

            Console.WriteLine();

            IList<int> values2 = new List<int> { 1, 2 };
            using (var iterator = values2.GetEnumerator())
            {
                ShowNext(iterator);
                ShowNext(iterator);
                ShowNext(iterator);
            }

            Console.WriteLine();

            List<int> values3 = new List<int> { 1, 2 };
            using (IEnumerator<int> iterator = values3.GetEnumerator())
            {
                ShowNext(iterator);
                ShowNext(iterator);
                ShowNext(iterator);
            }
            Console.ReadLine();
        } 
    }
}
