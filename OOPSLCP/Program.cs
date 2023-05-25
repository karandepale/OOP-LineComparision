using System;

namespace OOPSLCP
{
    internal class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }
    }

    internal class Line
    {
        private Point point1;
        private Point point2;

        public Line(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public double CalculateLength()
        {
            int xDiff = point2.X - point1.X;
            int yDiff = point2.Y - point1.Y;
            double length = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
            return length;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Line Comparison Program using Object-oriented programming...");

            Point point1 = new Point(3, 4);
            Point point2 = new Point(6, 8);

            Line line = new Line(point1, point2);
            double length = line.CalculateLength();

            Console.WriteLine($"Length of the line: {length}");
        }
    }
}
