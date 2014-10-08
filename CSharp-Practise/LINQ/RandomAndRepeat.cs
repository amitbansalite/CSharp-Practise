using System.Linq;
using System.Numerics;

namespace ConsoleApplication1.LINQ
{
    public class RandomAndRepeat
    {
        public void Range_examples()
        {
            // 1. generate a 100 random values
            var ran = new System.Random();
            var results = Enumerable.Range(1, 100).Select(i => ran.Next()).ToList();


            // 2. generate even numbers from 1 to 100
            var thisResult = Enumerable.Range(1, 100).Select(i => i*2).ToList();

            // 3. generate factorial
            var result = new BigInteger(1);
            Enumerable.Range(1,10).ToList().ForEach(x => result = x * result);

        }

        public void Repeat_examples()
        {
            // 1. repeat the given element for the specified count
            var repeatedValues = Enumerable.Repeat("Hello World!", 5).ToArray();



            // 2. WHAT it does not Do

            // does this generate 100 random numers? Or repeat first random number 100 times?
            var ran = new System.Random(100);
            var repeatedRandom = Enumerable.Repeat(ran.Next(), 100);        // call Next() once, and repeat the same value 100 times
        }

    }
}
