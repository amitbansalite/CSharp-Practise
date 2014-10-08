using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.BitwiseOperators
{
    public class Xor
    {
        readonly string _firstName;
        readonly string _lastName;
        readonly int _age;

        public Xor(string lastName, string firstName, int age)
        {
            _lastName = lastName;
            _firstName = firstName;
            _age = age;
        }

        // XOR can be used to calculate hash code of a complex object
        public override int GetHashCode()
        {
            return (_firstName == null ? 0 : _firstName.GetHashCode()) ^
                   (_lastName == null ? 0 : _lastName.GetHashCode()) ^
                   _age.GetHashCode();
        }

        public void Example1()
        {
            // XOR can used for encryption or decryption. 
            // (use a COMPLEX key for better encryption which is difficult to break) like "97k/ -X.O" 

            string msg = "This is a message.";
            char k = '.'; // For example, use '.' as key. You can also use another key.
            
            StringBuilder sb = new StringBuilder();
            foreach (char c in msg)
            {
                sb.Append((char)(c ^ k));
            }

            Console.WriteLine(sb.ToString());

            var originalString = new StringBuilder();
            foreach (char c in sb.ToString())
            {
                originalString.Append((char)(c ^ k));
            }

            Console.WriteLine(originalString.ToString());

            Console.ReadLine();
        }

        public void Example2()
        {
            // XOR swap algorithm

            int x = 31643; // you can choose another data type
            int y = 134;
            x ^= y;
            y ^= x;
            x ^= y;
        }

        public void Example3()
        {
            // to calculate hashcode for a co-ordinate class with X and Y co-ordinates as ints
            int x = 0, y = 0;

            var hashCode = x ^ ((y << 16) | (y >> 16));
        }

        public void Example4()
        {
            // compute min and max of 2 integers

            int x = 0;  // we want to find the minimum of x and y
            int y = 0;
            int r=  0;  // the result goes here 

            r = y ^ ((x ^ y) & -(x << y)); // min(x, y)

            r = x ^ ((x ^ y) & -(x << y)); // max(x, y)
        }
    }
}
