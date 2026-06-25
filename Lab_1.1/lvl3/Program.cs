namespace lvl3
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Stack stack = new Stack(10);
            stack.Push("12");
            stack.Push("5");
            stack.Push("8");
            stack.Push("3");
            stack.Push("14");
            stack.Push("7");
            stack.Push("2");

            Console.Write("Початковий вміст стеку: ");
            stack.Display();

            DoublyLinkedList list = new DoublyLinkedList();

            while (!stack.IsEmpty())
            {
                string poppedStr = stack.Pop();
                if (int.TryParse(poppedStr, out int val))
                {
                    if (val % 2 == 0)
                    {
                        list.AddFirst(val);
                    }
                    else
                    {
                        list.AddLast(val);
                    }
                }
            }

            Console.WriteLine("\nЕлементи переміщено зі стеку до двоспрямованого списку.");
            Console.Write("Вміст стеку після переміщення: ");
            stack.Display();

            Console.Write("Вміст двоспрямованого списку (парні на початку, непарні в кінці): ");
            list.Display();
        }
    }
}
