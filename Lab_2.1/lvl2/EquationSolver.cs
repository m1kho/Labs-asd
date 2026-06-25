using System;

public class EquationSolver
{
    public double F(double x)
    {
        return Math.Log(x) + 2.0 * x * x - 6.0;
    }

    public double DF(double x)
    {
        return 1.0 / x + 4.0 * x;
    }

    public double BisectionMethod(double a, double b, double epsilon)
    {
        if (F(a) * F(b) >= 0)
        {
            throw new ArgumentException("Функція повинна мати різні знаки на кінцях інтервалу.");
        }

        double c = a;
        while ((b - a) / 2.0 > epsilon)
        {
            c = (a + b) / 2.0;

            if (F(c) == 0.0)
            {
                break;
            }
            else if (F(c) * F(a) < 0)
            {
                b = c;
            }
            else
            {
                a = c;
            }
        }
        return (a + b) / 2.0;
    }

    public double SecantMethod(double a, double b, double epsilon)
    {
        double xPrev = a;
        double xCurr = b;
        double xNext;

        do
        {
            xNext = xCurr - F(xCurr) * (xCurr - xPrev) / (F(xCurr) - F(xPrev));
            xPrev = xCurr;
            xCurr = xNext;

        } while (Math.Abs(F(xCurr)) > epsilon);

        return xCurr;
    }

    public double NewtonMethod(double initialGuess, double epsilon)
    {
        double xCurr = initialGuess;
        double xNext;

        do
        {
            xNext = xCurr - F(xCurr) / DF(xCurr);

            if (Math.Abs(xNext - xCurr) < epsilon)
            {
                break;
            }

            xCurr = xNext;

        } while (true);

        return xNext;
    }
}