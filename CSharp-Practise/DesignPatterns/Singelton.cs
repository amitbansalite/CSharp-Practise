using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOT thread SAFE

namespace ConsoleApplication1.DesignPatterns
{
    public sealed class Singelton
    {
        private Singelton(){}

        private static Singelton _instance;

        public static Singelton getInstanct()
        {
            if (_instance == null)
                _instance = new Singelton();

            return _instance;
        }
    }
}
