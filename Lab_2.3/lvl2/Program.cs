using System;
using System.Text;

namespace lvl2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                int firstPosChoices = 6;
                int otherPosChoices = 11;
                int length = 10;

                double total = firstPosChoices * CombinatoricsMath.Power(otherPosChoices, length - 1);

                Console.WriteLine("Формула: 6 * 11^9");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Відповідь: Можна сформувати {total:F0} паролів.");
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