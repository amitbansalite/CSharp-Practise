using System;
using System.Collections.Generic;


// one can create EvenArgs<T> to send parameters also to an event delegate or create custom delegate liek below

namespace ConsoleApplication1.Events
{
    public class Events_with_CustomDelegate
    {
        public class TotalEventArgs : EventArgs
        {
            public int currentValue { get; set; }
        }

        public class Learning_Events
        {
            public int total = 0;
            public int threshold;

            public delegate void Mydelegate(Object sender, TotalEventArgs e);

            public event Mydelegate event_1;

            public event EventHandler<TotalEventArgs> event_2;

            public Learning_Events(int threshold)
            {
                this.threshold = threshold;
            }

            public void Add(int input)
            {
                total += input;
                if (total > threshold)
                {
                    EventHandler<TotalEventArgs> handler = event_2;
                    if (handler != null)
                    {
                        TotalEventArgs eventArgs = new TotalEventArgs() { currentValue = total };
                        handler(this, eventArgs);
                    }

                    Mydelegate handler_2 = event_1;
                    if (handler_2 != null)
                    {
                        TotalEventArgs eventArgs = new TotalEventArgs() { currentValue = total };
                        handler_2(this, eventArgs);
                    }
                }
            }
        }

        public class Test_LearningEvents
        {
            public void test()
            {
                var obj = new Learning_Events(10);
                
                obj.event_2 += DoSomething;
                obj.event_1 += DoSomething;

                obj.Add(13);

                Console.ReadLine();
            }

            public static void DoSomething(object sender, TotalEventArgs e)
            {
                Console.WriteLine("Threshold was reached with value : {0}", e.currentValue);
            }
        }
    }
}
