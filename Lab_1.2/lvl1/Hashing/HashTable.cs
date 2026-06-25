namespace lvl1.Hashing
{
    using lvl1.Models;
    using System;

    public class HashTable
    {
        private Triangle[] table;
        private int size;

        public HashTable(int size)
        {
            this.size = size;
            this.table = new Triangle[size];
        }

        private int HashFunction(double key)
        {
            int k = (int)Math.Floor(key);
            k = Math.Abs(k);
            return k % size;
        }

        public bool Insert(Triangle triangle)
        {
            int index = HashFunction(triangle.GetPerimeter());

            if (table[index] == null)
            {
                table[index] = triangle;
                return true;
            }

            return false;
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  Хеш-таблиця  ");
            Console.WriteLine("{0,-5} | {1,-10} | {2}", "Індекс", "Ключ (P)", "Елемент");
            Console.WriteLine(new string('-', 70));
            Console.ResetColor();

            for (int i = 0; i < size; i++)
            {
                if (table[i] != null)
                {
                    Console.WriteLine("[{0:D3}] | {1,-10:F2} | {2}",
                        i, table[i].GetPerimeter(), table[i].ToString());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[{0:D3}] | {1,-10} | Порожньо", i, "-");
                    Console.ResetColor();
                }
            }
        }
    }
}
