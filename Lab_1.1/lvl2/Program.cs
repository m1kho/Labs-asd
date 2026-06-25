namespace lvl2
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            DoublyLinkedList list = new DoublyLinkedList();

            Console.WriteLine("Додавання елементів у список: 15, -4, 22, 7, 10");
            list.Add(15);
            list.Add(-4);
            list.Add(22);
            list.Add(7);
            list.Add(10);

            Console.Write("Вміст списку: ");
            list.Display();

            Console.WriteLine("\nВидалення елементів за індексами 1 та 3...");
            list.RemoveByIndex(1);
            list.RemoveByIndex(2);

            Console.Write("Вміст списку після видалення: ");
            list.Display();
        }
    }
}
