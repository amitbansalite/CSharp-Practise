using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1.Arbit
{
    public class CountObjects
    {
        private static int _counter;

        public CountObjects()
        {
            _counter++;
        }

        ~CountObjects()
        {
            _counter--;
        }

        public static int GetActiveInstances()
        {
            return _counter;
        }
    }

    public class CountObjects2
    {
        private static int _counter;
        private static readonly object _lock = new object();

        public CountObjects2()
        {
            lock (_lock)
            {
                _counter++;
            }
        }

        ~CountObjects2()
        {
            lock (_lock)
            {
                _counter--;
            }
        }

        public static int GetActiveiInstances()
        {
            return _counter;
        }
    }

    public class CountObjects3
    {
        private static int _counter;

        public CountObjects3()
        {
            Interlocked.Increment(ref _counter);
        }

        ~CountObjects3()
        {
            Interlocked.Decrement(ref _counter);
        }

        public static int GetActiveInstances()
        {
            return _counter;
        }
    }
}
