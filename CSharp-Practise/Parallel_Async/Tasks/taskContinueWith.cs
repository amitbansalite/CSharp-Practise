using System;
using System.Threading.Tasks;

// improves performance and when a task finishes execution, next one starts only after and only the appropriate one starts
    // rest all ends

namespace ConsoleApplication1.Parallel_Async.Tasks
{
    public class TaskContinueWith
    {
        public static void Test(String[] args)
        {
            // Create and start a Task, continue with multiple other tasks
            Task<Int32> t = Task.Run(() => Sum(10000000));

            // Each ContinueWith returns a Task but you usually don't care
            t.ContinueWith(task => Console.WriteLine("The sum is: " + task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

            t.ContinueWith(task => Console.WriteLine("Sum threw: " + task.Exception.InnerException), TaskContinuationOptions.OnlyOnFaulted);
            
            t.ContinueWith(task => Console.WriteLine("Sum was canceled"), TaskContinuationOptions.OnlyOnCanceled);
            
            Console.WriteLine("Enter any key to exit the applciation");
            Console.ReadLine();
        }

        private static int Sum(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                checked { sum += n; }       // if n is large, this will throw System.OverflowException
            }
            return sum;
        }
    }
}
