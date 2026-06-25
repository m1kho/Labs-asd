namespace lvl1
{
    using System;
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

            Console.WriteLine("=== СИМЕТРИЧНИЙ ОБХІД (INORDER) ===");
            tree.Inorder();

            Console.WriteLine("=== ПРЯМИЙ ОБХІД (PREORDER) ===");
            tree.Preorder();

            Console.WriteLine("=== ЗВОРОТНИЙ ОБХІД (POSTORDER) ===");
            tree.Postorder();
        }
    }
}
