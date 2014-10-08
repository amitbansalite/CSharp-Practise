using System;
using System.Threading;
using System.Threading.Tasks;

// READ carefully all the various ways of crearting a TASK

namespace ConsoleApplication1.Parallel_Async.Tasks
{
    public class Basics
    {
        public static void test(String[] args)
        {
            // task creation is very similar to ThreadPool usage
            ThreadPool.QueueUserWorkItem(DoSomething, 5);

            Task.Run(() => DoSomething(5));

            var t = new Task(DoSomething, 5);
            t.Start();

            Task.Factory.StartNew(DoSomething, 5);


            // Tasks that return a value
            Task<int> t2 = new Task<int>(n => Compute((int)n), 10);
            t2.Start();
            t2.Wait();
            Console.WriteLine("the result  is : " + t2.Result);

            // Tasks that return a value and accept a CancellationToken
            var cts = new CancellationTokenSource();
            Task<int> t3 = Task.Run(() => ComputeSum(cts.Token, 900000000), cts.Token);
            
            cts.Cancel();

            try
            {
                Console.WriteLine(" The sum is : " + t3.Result);
            }
            catch (AggregateException e)
            {
                e.Handle(x => x is OperationCanceledException);
                Console.WriteLine("Sum was cancelled");
            }

            Console.WriteLine("Press any key to exit the applciation.");
            Console.ReadLine();
        }

        // another way to create a task that returns a value
        public async Task DoWork()
        {
            int res = await Task.FromResult<int>(Compute(4));
        }
 

        private static void DoSomething(object input) { }

        private static int Compute(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                checked { sum += n; }       // if n is large, this will throw System.OverflowException
            }
            return sum;
        }

        private static int ComputeSum(CancellationToken ctv, int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                // The following line throws OperationCanceledException when Cancel
                    // is called on the CancellationTokenSource referred to by the token
                ctv.ThrowIfCancellationRequested();

                checked { sum += n; }       // if n is large, this will throw System.OverflowException
            }
            return sum;
        }
    }
}
