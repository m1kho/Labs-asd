using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lvl1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string filePath = "words_variant1.txt";

            var initialWords = new List<string>
            {
                "%HELLO%",
                "%A%",
                "%TEST%",
                "HELLO%",
                "%HELLO",
                "%Hello%",
                "%123%",
                "%%",
                "%A B%"
            };

            try
            {
                FileHandler.CreateFileWithWords(filePath, initialWords);

                string pattern = @"^%[A-Z]+%$";
                var matcher = new RegexMatcher(pattern);

                var wordsFromFile = FileHandler.ReadWordsFromFile(filePath);
                var matchedWords = matcher.FindMatchingWords(wordsFromFile).ToList();

                Console.WriteLine("\n--- РЕЗУЛЬТАТИ ПОШУКУ (Рівень 1, Варіант 1) ---");
                Console.WriteLine($"Регулярний вираз: {pattern}");
                Console.WriteLine($"Знайдено відповідних слів: {matchedWords.Count}\n");

                foreach (var word in matchedWords)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[ЗНАЙДЕНО] {word}");
                }
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