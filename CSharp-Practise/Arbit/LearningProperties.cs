using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Arbit
{
    class SampleCollection<T>
    {
        // Declare an array to store the data elements. 
        private T[] arr = new T[100];

        // Define the indexer, which will allow client code 
        // to use [] notation on the class instance itself. 
        // (See line 2 of code in Main below.)         
        public T this[int i]
        {
            get
            {
                // This indexer is very simple, and just returns or sets 
                // the corresponding element from the internal array. 
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }

    // This class shows how client code uses the indexer. 
    class Program
    {
        static void Test(string[] args)
        {
            // Declare an instance of the SampleCollection type.
            SampleCollection<string> stringCollection = new SampleCollection<string>();

            // Use [] notation on the type.
            stringCollection[0] = "Hello, World";
            System.Console.WriteLine(stringCollection[0]);
        }
    }
}


//class TimePeriod
//{
//    private double seconds;

//    public double Hours
//    {
//        get { return seconds / 3600; }
//        set { seconds = value * 3600; }
//    }
//}