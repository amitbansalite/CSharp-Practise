using System;
using System.Collections;

// If you implement IEquatable<T> you still MUST OVERRIDE Object’s Equals and GetHashCode

// http://blogs.msdn.com/b/jaredpar/archive/2009/01/15/if-you-implement-iequatable-t-you-still-must-override-object-s-equals-and-gethashcode.aspx

namespace ConsoleApplication1.Interfaces
{
    public class EquateObjects
    {
        class Person : IEquatable<Person>
        {
            private readonly string Name;
            
            public Person(string name)
            {
                Name = name;
            }

            public bool Equals(Person other)
            {
                if (other == null)
                {
                    return false;
                }
                return StringComparer.Ordinal.Equals(Name, other.Name);
            }
        }

        class Employee : IEquatable<Employee>
        {
            private readonly string Name;

            public Employee(string name)
            {
                Name = name;
            }

            public bool Equals(Employee other)
            {
                if (other == null)
                    return false;
               
                return StringComparer.Ordinal.Equals(Name, other.Name);
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (!(obj is Employee)) return false;

                return Equals((Employee)obj);
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }

        public void Test()
        {
            var p = new Person("Bob");
            var list = new ArrayList {p};

            Console.WriteLine(list.Contains(p)); // Prints: True
            Console.WriteLine(list.Contains(new Person("Bob")));    // Prints: False

            Console.WriteLine();

            var emp = new Employee("Bob");
            var listEmp = new ArrayList {emp};

            Console.WriteLine(listEmp.Contains(emp)); // Prints: True
            Console.WriteLine(listEmp.Contains(new Employee("Bob"))); // Print TRUE    

            Console.ReadLine();
        }
    }
}
