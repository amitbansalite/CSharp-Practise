using System;

namespace ConsoleApplication1.DataStructures
{
    public class MergeLinkList
    {
        public class Node
        {
            public int val;
            public Node next;
        }

        private Node AddNode(Node head, int val)
        {
            var newNode = new Node();
            newNode.val = val;
            newNode.next = null;

            if (head == null)
            {
                head = newNode;
                return head;
            }

            Node tmp = head;
            while (tmp.next != null)
                tmp = tmp.next;

            tmp.next = newNode;

            return head;
        }

        public void CreateAndMerge2Lists()
        {
            Node head1 = null;
            head1 = AddNode(head1, 2);
            head1 = AddNode(head1, 4);
            head1 = AddNode(head1, 6);
            head1 = AddNode(head1, 18);

            Node head2 = null;
            head2 = AddNode(head2, 1);
            head2 = AddNode(head2, 5);
            head2 = AddNode(head2, 13);

            var result = MergeLists(head1, head2);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }

            Console.ReadLine();
        }

        private Node MergeLists(Node head1, Node head2)
        {
            Node resultHead = null;

            while (head1 != null && head2 != null)
            {
                if (head1.val <= head2.val)
                {
                    resultHead = AddNode(resultHead, head1.val);
                    head1 = head1.next;
                }
                else if (head1.val > head2.val)
                {
                    resultHead = AddNode(resultHead, head2.val);
                    head2 = head2.next;
                }
            }

            while (head1 != null)
            {
                resultHead = AddNode(resultHead, head1.val);
                head1 = head1.next;
            }

            while (head2 != null)
            {
                resultHead = AddNode(resultHead, head2.val);
                head2 = head2.next;
            }

            return resultHead;
        }
    }
}
