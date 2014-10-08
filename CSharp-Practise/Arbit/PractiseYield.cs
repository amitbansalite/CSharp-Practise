using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Arbit
{
    public class PractiseYield
    {
        public void Test()
        {
            foreach (var name in GetNextForEach())
            {
                Console.WriteLine(name);
            }
            
        }

        private IEnumerable<string> GetNextFor()
        {
            var names = new List<string> { "tom", "harry", "shrader", "walter" };

            for (var i = 0; i < names.Count; i++)
            {
                if (names[i].Length > 4)
                {
                    Console.WriteLine("I am here");
                    yield return names[i];
                }
            }
        }

        private IEnumerable<string> GetNextForEach()
        {
            var names = new List<string> { "tom", "harry", "shrader", "walter" };
            
            foreach (var name in names)
            {
                if (name.Length > 4)
                {
                    Console.WriteLine("I am here");
                    yield return name;
                }
            }
        }

        private IEnumerable<string> GetNextLinq()
        {
            var names = new List<string> { "tom", "harry", "shrader", "walter" };

            foreach ( var name in names.Where( x => x.Length > 4))
            {
                Console.WriteLine("I am here");
                yield return name;
            }
        }
    }
}
