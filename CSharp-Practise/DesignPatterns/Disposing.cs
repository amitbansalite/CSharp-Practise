using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You don’t have to explicitly call Dispose on the FileStream object because the
// StreamWriter calls it for you. However, if you do call Dispose explicitly, the FileStream will
// see that the object has already been cleaned up—the method does nothing and just returns.

namespace ConsoleApplication1.DesignPatterns
{
    public class Disposing
    {
        public void Test()
        {
            var file = new FileStream("temp.txt", FileMode.Create);

            var stream = new StreamWriter(file);

        }
    }
}
