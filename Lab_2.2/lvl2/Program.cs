using System;
using System.Text;

namespace lvl2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("--- СИНТАКСИЧНИЙ АНАЛІЗАТОР (Рівень 2, Варіант 1) ---");
            Console.WriteLine("Паттерн: %[A-Z]+%\n");

            Console.Write("Введіть текстовий образ для перевірки: ");
            string input = Console.ReadLine() ?? "";

            var analyzer = new SyntaxAnalyzer();
            bool isValid = analyzer.Analyze(input);

            if (isValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[УСПІХ] Введений рядок ВІДПОВІДАЄ правилам автомата.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ПОМИЛКА] Введений рядок НЕ ВІДПОВІДАЄ правилам автомата.");
            }
            Console.ResetColor();
        }
    }
}