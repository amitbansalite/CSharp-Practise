using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Arbit
{
    public class MissingAPNumber
    {
        public void getMissingNumber()
        {
            int n = Convert.ToInt32(Console.In.ReadLine());

            string foo = Console.In.ReadLine();
            string[] tokens = foo.Split(' ');

            List<int> nums = new List<int>();

            for (int i = 0; i < n; i++)
            {
                nums.Add(Convert.ToInt32(tokens[i]));
            }

            int diff1, diff2, missingNum = 0;

            for (int i = n - 1; i >= 2; i++)
            {
                diff1 = nums[i] - nums[i - 1];
                diff2 = nums[i - 1] - nums[i - 2];

                if (diff1 > diff2)
                    missingNum = nums[i - 1] + diff2;
                else if (diff1 < diff2)
                    missingNum = nums[i - 1] - diff2;
            }
            Console.Out.WriteLine(missingNum); 
        }
    }
}
