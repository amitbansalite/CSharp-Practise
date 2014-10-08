using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApplication1.Generics
{
    public class G_PerformanceBenefits
    {
        private static void Test(String[] args)
        {
            ValueTypePerfTest();
            ReferenceTypePerfTest();

            Console.ReadLine();
        }

        private static void ValueTypePerfTest()
        {
            const Int32 count = 10000000;
            using (new OperationTimer("List<Int32>"))
            {
                var l = new List<Int32>();
                for (var n = 0; n < count; n++)
                {
                    l.Add(n); // No boxing
                    var x = l[n]; // No unboxing
                }
                l = null; // Make sure this gets garbage collected
            }
            using (new OperationTimer("ArrayList of Int32"))
            {
                var a = new ArrayList();
                for (var n = 0; n < count; n++)
                {
                    a.Add(n); // Boxing
                    var x = (Int32) a[n]; // Unboxing
                }
                a = null; // Make sure this gets garbage collected
            }
        }

        private static void ReferenceTypePerfTest()
        {
            const Int32 count = 10000000;
            using (new OperationTimer("List<String>"))
            {
                var l = new List<String>();
                for (var n = 0; n < count; n++)
                {
                    l.Add("X"); // Reference copy
                    String x = l[n]; // Reference copy
                }
                l = null; // Make sure this gets garbage collected
            }

            using (new OperationTimer("ArrayList of String"))
            {
                var a = new ArrayList();
                for (var n = 0; n < count; n++)
                {
                    a.Add("X"); // Reference copy
                    String x = (String) a[n]; // Cast check & reference copy
                }
                a = null; // Make sure this gets garbage collected
            }
        }

    }

    // This class is useful for doing operation performance timing
    internal sealed class OperationTimer : IDisposable
    {
        private Stopwatch m_stopwatch;
        private String m_text;
        private Int32 m_collectionCount;

        public OperationTimer(String text)
        {
            PrepareForOperation();
            m_text = text;
            m_collectionCount = GC.CollectionCount(0);
            // This should be the last statement in this
            // method to keep timing as accurate as possible
            m_stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("{0} (GCs={1,3}) {2}", (m_stopwatch.Elapsed),
                              GC.CollectionCount(0) - m_collectionCount, m_text);
        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

}
