using System;


// when creating a generic class one can specify constraints 


namespace ConsoleApplication1.Generics
{
    public class GenericList<T>
        where T : IComparable<T>
    {
        public class Node<T>
        {
            public T Item;
            public Node<T> Next;
        }

        public Node<T> AddNode(T value, Node<T> head)
        {
            var newNode = new Node<T>();
            newNode.Item = value;
            newNode.Next = null;

            if (head == null)
            {
                head = newNode;
                return head;
            }

            var temp = head;
            while (temp.Next != null)
                temp = temp.Next;

            temp.Next = newNode;

            return head;
        }

        public Node<T> MergeLists(Node<T> head1, Node<T> head2)
        {
            Node<T> newHeadNode = null;

            while (head1 !=null && head2 !=null)
            {
                if (head1.Item.CompareTo(head2.Item) < 0)
                {
                    newHeadNode = AddNode(head1.Item, newHeadNode);
                    head1 = head1.Next;
                }
                else if (head1.Item.CompareTo(head2.Item) > 0)
                {
                    newHeadNode = AddNode(head2.Item, newHeadNode);
                    head2 = head2.Next;
                }
            }

            while (head1 != null)
            {
                newHeadNode = AddNode(head1.Item, newHeadNode);
                head1 = head1.Next;
            }

            while (head2 != null)
            {
                newHeadNode = AddNode(head2.Item, newHeadNode);
                head2 = head2.Next;
            }

            return newHeadNode;
        }

        public void Display(Node<T> head)
        {
            var tmp = head;

            while (tmp != null)
            {
                Console.WriteLine(tmp.Item);
                tmp = tmp.Next;
            }
        }
    }

    public class Test_GenericLinkedList
    {
        public Test_GenericLinkedList()
        {
            var list1 = new GenericList<int>();

            var head1 = list1.AddNode(10, null);
            head1 = list1.AddNode(20, head1);
            head1 = list1.AddNode(30, head1);
            head1 = list1.AddNode(40, head1);

            list1.Display(head1);

            var list2 = new GenericList<int>();

            var head2 = list2.AddNode(5, null);
            head2 = list2.AddNode(25, head2);
            head2 = list2.AddNode(28, head2);

            list2.Display(head2);

            var mergeHead = list1.MergeLists(head1, head2);

            while (mergeHead != null)
            {
                Console.WriteLine(mergeHead.Item);
                mergeHead = mergeHead.Next;
            }

            Console.ReadLine();
        }
    }
}
