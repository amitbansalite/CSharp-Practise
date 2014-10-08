using System;

namespace ConsoleApplication1.Arbit
{
    public class Parameter_ByReference
    {
        public int count;

        public Parameter_ByReference(int count)
        {
            this.count = count;
        }
    }

    public class Test_Parameter_ByReference
    {
        //static void Main(string[] args)
        //{
        //    var obj = new Parameter_ByReference(100);
        //    Console.WriteLine("Original value : {0}", obj.count);

        //    SetInputObjectToNull(obj);

        //    if(obj == null)
        //        Console.WriteLine("Object is null");
        //    else
        //        Console.WriteLine("Object is not null");


        //    Console.WriteLine();

        //    ModifyInputObject(obj);
        //    Console.WriteLine("Current value {0}", obj.count);

        //    Console.ReadLine();
        //}
       
        public static void SetInputObjectToNull(Parameter_ByReference that)
        {
            that = null;
        }

        public static void ModifyInputObject(Parameter_ByReference that)
        {
            that.count = 50;
        }
    }
}
