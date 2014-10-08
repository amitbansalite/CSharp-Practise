using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Entities
{
    public class Team
    {
        public string name;
        public int matchCount;
        public IEnumerable<Player> players;
        public int matchWin;
    }
}
