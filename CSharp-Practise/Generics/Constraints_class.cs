using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generics
{
    public class Constraints_class<T>
        where T : class
    {
        private T info;

        public Constraints_class(T obj)
        {
            info = obj;
        } 

        public T GetObject()
        {
            return info;
        }

    }
    
    public interface IPerson
    {
        string FullName{ get; set; }
        DateTime DateOfBirth { get; set; }
        void Dispaly();
    }

    public class PersonIdentification : IPerson
    {
        public PersonIdentification(string name)
        {
            FullName = name;
            DateOfBirth = DateTime.Now;
        }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public void Dispaly()
        {
            Console.WriteLine("name {0} : date of birth {1} ", FullName, DateOfBirth);
        }
    }

    public class Test_GenericConstraint
    {
        public Test_GenericConstraint()
        {
            var obj = new Constraints_class<PersonIdentification>(new PersonIdentification("Amit"));

            var result = obj.GetObject();
            result.Dispaly();

            // compile error as the INT is not  reference type which is a constraint on the generic class
            //var obj2 = new Constraints_class<int>("Amit");


            Console.ReadLine();
        }
    }
}
