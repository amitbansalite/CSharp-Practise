using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// thread safe using static initialization when first time the class is referenced

// not LAZY but thread safety without locks and avoids all race conditions of locks totally

// readonly : ensure no one can change the value, either inner method or from outside


namespace ConsoleApplication1.DesignPatterns
{
    public sealed class Singelton_ThreadSafe
    {
        private Singelton_ThreadSafe(){}

        private static readonly Singelton_ThreadSafe _instance = new Singelton_ThreadSafe();

        public Singelton_ThreadSafe getInstance
        {
            get
            {
                return _instance;
            }           
        }
    }
}
