using System;
using System.Threading;

// The output will keep varying and one can NEVER say which line will be printed when
    // Process will schedule the threads in which order cannot be guaranteed

// since there are more than 1 core availble, CPU will schedule them simultaneously

namespace ConsoleApplication1.Parallel_Async.UsingThreadPools
{
    public class Basics
    {
        public static void Test()
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 2);

            // the state parameter for the QueueUserWorkItem is optional
            ThreadPool.QueueUserWorkItem(ComputeBoundOp);
            Console.WriteLine("Main thread: Doing other work here...");
            
            //Thread.Sleep(1000); // Simulating other work (10 seconds)

            long sum = 1;
            long previousSum = 0;
            int x = 0;

            while (x < 20)
            {
                sum = 1;
                previousSum = 0;

                for (var i = 2; i <= 500000000; i++)
                {
                    long tmp = sum;
                    sum += previousSum;
                    previousSum = tmp;
                }
                x++;
            }

            Console.WriteLine("Finished computing in main thread : {0}", sum);

            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }


        // This method's signature must match the WaitCallback delegate
        private static void ComputeBoundOp(Object state)
        {
            // This method is executed by a thread pool thread
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            //Thread.Sleep(1000); // Simulates other work (1 second)
            
            // When this method returns, the thread goes back
            // to the pool and waits for another task

            long sum = 1;
            long previousSum = 0;
            int x = 0;

            while (x < 20)
            {
                sum = 1;
                previousSum = 0;

                for (var i = 2; i <= 500000000; i++)
                {
                    long tmp = sum;
                    sum += previousSum;
                    previousSum = tmp;
                }
                x++;
            }

            Console.WriteLine("Finished computing in other thread : {0}", sum);

        }
    }
}

