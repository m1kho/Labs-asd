using System;
using System.Text;

namespace lvl1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                int n = 19;
                int k = 2;

                long ways = Combinatorics.Arrangements(n, k);

                Console.WriteLine("Формула: A(19, 2) = 19! / (19 - 2)!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Відповідь: Розподілити види робіт можна {ways} способами.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ПОМИЛКА] {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}