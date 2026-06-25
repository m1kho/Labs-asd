using lvl2.BST;
using lvl2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            BinarySearchTree tree = new BinarySearchTree();

            var studentsData = new List<Student>
            {
                new Student("Бойко", "Олег", "Сидорович", 105, false),
                new Student("Абрамов", "Іван", "Петрович", 101, true),
                new Student("Гнатюк", "Марія", "Олегівна", 115, true),
                new Student("Коваль", "Анна", "Вікторівна", 145, true),
                new Student("Данилюк", "Артем", "Сергійович", 120, false),
                new Student("Новак", "Олена", "Петрівна", 160, true),
                new Student("Мороз", "Степан", "Іванович", 155, true),
                new Student("Ткач", "Вадим", "Олександрович", 185, true),
                new Student("Усенко", "Богдан", "Дмитрович", 190, true),
                new Student("Савченко", "Кирило", "Ярославович", 180, false)
            };

            Console.WriteLine("=== СПИСОК СТУДЕНТІВ ДЛЯ ДОДАВАННЯ ===");
            foreach (var s in studentsData)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n=== ДОДАВАННЯ З РОТАЦІЄЮ В КОРІНЬ ===");
            foreach (var s in studentsData)
            {
                tree.Insert(s);
                Console.WriteLine($"Додано: {s.LastName} {s.FirstName} (Заліковка: {s.RecordBookNumber}). Новий корінь: {tree.Root?.Data.LastName} {tree.Root?.Data.FirstName}");
            }

            Console.Write("\nВведіть номер залікової книжки для пошуку: ");
            if (int.TryParse(Console.ReadLine(), out int searchKey))
            {
                Node? result = tree.Search(searchKey);

                if (result != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nВУЗОЛ ЗНАЙДЕНО:");
                    Console.WriteLine(result.Data);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nСтудента з такою заліковою книжкою не знайдено.");
                    Console.ResetColor();
                }
            }
        }
    }
}