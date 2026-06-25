namespace lvl2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            BinaryTree tree = new BinaryTree();

            tree.Insert(new Student("Коваль", "Олег", 1, 102030, "Львів"));
            tree.Insert(new Student("Петренко", "Ірина", 2, 101040, "Київ"));
            tree.Insert(new Student("Сидоренко", "Андрій", 1, 104050, "Одеса"));
            tree.Insert(new Student("Іваненко", "Марія", 3, 103020, "Харків"));
            tree.Insert(new Student("Ткаченко", "Дмитро", 1, 105010, "Київ"));
            tree.Insert(new Student("Гнатюк", "Степан", 1, 100990, "Львів"));

            Console.WriteLine("=== ВМІСТ ДЕРЕВА (INORDER) ===");
            tree.Inorder();

            string uniCity = "Київ";
            Console.WriteLine($"\n=== ПОШУК: Студенти 1-го курсу, які приїхали не з міста {uniCity} ===");
            List<Student> found = tree.SearchMatchingStudents(uniCity);

            if (found.Count > 0)
            {
                foreach (var s in found)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(s);
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Таких студентів не знайдено.");
                Console.ResetColor();
            }
        }
    }
}
