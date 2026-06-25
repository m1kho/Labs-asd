using System;

public class NumericalIntegration
{
    private double F(double x)
    {
        return 4.0 / (1.0 + x * x);
    }

    public double RectangleMethodL(double a, double b, double step)
    {
        double sum = 0.0;
        int n = (int)Math.Round((b - a) / step);
        for (int i = 0; i < n; i++)
        {
            sum += F(a + i * step);
        }
        return sum * step;
    }

    public double RectangleMethodR(double a, double b, double step)
    {
        double sum = 0.0;
        int n = (int)Math.Round((b - a) / step);
        for (int i = 1; i <= n; i++)
        {
            sum += F(a + i * step);
        }
        return sum * step;
    }

    public double RectangleMethodM(double a, double b, double step)
    {
        double sum = 0.0;
        int n = (int)Math.Round((b - a) / step);
        double halfStep = step / 2.0;
        for (int i = 0; i < n; i++)
        {
            sum += F(a + i * step + halfStep);
        }
        return sum * step;
    }

    public double TrapezoidMethod(double a, double b, double step)
    {
        double sum = (F(b) + F(a)) / 2.0;
        int n = (int)Math.Round((b - a) / step);
        for (int i = 1; i < n; i++)
        {
            sum += F(a + step * i);
        }
        return sum * step;
    }

    public double SimpsonsMethod(double a, double b, double step)
    {
        int n = (int)Math.Round((b - a) / step);
        int nEven = (n % 2 == 0) ? n : n - 1;
        double sum = F(a) + F(a + nEven * step);
        double subSum1 = 0;
        for (int i = 1; i < nEven; i += 2)
        {
            subSum1 += F(a + step * i);
        }
        sum += subSum1 * 4.0;

        double subSum2 = 0;
        for (int i = 2; i < nEven - 1; i += 2)
        {
            subSum2 += F(a + step * i);
        }
        sum += subSum2 * 2.0;

        double result = sum * step / 3.0;

        if (n % 2 != 0)
        {
            double xLast = a + nEven * step;
            result += step * (F(xLast) + F(b)) / 2.0;
        }

        return result;
    }
}