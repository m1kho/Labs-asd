namespace lvl1
{
    using System;

    public class Stack
    {
        private string[] items;
        private int top;
        private int capacity;

        public Stack(int capacity)
        {
            this.capacity = capacity;
            items = new string[capacity];
            top = -1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == capacity - 1;
        }

        public void Push(string item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Стек переповнений");
            }
            items[++top] = item;
        }

        public string Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек порожній");
            }
            return items[top--];
        }

        public string Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек порожній");
            }
            return items[top];
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек порожній.");
                return;
            }
            for (int i = top; i >= 0; i--)
            {
                Console.Write(items[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
