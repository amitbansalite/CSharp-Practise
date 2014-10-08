using System.Collections.Generic;

namespace ConsoleApplication1.DataStructures
{
    public class PractiseLinkedList
    {
        public PractiseLinkedList()
        {
            // create a linkedList of standard data types
            var x = new LinkedList<int>();

            x.AddLast(10);
            x.AddLast(20);
            x.AddLast(30);

            var y = new LinkedList<string>();
            y.AddLast("Amit");
            y.AddLast("hello");
            
            var node = new LinkedListNode<string>("Amit");
            y.AddLast(node);

            // create a linkedList of custom object
            var customList = new LinkedList<MyListNode>();

            var nodeObj = new MyListNode("amit", "agarwal");
            customList.AddLast(nodeObj);
            
        }

        public class MyListNode
        {
            public string first;
            public string last;

            public MyListNode(string first, string last)
            {
                this.first = first;
                this.last = last;
            }
        }
    }
}
