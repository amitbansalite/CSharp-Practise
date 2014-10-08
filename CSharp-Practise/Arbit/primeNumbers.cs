using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Arbit
{
    public class primeNumbers
    {
        static int getNumberOfPrimes(int N)
        {
            int count = 0;
            bool flag = false;

            for (int i = 2; i <= N; i++)
            {
                flag = isPrime(i);
                if (flag)
                {
                    count++;
                    Console.WriteLine(i);
                }
            }
            return count;
        }

        public static bool isPrime(int num)
        {
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }   
    }
}
