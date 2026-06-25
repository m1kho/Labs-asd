namespace lvl1
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Stack stack = new Stack(10);

            Console.WriteLine("Додавання елементів у стек: 5, -12, 8, 3, -7");
            stack.Push("5");
            stack.Push("-12");
            stack.Push("8");
            stack.Push("3");
            stack.Push("-7");

            Console.Write("Вміст стеку: ");
            stack.Display();

            Console.WriteLine("\nВидалення двох елементів зі стеку...");
            Console.WriteLine("Видалено: " + stack.Pop());
            Console.WriteLine("Видалено: " + stack.Pop());

            Console.Write("Вміст стеку після видалення: ");
            stack.Display();
        }
    }
}
