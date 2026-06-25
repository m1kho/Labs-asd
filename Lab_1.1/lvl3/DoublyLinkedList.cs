namespace lvl3
{
    using System;

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;
        private int count;

        public int Count => count;

        public bool IsEmpty()
        {
            return head == null;
        }

        public void AddFirst(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            count++;
        }

        public void AddLast(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            count++;
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}
