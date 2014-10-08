using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Arbit
{
    public class MethodOverriding
    {
        class Employee
        {
            public virtual void CalculateSalary(int month)
            {
                Console.WriteLine("Employee.CalculateSalary(int)");
            }
        }

        class Manager : Employee
        {
            public override void CalculateSalary(int month)
            {
                Console.WriteLine("Manager.CalculateSalary(int)");
            }

            public void CalculateSalary(object month)
            {
                Console.WriteLine("Manager.CalculateSalary(object)");
            }
        }

        class Overloading
        {
            public static void Test(string[] args)
            {
                Manager mgr = new Manager();
                int month = 10;
                mgr.CalculateSalary(month);
                Console.Read();
            }
        }
    }
}
