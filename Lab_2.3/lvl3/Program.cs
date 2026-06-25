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
            string filePath = "arrangements.txt";

            try
            {
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    int count = 0;
                    for (int i = 1; i <= 19; i++)
                    {
                        for (int j = 1; j <= 19; j++)
                        {
                            if (i != j)
                            {
                                writer.WriteLine($"Робота 2 -> Студент {i}, Робота 3 -> Студент {j}");
                                count++;
                            }
                        }
                    }
                    Console.WriteLine($"[ФАЙЛ] Згенеровано та записано {count} розміщень у файл: {Path.GetFullPath(filePath)}");
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
