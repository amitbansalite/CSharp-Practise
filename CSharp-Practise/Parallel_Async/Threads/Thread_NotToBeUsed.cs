using System;
using System.Threading;

// since there are more than 1 core availble, CPU will schedule them simultaneously

// The output will keep varying and one can NEVER say which line will be printed when
    // Process will schedule the threads in which order cannot be guaranteed

namespace ConsoleApplication1.Parallel_Async.Threads
{
    public class ThreadNotToBeUsed
    {
        public static void Test()
        {
            Console.WriteLine("Main thread: starting a dedicated thread " + "to do an asynchronous operation");
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(5);

            Thread dedicatedThread2 = new Thread(ComputeBoundOp);
            dedicatedThread2.Start(5);

            Thread dedicatedThread3 = new Thread(ComputeBoundOp);
            dedicatedThread3.Start(5);
            
            Console.WriteLine("Main thread: Doing other work here...");
            //Thread.Sleep(10000); // Simulating other work (10 seconds)
            

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

            dedicatedThread.Join(); // Wait for thread to terminate
            dedicatedThread2.Join(); // Wait for thread to terminate
            dedicatedThread3.Join(); // Wait for thread to terminate
            
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        // This method's signature must match the ParameterizedThreadStart delegate
        private static void ComputeBoundOp(Object state)
        {
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            //Thread.Sleep(1000); // Simulates other work (1 second)
            // When this method returns, the dedicated thread dies

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

        }
    }
}

