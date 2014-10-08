using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Indicates that an enumeration can be treated as a bit field; that is, a set of flags.

namespace ConsoleApplication1.Arbit
{
    [FlagsAttribute]
    public enum NewsCategory : int
    {
        None=1,
        TopHeadlines = 1,
        Sports = 2,
        Business = 4,
        Financial = 8,
        World = 16,
        Entertainment = 32,
        Technical = 64,
        Politics = 128,
        Health = 256,
        National = 512
    }

    public class ContentCategory
    {
        public NewsCategory Content
        {
            set
            {
                int[] arr = (int[])System.Enum.GetValues(typeof (NewsCategory));
                int largest = 512;    //GetLargest(arr);
                int smallest = 1; //GetSmallest(arr);

                for (int i = smallest; i < largest; i=2*i)
                {
                    switch ((NewsCategory)(value & (NewsCategory)i))
                    {
                        case NewsCategory.Business:
                            Console.WriteLine("NewsCategory.Business");
                            break;
                        case NewsCategory.Entertainment:
                            Console.WriteLine("NewsCategory.Entertainment");
                            break;
                        case NewsCategory.Financial:
                            Console.WriteLine("NewsCategory.Financial");
                            break;
                        case NewsCategory.Health:
                            Console.WriteLine("NewsCategory.Health");
                            break;
                        case NewsCategory.National:
                            Console.WriteLine("NewsCategory.National");
                            break;
                        case NewsCategory.Politics:
                            Console.WriteLine("NewsCategory.Politics");
                            break;
                        case NewsCategory.Sports:
                            Console.WriteLine("NewsCategory.Sports");
                            break;
                        case NewsCategory.Technical:
                            Console.WriteLine("NewsCategory.Technical");
                            break;
                        case NewsCategory.TopHeadlines:
                            Console.WriteLine("NewsCategory.TopHeadLines");
                            break;
                        case NewsCategory.World:
                            Console.WriteLine("NewsCategory.World");
                            break;
                        default: break;
                    }
                }
            }
        }

        public void Test()
        {
            this.Content = NewsCategory.Business | NewsCategory.Financial | NewsCategory.Entertainment;
        }
        
    }

    public class Test
    {
        public void Testing()
        {
            var obj = new ContentCategory();
            obj.Test();

            Console.ReadLine();
        }
                            
    }
}
