namespace lvl2.Models
{
    using System;

    public class Triangle
    {
        public double X1 { get; }
        public double Y1 { get; }
        public double X2 { get; }
        public double Y2 { get; }
        public double X3 { get; }
        public double Y3 { get; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetPerimeter()
        {
            double a = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double b = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double c = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
            return a + b + c;
        }

        public double GetArea()
        {
            double a = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            double b = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double c = Math.Sqrt(Math.Pow(X1 - X3, 2) + Math.Pow(Y1 - Y3, 2));
            double s = (a + b + c) / 2.0;
            return Math.Sqrt(Math.Max(0, s * (s - a) * (s - b) * (s - c)));
        }

        public override string ToString()
        {
            return $"Трикутник [Вершини: ({X1:F1};{Y1:F1}), ({X2:F1};{Y2:F1}), ({X3:F1};{Y3:F1}), Площа: {GetArea():F2}, Периметр: {GetPerimeter():F2}]";
        }
    }
}
