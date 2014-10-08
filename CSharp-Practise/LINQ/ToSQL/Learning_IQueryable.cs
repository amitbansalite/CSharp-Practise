using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApplication1.LINQ.ToSQL
{
    public class Learning_IQueryable
    {
        public void Expressions()
        {
            Func<int, int, int> multiply = (x, y) => x*y;
            // delegates are invokable, pass parameters and call them and they will execute
            Console.WriteLine(multiply(2, 3));

            // expressions cannot be invoked as methods as they represent code as data
            Expression<Func<int, int, int>> multiplyExpression = (x, y) => x*y;

            // they can be invoked by compiling
            Func<int, int, int> mult = multiplyExpression.Compile();
            Console.WriteLine(mult(2,3));

            // but the REAL power is to be able to treat code as DATA and look at it through runtime analysis
        }

        public void GetDataFromSQLTables()
        {
            //var context = new ReadmissionsDataContext();

            //var predictions = from p in context.Predictions
            //                  where p.Value > 0.5
            //                  orderby p.Value
            //                  select p;

            //foreach (var prediction in predictions)
            //{
            //    Console.WriteLine(prediction.PatientLocationKey + ':' + prediction.Value);
            //}
        }

    }

    public class Test_IQueryable
    {
        public void Test()
        {
            new Learning_IQueryable().Expressions();

            Console.ReadLine();
        }
    }
}
