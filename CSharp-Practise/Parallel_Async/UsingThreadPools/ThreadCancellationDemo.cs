using System;
using System.Threading;

namespace ConsoleApplication1.Parallel_Async.UsingThreadPools
{
    public class ThreadCancellationDemo
    {
        public static void Test()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // optionally , one could register a callback method to be executed when thread execution is cancelled
            cts.Token.Register(() => Console.WriteLine("Cancelled 1"));
            cts.Token.Register(ExecuteCallBackOnCancelled, "Cancelled 2");

            // the below Anonymous function accepts an input parameter 'o' and returns nothing as expected by QueueUserWorkItem
            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 10));

            Console.WriteLine("Press <Enter> to cancel the thread execution.");
            Console.ReadLine();

            cts.Cancel();

            Console.WriteLine("Press <Enter> to exit the program.");
            Console.ReadLine();
        }

        private static void Count(CancellationToken token, int count)
        {
            while (count > 0)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled : " + count);
                    break;
                }
                
                long sum = 1;
                long previousSum = 0;

                for (var i = 2; i <= 500000000; i++)
                {
                    long tmp = sum;
                    sum += previousSum;
                    previousSum = tmp;
                }
                count--;

                Console.WriteLine(count);
            }

            Console.WriteLine("Count is done : " + count);
        }

        private static void ExecuteCallBackOnCancelled(object input)
        {
            Console.WriteLine(input);
        }
    }
}
