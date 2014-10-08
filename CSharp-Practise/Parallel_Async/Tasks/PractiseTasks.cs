using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ConsoleApplication1.Parallel_Async.Tasks
{
    public class PractiseTasks
    {
        public PractiseTasks()
        {
            int N = 100;
            var result = new BigInteger(1);

            // 1. create a task
            var T = new Task<string>(() => String.Concat("amit","agarwal"));

            var t5 = new Task(DoSomething);
            // program "forks" and now 2 code streams are executing concurrently
            T.Start();                          
            
            // 2. another and neater way to create a Task
            var T2 = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < N; i++)
                    {
                        result *= i;
                    }
                    
                });

            var t3 = T2.ContinueWith((antecedant) =>
                                        {
                                            Console.WriteLine(result);
                                        },
                                      TaskScheduler.FromCurrentSynchronizationContext()  );

            // result object above will never face a race condition as the t3 task will always execute after T2 is completed


            // 3. facade task

            var existingOp = new TaskCompletionSource<int>();
            Task t_facade = existingOp.Task;


            // 4. task returning a result

            Task<int> T4 = Task.Factory.StartNew(() =>
                                                {
                                                    return 10;
                                                });

            int R = T4.Result;



        }

        public void DoSomething()
        {
            
        }

        //public static void Main()
        //{
            
        //}

    }
}
