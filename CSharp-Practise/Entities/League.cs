using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Entities
{
    public class League
    {
        public string name;
        public int year;
        public IEnumerable<Team> teams;
    }
}
