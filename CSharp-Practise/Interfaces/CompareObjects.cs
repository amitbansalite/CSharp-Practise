using System;
using System.Collections.Generic;

// to provide a 2nd defintion for comparing 2 objects of type T, always use Comparer<T> instead of IComparer<T>

namespace ConsoleApplication1.Interfaces
{
    public class CompareObjects : Comparer<CompareObjects>, IComparable<CompareObjects>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1} : {2}", Name, Country, Age);
        }

       
        public int CompareTo(CompareObjects other)
        {
            if (other == null)
                return 1;

            if (this.Age < other.Age)
                return -1;
            else if (this.Age > other.Age)
                return 1;
            else
                return 0;
        }

        // when we need more than one default comparison logic for a custom object, use IComparer<T>
        // once can create a new class too for this new IComparer<T>
        public override int Compare(CompareObjects x, CompareObjects y)
        {
            return x.Country.CompareTo(y.Country);
        }
    }

    public class Test_CompareObjects
    {
        public Test_CompareObjects()
        {
            var list = new List<CompareObjects>()
            {
                new CompareObjects {Name = "Mark", Age = 23, Country = "USA"},
                new CompareObjects {Name = "Tom", Age = 35, Country = "UK"},
                new CompareObjects {Name = "Ram", Age = 25, Country = "India"},
                new CompareObjects {Name = "Clark", Age = 28, Country = "Australia"},
                new CompareObjects {Name = "Jeff", Age = 31, Country = "France"},
                new CompareObjects {Name = "Matt", Age = 38, Country = "Germany"}
            };

            Console.WriteLine(list.Count);

            list.Sort();

            foreach (var obj in list)
            {
                Console.WriteLine(obj.ToString());
            }

            Console.WriteLine();

            IComparer<CompareObjects> compareByCountry = new CompareObjects();
            list.Sort(compareByCountry);

            foreach (var obj in list)
            {
                Console.WriteLine(obj.ToString());
            }

            Console.ReadLine();
        }
    }

    class XYZ : IComparable
    {
        public string content;
        public int len;
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            XYZ other = obj as XYZ;
            if (other != null)
                return len.CompareTo(other.len);
            throw new ArgumentException("something went wrong");
        }
    }
}
