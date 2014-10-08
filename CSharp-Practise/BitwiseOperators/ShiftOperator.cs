using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.BitwiseOperators
{
    public class ShiftOperator
    {
        public void LeftAndRightShiftOperators()
        {
            int x = 10;

            Console.WriteLine(x >> 1);
            Console.WriteLine(x >> 2);
            Console.WriteLine(x >> 3);
            Console.WriteLine(x >> 4);

            Console.WriteLine();

            Console.WriteLine(x << 1);
            Console.WriteLine(x << 2);
            Console.WriteLine(x << 3);
            Console.WriteLine(x << 4);

            byte y = 154;
            Console.WriteLine();

            Console.WriteLine(y >> 1);
            Console.WriteLine(y >> 2);
            Console.WriteLine(y >> 3);
            Console.WriteLine(y >> 4);

            Console.WriteLine();

            Console.WriteLine(y << 1);
            Console.WriteLine(y << 2);
            Console.WriteLine(y << 3);
            Console.WriteLine(y << 4);

            Console.ReadLine();
        }
    }
}
