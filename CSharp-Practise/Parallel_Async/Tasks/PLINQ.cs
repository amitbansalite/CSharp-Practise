using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace ConsoleApplication1.Parallel_Async.Tasks
{
    public class Plinq
    {
        public static void Test(string[] args)
        {
            IEnumerable<int> data = new List<int>(100);

            var q = data.Where(x => x % 2 == 0);
            foreach (var i in q)
                DoWork(i);

            // doing the same as above with PLINQ

            q = data.AsParallel().Where(x => x % 2 == 0);
            foreach (var i in q)
                DoWork(i);

            // -------------------------------------------

            const int n = 99999000;
            var sequence = new long[n];
            for (var i = 0; i < n; i++)
                sequence[i] = i;

            // adding numbers using PLINQ
            var sum = (from x in sequence.AsParallel()
                            select x).Sum();
            Console.WriteLine("Sum value is {0}", sum);

            // average of numbers using PLINQ
            var avg = (from x in sequence.AsParallel()
                       select x).Average();
            Console.WriteLine("Average value is {0}", avg);

            // there are many more aggregation tasks available for PLINQ
            Console.ReadLine();
        }

        private static void DoWork(int i) { }

        // the query cannot continue after the exception is thrown. 
        // By the time your application code catches the exception, PLINQ has already stopped the query on all threads.
        private static void Exceptionhandling1()
        {
            // Using the raw string array here. See PLINQ Data Sample. 
            var customers = new string[100];

            // First, we must simulate some currupt input.
            customers[54] = "###";

            var parallelQuery = from cust in customers.AsParallel()
                                let fields = cust.Split(',')
                                where fields[3].StartsWith("C") //throw indexoutofrange 
                                select new { city = fields[3], thread = Thread.CurrentThread.ManagedThreadId };
            try
            {
                // We use ForAll although it doesn't really improve performance 
                // since all output is serialized through the Console.
                parallelQuery.ForAll(e => Console.WriteLine("City: {0}, Thread:{1}", e.city, e.thread));
            }

            // In this design, we stop query processing when the exception occurs. 
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                    if (ex is IndexOutOfRangeException)
                        Console.WriteLine("The data source is corrupt. Query stopped.");
                }
            }
        }

        private static void OrderingInPlinq()
        {
            /*
            var cityQuery = (from city in cities.AsParallel()
                             where city.Population > 10000
                             select city)
                   .Take(1000);

            var orderedCities = (from city in cities.AsParallel().AsOrdered()
                                 where city.Population > 10000
                                 select city)
                               .Take(1000);

            // Next query which uses AsOrdered() for some parts and AsUnordered() for some parts
            
            var orderedCities2 = (from city in cities.AsParallel().AsOrdered()
                                 where city.Population > 10000
                                 select city)
                        .Take(1000);


            var finalResult = from city in orderedCities2.AsUnordered()
                              join p in people.AsParallel() on city.Name equals p.CityName into details
                              from c in details
                              select new { Name = city.Name, Pop = city.Population, Mayor = c.Mayor };

            foreach (var city in finalResult) { /*...#1# }
            
            */
        }

        private static void MergeOptions()
        {
            var nums = Enumerable.Range(1, 10000);

            // Replace NotBuffered with AutoBuffered or FullyBuffered to compare behavior. 
            var scanLines = from n in nums.AsParallel()
                                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);

            var sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
                Console.WriteLine(line);
            
            Console.WriteLine("Elapsed time: {0} ms. Press any key to exit.", sw.ElapsedMilliseconds);
        }

        private static string ExpensiveFunc(int i)
        {
            Thread.SpinWait(2000000);
            return String.Format("{0} *****************************************", i);
        }

        public void FileIteration(string path)
        {
            var sw = Stopwatch.StartNew();
            var count = 0;

            string[] files = null;
            //IEnumerable<string> files = null;
            
            try
            {
                // both the below options behave differently, in the 2nd option results start coming as soon as available

                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                //files = from dir in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                //        select dir;
            }
            catch (UnauthorizedAccessException u)
            {
                Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
                return;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The specified directory {0} was not found.", path);
            }

            var fileContents = from file in files.AsParallel()
                               let ext = Path.GetExtension(file)
                               where ext == ".txt" || ext == ".java"
                               let text = File.ReadAllText(file)
                               select new {name = file, Text = text};

            try
            {
                foreach (var fileContent in fileContents)
                {
                    Console.WriteLine(fileContent.name + " : " + fileContent.Text.Length);
                    count++;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle( (ex) =>
                    {
                        if ( ex is UnauthorizedAccessException)
                        {   
                            Console.WriteLine(ae.Message);
                            return true;
                        }
                        return false;
                    });
            }

            Console.WriteLine("FileIteration_1 processed {0} files in {1} milliseconds", count, sw.ElapsedMilliseconds);
        }
    }
}

