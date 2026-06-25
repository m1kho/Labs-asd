using System;
using System.IO;
using System.Text;

namespace lvl3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string filePath = "words_delimited.txt";
            string fileContent = "%HELLO%:INVALID% %A%:WORD:%%:%TEST%";

            try
            {
                File.WriteAllText(filePath, fileContent);
                Console.WriteLine($"[ФАЙЛ] Створено файл з роздільниками: {Path.GetFullPath(filePath)}");
                Console.WriteLine($"Вміст файлу: {fileContent}");
                Console.WriteLine(new string('-', 60));

                string readContent = File.ReadAllText(filePath);
                char[] delimiters = { ' ', ':' };
                string[] tokens = readContent.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                var analyzer = new SyntaxAnalyzer();

                Console.WriteLine("{0,-20} | {1,-25}", "Слово", "Результат валідації");
                Console.WriteLine(new string('-', 60));

                foreach (var token in tokens)
                {
                    bool isValid = analyzer.Analyze(token);
                    if (isValid)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0,-20} | {1,-25}", token, "ПРАВИЛЬНО");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-20} | {1,-25}", token, "НЕПРАВИЛЬНО");
                    }
                    Console.ResetColor();
                }
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
