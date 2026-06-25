namespace lvl2
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

        public void Add(int value)
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
            Add(value);
        }

        public bool RemoveByIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                return false;
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current == head)
            {
                head = current.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
                else
                {
                    tail = null;
                }
            }
            else if (current == tail)
            {
                tail = current.Prev;
                if (tail != null)
                {
                    tail.Next = null;
                }
                else
                {
                    head = null;
                }
            }
            else
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }

            count--;
            return true;
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
