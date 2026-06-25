namespace lvl3.Hashing
{
    using lvl3.Models;
    using System;
    using System.Collections.Generic;

    public class HashTable
    {
        private LinkedList<Triangle>[] table;
        private int size;

        public HashTable(int size)
        {
            this.size = size;
            this.table = new LinkedList<Triangle>[size];
            for (int i = 0; i < size; i++)
            {
                table[i] = new LinkedList<Triangle>();
            }
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
            foreach (var item in table[index])
            {
                if (Math.Abs(item.GetPerimeter() - triangle.GetPerimeter()) < 0.001)
                {
                    return false;
                }
            }
            table[index].AddLast(triangle);
            return true;
        }

        public int RemoveByAreaThreshold(double threshold)
        {
            int removedCount = 0;
            for (int i = 0; i < size; i++)
            {
                var node = table[i].First;
                while (node != null)
                {
                    var nextNode = node.Next;
                    if (node.Value.GetArea() < threshold)
                    {
                        table[i].Remove(node);
                        removedCount++;
                    }
                    node = nextNode;
                }
            }
            return removedCount;
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  Хеш-таблиця  ");
            Console.WriteLine("{0,-5} | {1}", "Індекс", "Елементи (ланцюжок)");
            Console.WriteLine(new string('-', 70));
            Console.ResetColor();

            for (int i = 0; i < size; i++)
            {
                Console.Write("[{0:D3}] | ", i);
                if (table[i].Count > 0)
                {
                    foreach (var item in table[i])
                    {
                        Console.Write($"({item.GetPerimeter():F2}, S:{item.GetArea():F2}) -> ");
                    }
                    Console.WriteLine("null");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Порожньо");
                    Console.ResetColor();
                }
            }
        }
    }
}
