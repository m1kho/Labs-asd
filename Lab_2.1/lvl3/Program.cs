using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        DifferentialSolver solver = new DifferentialSolver();

        Console.WriteLine("Диференціальне рівняння: dy/dx = (1 - e^-x) * y");
        Console.WriteLine("Метод: Рунге-Кутта 2-го порядку\n");

        try
        {
            Console.Write("Введіть початкове значення x0: ");
            double x0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть початкове значення y0 (y(x0)): ");
            double y0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть кінцеве значення аргументу x_end: ");
            double xEnd = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть крок інтегрування h: ");
            double h = Convert.ToDouble(Console.ReadLine());

            if (xEnd <= x0 || h <= 0)
            {
                Console.WriteLine("\nПомилка: Кінцеве значення X повинно бути більшим за початкове, а крок h > 0.");
                return;
            }

            List<(double x, double y)> results = solver.RungeKutta2ndOrder(x0, y0, xEnd, h);

            Console.WriteLine("\nРезультати обчислення:");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"| {"Аргумент x",-10} | {"Функція y",-13} |");
            Console.WriteLine(new string('-', 30));

            foreach (var point in results)
            {
                Console.WriteLine($"| {point.x,10:F5} | {point.y,13:F5} |");
            }
            Console.WriteLine(new string('-', 30));
        }
        catch (FormatException)
        {
            Console.WriteLine("\nПомилка введення! Будь ласка, використовуйте числа.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nПомилка: {ex.Message}");
        }
    }
}