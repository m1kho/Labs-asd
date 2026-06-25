using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        EquationSolver solver = new EquationSolver();

        double a = 1.0;
        double b = 2.0;
        double epsilon = 0.0001;

        Console.WriteLine("Рівняння: ln(x) + 2x^2 - 6 = 0");
        Console.WriteLine($"Інтервал пошуку: [{a}, {b}], Точність = {epsilon}");
        Console.WriteLine(new string('-', 50));

        try
        {
            double rootBisection = solver.BisectionMethod(a, b, epsilon);
            double rootSecant = solver.SecantMethod(a, b, epsilon);
            double rootNewton = solver.NewtonMethod(b, epsilon);

            Console.WriteLine($"Метод половинного ділення: x = {rootBisection:F6}");
            Console.WriteLine($"Метод хорд:                x = {rootSecant:F6}");
            Console.WriteLine($"Метод дотичних (Ньютона):  x = {rootNewton:F6}");

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Перевірка (підстановка кореня в f(x)): {solver.F(rootNewton):F6}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}