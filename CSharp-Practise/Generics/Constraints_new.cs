using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Generics
{
    public class Constraints_new<T>
        where T : new()
    {

    }

    public class Employee
    {
        public string name { get; set; }

        public Employee(string name)
        {
            this.name = name;
        }

        public Employee(){}
    }

    public class ContractEmployee
    {
        public string name { get; set; }

        public ContractEmployee(){}

        public ContractEmployee(string name)
        {
            this.name = name;
        }
    }

    public class Empl
    {
        static Empl(){}
    }

    public class Empl1
    {
        private Empl1(){}
    }

    public class Test_Constraints_new
    {
        public Test_Constraints_new()
        {

            var obj = new Constraints_new<Employee>();

            var obj2 = new Constraints_new<ContractEmployee>();

            var obj3 = new Constraints_new<Empl>();

            // syntax error as the below class does not have a default constructor
            //var obj4 = new Constraints_new<Empl1>();
        }
    }
}
