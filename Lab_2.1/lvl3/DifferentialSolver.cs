using System;
using System.Collections.Generic;

public class DifferentialSolver
{
    private double F(double x, double y)
    {
        return (1.0 - Math.Exp(-x)) * y;
    }

    public List<(double x, double y)> RungeKutta2ndOrder(double x0, double y0, double xEnd, double h)
    {
        var points = new List<(double x, double y)>();

        double x = x0;
        double y = y0;

        points.Add((x, y));

        while (x < xEnd - h / 2.0)
        {
            double k1 = h * F(x, y);
            double k2 = h * F(x + h, y + k1);

            y = y + 0.5 * (k1 + k2);
            x = x + h;

            points.Add((x, y));
        }

        return points;
    }
}