using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// DoWork method should not be mutable, no state must be shared among different invocations of DoWork()

// Methods do not return until all parallel tasks complete

// useful for lots of items, lots of work for each item

namespace ConsoleApplication1.Parallel_Async.Tasks
{
    public class Parallel_For
    {
        public static void Test(String[] args)
        {
            // Mehtod 1
            for (int i = 0; i < 100; i++)
                DoWork(i);

            Parallel.For(0, 100, i => DoWork(i));

            // Method 2
            var list = new List<int>(100);
            foreach (var item in list)
                DoWork(item);
            Parallel.ForEach(list, item => DoWork(item));

            // Method 3
            DoWork(1); DoWork(2); DoWork(3);
            Parallel.Invoke(() => DoWork(1),
                            () => DoWork(2),
                            () => DoWork(3));


            // Method 4
            var max = 10;
            var loopResult = Parallel.For(0, max, (i, loopState) =>
                                    {
                                      // Do something 
                                      if ( true /* stopping condition is true */)
                                      {
                                        loopState.Break();      // One could aso use loopState.Stop()  (therre are subtle differences among the two)
                                      }
                                    });

            if ( !loopResult.IsCompleted && loopResult.LowestBreakIteration.HasValue)
                Console.WriteLine("Loop encountered a break at {0}", loopResult.LowestBreakIteration.HasValue);

            // Method 5
            max = 10;
            var token = new CancellationTokenSource().Token;
            var options = new ParallelOptions {CancellationToken = token};
            loopResult = Parallel.For(0, max, options, (i) =>
            {
                // Do something 
                if (token.IsCancellationRequested /* stopping condition is true */)
                {
                    // ... optionally exit this iteration early
                }
            });




            // ------------------------------------
            // -----------------------------------

            // read world example, watch the task manager (all the cores will be used heavily)
            Console.WriteLine( HeavyComputation() );

            Console.WriteLine("Press any key to exit the applciation.");
            Console.ReadLine();
        }

        private static void DoWork(int i) { }

        private static long HeavyComputation()
        {
            long masterTotal = 0;
            ParallelLoopResult result = new ParallelLoopResult();

            try
            {
                result = Parallel.For<long>(0, 9999900000,

                                             () => { return 0; },

                                             (i, loopState, taskLocalTotal) => { return taskLocalTotal + i; },

                                             taskLocalTotal => { Interlocked.Add(ref masterTotal, taskLocalTotal); }
                                         );
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Flatten().ToString());
            }
            if (result.IsCompleted)
            {
                Console.WriteLine(" Operation Complete.");
                return masterTotal;
            }
            
            Console.WriteLine(" Operation did not complete completely, the last item processed was : " + result.LowestBreakIteration);
            return -1;
        }


        // an example for Parallel.ForEach
        //static void UpdatePredictionsSequential(AccountRepository accounts)
        //{
        //    // sequential execution
        //    foreach (Account account in accounts.AllAccounts)
        //    {
        //        Trend trend = SampleUtilities.Fit(account.Balance);
        //        double prediction = trend.Predict(
        //                         account.Balance.Length + NumberOfMonths);
        //        account.SeqPrediction = prediction;
        //        account.SeqWarning = prediction < account.Overdraft;
        //    }

        //    // parallel execution
        //    accounts.AllAccounts
        //     .AsParallel()
        //     .ForAll(account =>
        //     {
        //         Trend trend = SampleUtilities.Fit(account.Balance);
        //         double prediction = trend.Predict(
        //                             account.Balance.Length + NumberOfMonths);
        //         account.PlinqPrediction = prediction;
        //         account.PlinqWarning = prediction < account.Overdraft;
        //     });  
        //}
        
    }
}
