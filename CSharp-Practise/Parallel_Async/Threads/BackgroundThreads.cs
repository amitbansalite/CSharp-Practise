using System;
using System.Threading;

// very bad practise to create a foreground thread
    // should be done with a lot of caution

namespace ConsoleApplication1.Parallel_Async.Threads
{
    public class BackgroundThreads
    {
        public static void Test()
        {
            // Create a new thread (defaults to foreground)
            Thread t = new Thread(Worker);
            // Make the thread a background thread
            t.IsBackground = false;
            t.Start(); // Start the thread


            // If t is a foreground thread, the application won't die for about 10 seconds
            // If t is a background thread, the application dies immediately
            Console.WriteLine("Returning from Main");

            Console.ReadLine();
        }
        private static void Worker()
        {
            Thread.Sleep(10000); // Simulate doing 10 seconds of work
            // The following line only gets displayed if this code is executed by a foreground thread
            Console.WriteLine("Returning from Worker");
            
            Console.ReadLine();
        }
    }
}
