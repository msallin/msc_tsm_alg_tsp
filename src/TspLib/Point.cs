using System;

namespace TspLib
{
    public class Point
    {
        public Point(int id, double x, double y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public int Id { get; }

        public double X { get; }

        public double Y { get; }

        public double CalculateDistanceTo(Point otherPoint)
        {
            var deltaX = X - otherPoint.X;
            var deltaY = Y - otherPoint.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}