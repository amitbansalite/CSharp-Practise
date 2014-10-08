namespace ConsoleApplication1.Arbit
{
    public class OverflowException
    {
       /* private static void Main(string[] args)
        {

            //  when the below statment is executed, a StackOverflowException will be thrown
            var x = new test1();

        }*/
    }

    public class test1
    {
        public test1()
        {
            new test2();
        }
    }

    public class test2
    {
        public test2()
        {
            new test1();
        }
    }
}
