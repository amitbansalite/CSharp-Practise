using System;

namespace ConsoleApplication1.Events
{
    public class Events_withNOParams
    {
        public int total =0;
        public int threshold;

        public event EventHandler ThresholdReached;
 
        public Events_withNOParams(int threshold)
        {
            this.threshold = threshold;
        }

        public void Add(int input)
        {
            total += input;
            if (total > threshold)
            {
                EventHandler handler = ThresholdReached;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }

    public class Test_LearningEvents
    {
        public void Test()
        {
            var obj = new Events_withNOParams(10);
            obj.ThresholdReached += DoSomething;

            obj.Add(11);
            
            Console.ReadLine();
        }

        public static void DoSomething(object sender, EventArgs e)
        {
            Console.WriteLine("Threshold was reached.");
        }
    }
}
