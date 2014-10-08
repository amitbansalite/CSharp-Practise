using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generics
{
    public class Constraints_interface<T>
        where T : IComparable
    {
        public Constraints_interface(){}

        public IEnumerable<T> Sort(IEnumerable<T> list )
        {
            return list.OrderBy(s => s);
        }
    }

    public class Person : IComparable
    {
        public string name { get; set; }

        public Person(string name)
        {
            this.name = name;
        }

        public int CompareTo(object obj)
        {
            var tmp = (Person) obj;

            return this.name.CompareTo(tmp.name);
        }
    }



    public class Test_Constraints_interface
    {
        public Test_Constraints_interface()
        {
            var obj = new Constraints_interface<string>();
            var strList = new List<string>() {"Hi", "Abcd", "rt3", "amit", "adi", "bala"};
            var sortedList = obj.Sort(strList);

            sortedList.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
            (from n in sortedList select n).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            var obj2 = new Constraints_interface<Person>();
            var list = new List<Person>();
            list.Add(new Person("Amit"));
            list.Add(new Person("Raj"));
            list.Add(new Person("Saurabh"));
            list.Add(new Person("Prakash"));
            list.Add(new Person("Agarwal"));

            var sortedPersons = obj2.Sort(list);
            
            foreach (var person in sortedPersons)
            {
                Console.WriteLine(person.name);
            }

            Console.ReadLine();
        }
    }   
}
