using System;
using System.Threading;

namespace ConsoleApplication1.Parallel_Async.UsingThreadPools
{
    class ThreadPool_Examples
    {
        public static void Test(String[] args)
        {
             string input = "abcd";

            // as above this would also work
            ThreadPool.QueueUserWorkItem(x => Hello(input));

            // below does not work as Hello is accpeting string and not OBJECT as required by QueueUserWorkItem
            //ThreadPool.QueueUserWorkItem(Hello, input);

            // below works as Do accepts OBJECT and we are passing string which is of TYPE OBJECT
            ThreadPool.QueueUserWorkItem(Do, input);

            ThreadPool.QueueUserWorkItem(x => DoSomething("hello", 10, 20, true));
            
        }

        private static void Do(object input) { }

        private static void Hello(string input) { }

        private static void DoSomething(string in1, int in2, object in3, bool in4) { }
    }
}
