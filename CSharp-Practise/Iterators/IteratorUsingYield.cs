using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Iterators
{
    public class IteratorUsingYield : IEnumerable
    {
        private string[] days = {"Sun", "Mon", "Tue"};

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < days.Length; i++)
            {
                yield return days[i];
            }
        }
    }

    public class Test_IteratorUsingYield
    {
        private List<int> _numbers; 

        public IList<int> Numbers
        {
            get { return _numbers; }
        }


        public void Test()
        {
            var days = new IteratorUsingYield();

            foreach (var day in days)
            {
                Console.WriteLine(day);
            }

            Console.ReadLine();
        }        
    }
}
