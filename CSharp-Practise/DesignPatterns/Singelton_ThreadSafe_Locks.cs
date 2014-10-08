
// 1. VOLATILE to ensure that assignment to the instance variable completes before the instance variable can be accessed. 

// 2. SYNCROOT instance to lock on, rather than locking on the type itself, to avoid deadlocks. using a private object to the class itself for locking

// 3. double checking for null instance because : 

namespace ConsoleApplication1.DesignPatterns
{
    public sealed class Singelton_ThreadSafe_Locks
    {
        private Singelton_ThreadSafe_Locks(){}

        private static volatile Singelton_ThreadSafe_Locks _instance;
        private static object syncRoot = new object();

        public static Singelton_ThreadSafe_Locks getInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new Singelton_ThreadSafe_Locks();
                }
            }

            return _instance;
        }
    }
}
