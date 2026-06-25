using lvl3.Models;
using lvl3.Services;
using System;
using System.Text;

namespace lvl3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Student[] students = {
                new Student("Іваненко", "Олег", "ІТ-21", 123456),
                new Student("Петренко", "Анна", "АС-11", 543210),
                new Student("Сидоренко", "Ігор", "ІТ-21", 234567),
                new Student("Коваль", "Марія", "ББ-05", 102938),
                new Student("Ткаченко", "Максим", "АС-11", 987654)
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--->>> Масив до сортування <<<---");
            Console.ResetColor();
            PrintTable(students);

            MergeSorter.Sort(students);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--->>> Масив після сортування (Злиттям top-down за зростанням квитка) <<<---");
            Console.ResetColor();
            PrintTable(students);
        }

        static void PrintTable(Student[] students)
        {
            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"| {"Група",-8} | {"Квиток",-12} | {"Прізвище та ім'я",-24} |");
            Console.WriteLine(new string('-', 55));
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(new string('-', 55));
        }
    }
}