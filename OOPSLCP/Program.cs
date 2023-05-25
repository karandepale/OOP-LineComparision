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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Point otherPoint = (Point)obj;
            return (x == otherPoint.x) && (y == otherPoint.y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x.GetHashCode(), y.GetHashCode());
        }
    }

    internal class Line : IComparable<Line>
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

        public int CompareTo(Line otherLine)
        {
            double length1 = CalculateLength();
            double length2 = otherLine.CalculateLength();

            if (length1 < length2)
                return -1;
            else if (length1 > length2)
                return 1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Line otherLine = (Line)obj;
            return (point1.Equals(otherLine.point1) && point2.Equals(otherLine.point2)) ||
                   (point1.Equals(otherLine.point2) && point2.Equals(otherLine.point1));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(point1.GetHashCode(), point2.GetHashCode());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Line Comparison Program using Object-oriented programming...");

            Point point1 = new Point(3, 4);
            Point point2 = new Point(6, 8);

            Line line1 = new Line(point1, point2);
            Line line2 = new Line(new Point(3, 4), new Point(6, 8));
            Line line3 = new Line(new Point(1, 2), new Point(6, 8));

            double length1 = line1.CalculateLength();
            Console.WriteLine($"Length of line1: {length1}");

            double length2 = line2.CalculateLength();
            Console.WriteLine($"Length of line2: {length2}");

            double length3 = line3.CalculateLength();
            Console.WriteLine($"Length of line3: {length3}");

            bool isEqual1 = line1.Equals(line2);
            Console.WriteLine($"line1 and line2 are equal: {isEqual1}");

            bool isEqual2 = line1.Equals(line3);
            Console.WriteLine($"line1 and line3 are equal: {isEqual2}");

            int comparison1 = line1.CompareTo(line2);
            Console.WriteLine($"Comparison of line1 and line2: {comparison1}");

            int comparison2 = line1.CompareTo(line3);
            Console.WriteLine($"Comparison of line1 and line3: {comparison2}");
        }
    }
}
