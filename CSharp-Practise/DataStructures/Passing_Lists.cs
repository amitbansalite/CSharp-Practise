using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1.DataStructures
{
    public class Passing_Lists
    {
        public List<int> ModifyList(List<int> input )
        {
            input.Add(10);
            return input;
        }

        public ArrayList ModifyArrayList(ArrayList input)
        {
            input.Add(10);
            return input;
        }  

        public int[] ModifyArray(int[] input)
        {
            input[3] = 10;
            return input;
        }
    }

    public class Test_Passing_lists
    {
        public Test_Passing_lists()
        {
            var obj = new Passing_Lists();

            var list = new List<int>() {1, 2, 3, 4};
            list = obj.ModifyList(list);
            foreach (var i in list)
                Console.WriteLine(i);

            Console.WriteLine();

            var arrayList = new ArrayList() {1, 2, 3};
             arrayList = obj.ModifyArrayList(arrayList);
            foreach (var i in arrayList)
                Console.WriteLine(i);

            Console.WriteLine();

            var array = new int[4];
            array[0] = 0;
            array[1] = 1;
            array[2] = 2;
            array = obj.ModifyArray(array);
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    
    }
}
