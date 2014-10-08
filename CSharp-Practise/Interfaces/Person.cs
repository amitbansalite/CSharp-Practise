using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1.Interfaces
{
    // if a class does not implement IEnumerable<T> then one cannot use foreach() on a object of that class

    // An enumerator remains valid as long as the collection remains unchanged. 
        //If changes are made to the collection, such as adding, modifying, or deleting elements, the enumerator is irrecoverably invalidated and its behavior is undefined.

    //The enumerator does not have exclusive access to the collection; 
        //therefore, enumerating through a collection is intrinsically not a thread-safe procedure. 
    //Even when a collection is synchronized, other threads can still modify the collection, which causes the enumerator to throw an exception. 
    //To guarantee thread safety during enumeration, you can either lock the collection during the entire enumeration or catch the exceptions resulting from changes made by other threads.


    //Implementing this interface requires implementing the nongeneric IEnumerator interface. 
    //    The MoveNext and Reset methods do not depend on T, and appear only on the nongeneric interface. 
    //    The Current property appears on both interfaces, and has different return types. 
    //        Implement the nongeneric IEnumerator.Current property as an explicit interface implementation. 
    //            This allows any consumer of the nongeneric interface to consume the generic interface.

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
    }

    public class People : IEnumerable<Person>
    {
        private Person[] _people;

        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];
            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return new PeopleEnumerator(_people);
        }

        // need to implement the non generic interface also
        IEnumerator IEnumerable.GetEnumerator()
        {
            // return the generic enumerator
            return GetEnumerator();
        }
    }

   public class PeopleEnumerator : IEnumerator<Person>
   {
       public Person[] _people;

       private int position = -1;

       public PeopleEnumerator(Person[] list)
       {
           _people = list;
       }

       public bool MoveNext()
       {
           position++;
           return (position < _people.Length);
       }

       public void Reset()
       {
           position = -1;
       }

       public Person Current
       {
           get
           {
               try
               {
                   return _people[position];
               }
               catch (IndexOutOfRangeException)
               {
                   throw new InvalidOperationException();
               }
           }
           
       }

       // NOTE : the non generic method returns object where as the generic one above returns of type T
       object IEnumerator.Current
       {
           get { return Current; }
       }

       public void Dispose()
       {
           // do nothing;
       }
   }

    public class Test_LoopLists
    {
        public void test()
        {
           Person[] peopleArray = new Person[]
               {
                   new Person("John", "Smith"), 
                   new Person("Jim", "Johnson"), 
                   new Person("Sue", "Robinson")
               };

            People peopleList = new People(peopleArray);
            foreach (var person in peopleList)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }

            Console.ReadLine();
        }
    }
}
