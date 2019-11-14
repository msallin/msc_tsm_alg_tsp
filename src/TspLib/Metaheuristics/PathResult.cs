namespace TspLib.Metaheuristics
{
    public class PathResult
    {
        public PathResult(double distance, Point point)
        {
            Distance = distance;
            LastPoint = point;
        }

        public double Distance { get; private set; }
        public Point LastPoint { get; }

        public Point FirstPoint { get; private set; }

        public PathResult Plus(double distance)
        {
            Distance += distance;
            return this;
        }

        internal void AddFirstPoint(Point point)
        {
            FirstPoint = point;
            ;
        }
    }
}