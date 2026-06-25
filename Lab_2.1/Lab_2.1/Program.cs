using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        NumericalIntegration calculator = new NumericalIntegration();

        double a = 1.0;
        double b = 3.0;
        double step = 0.2;

        double analytical = 4.0 * Math.Atan(3.0) - Math.PI;

        Console.WriteLine($"Інтервал: [{a}, {b}], крок = {step}");
        Console.WriteLine(new string('-', 55));

        Console.WriteLine($"Метод лівих прямокутників:      {calculator.RectangleMethodL(a, b, step):F6}");
        Console.WriteLine($"Метод правих прямокутників:     {calculator.RectangleMethodR(a, b, step):F6}");
        Console.WriteLine($"Метод серединних прямокутників: {calculator.RectangleMethodM(a, b, step):F6}");
        Console.WriteLine($"Метод трапецій:                 {calculator.TrapezoidMethod(a, b, step):F6}");
        Console.WriteLine($"Метод Сімпсона:                 {calculator.SimpsonsMethod(a, b, step):F6}");
        Console.WriteLine($"Точне аналітичне значення:      {analytical:F6}");
    }
}