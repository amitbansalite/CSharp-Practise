using System;

namespace ConsoleApplication1.DataStructures
{
    public class MultiDimensionalArrays
    {
        public MultiDimensionalArrays()
        {
            // create a jagged array or a 2D array
            var x = new int[4][];
            Console.WriteLine(x.Length);
            Console.WriteLine(x.Rank);      // only 1 dimension
            x[0] = new int[10];
            x[1] = new int[40];
            x[2] = new int[30];
            x[3] = new int[20];
            Console.WriteLine(x[0].Length);

            // create a multi dimensional array 
            var y = new int[4, 4];
            Console.WriteLine(y.Length);
            Console.WriteLine(y.Rank);
            Console.WriteLine(y.GetLength(0));

            var z = new string[5, 5, 5];
            Console.WriteLine(z.Length);
            Console.WriteLine(z.Rank);


            Console.ReadLine();
        }
    }
}
