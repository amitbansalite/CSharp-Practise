using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Arbit
{
    class Animal{}

    class Dog : Animal{}

    class Cat : Animal{}

    public class ContraAndCovar
    {
        public void Test(){
            Animal objAnimal = new Dog();   // valid statement
            objAnimal = new Cat();          // valid statement

            // this is covariance : look at the definition of IEnumerable which takes in the generic T as IEnumerable<OUT T>
            IEnumerable<Animal> animals = new List<Dog>();  // this was not valid before .Net 4.0 
            

            // this is not allowed even now as List<T> can be manipulated
            //List<Animal> animalsList = new List<Dog>(); 





        }
    }
}
