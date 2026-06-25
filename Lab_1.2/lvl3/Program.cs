namespace lvl3
{
    using lvl3.Hashing;
    using lvl3.Models;
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть розмір хеш-таблиці: ");
            if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
            {
                Console.WriteLine("Некоректний розмір.");
                return;
            }

            HashTable hashTable = new HashTable(size);
            Random random = new Random();

            Console.Write("Введіть кількість елементів для вставки: ");
            if (!int.TryParse(Console.ReadLine(), out int countToInsert) || countToInsert <= 0)
            {
                Console.WriteLine("Некоректна кількість.");
                return;
            }

            int inserted = 0;
            int attempts = 0;

            while (inserted < countToInsert && attempts < 2000)
            {
                double x1 = random.NextDouble() * 10;
                double y1 = random.NextDouble() * 10;
                double x2 = random.NextDouble() * 10;
                double y2 = random.NextDouble() * 10;
                double x3 = random.NextDouble() * 10;
                double y3 = random.NextDouble() * 10;

                Triangle newTriangle = new Triangle(x1, y1, x2, y2, x3, y3);

                if (newTriangle.GetArea() > 0.1)
                {
                    if (hashTable.Insert(newTriangle))
                    {
                        inserted++;
                    }
                    attempts++;
                }
            }

            Console.WriteLine("\nПочатковий стан хеш-таблиці:");
            hashTable.Display();

            Console.Write("\nВведіть мінімальну площу (поріг для видалення): ");
            if (double.TryParse(Console.ReadLine(), out double threshold))
            {
                int removed = hashTable.RemoveByAreaThreshold(threshold);
                Console.WriteLine($"\nВидалено {removed} трикутників із площею менше ніж {threshold:F2}.");

                Console.WriteLine("\nСтан хеш-таблиці після видалення:");
                hashTable.Display();
            }
            else
            {
                Console.WriteLine("Некоректне значення площі.");
            }
        }
    }
}
