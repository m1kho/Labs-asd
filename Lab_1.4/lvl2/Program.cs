using lvl2.Models;
using lvl2.Services;
using System;
using System.Text;

namespace lvl2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var list = new SinglyLinkedList();
            list.Append(new Student("Іваненко", "Олег", "ІТ-21", 123456));
            list.Append(new Student("Петренко", "Анна", "АС-11", 543210));
            list.Append(new Student("Сидоренко", "Ігор", "ІТ-21", 234567));
            list.Append(new Student("Коваль", "Марія", "ББ-05", 102938));
            list.Append(new Student("Ткаченко", "Максим", "АС-11", 987654));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--->>> Список до сортування <<<---");
            Console.ResetColor();
            PrintList(list);

            list.InsertionSort();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--->>> Список після сортування (Вставками за групою) <<<---");
            Console.ResetColor();
            PrintList(list);
        }

        static void PrintList(SinglyLinkedList list)
        {
            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"| {"Група",-8} | {"Квиток",-12} | {"Прізвище та ім'я",-24} |");
            Console.WriteLine(new string('-', 55));
            var current = list.Head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
            Console.WriteLine(new string('-', 55));
        }
    }
}