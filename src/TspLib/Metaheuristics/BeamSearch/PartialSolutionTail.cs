using System.Linq;

namespace TspLib.Metaheuristics.BeamSearch
{
    public class PartialSolutionTail
    {
        public PartialSolutionTail(PartialSolutionTail fromTail, Point point)
        {
            var points = fromTail.Points.ToList();
            if (!points.Any())
            {
                DistanceOpen += fromTail.Head.LastPoint.CalculateDistanceTo(point);
            }
            else
            {
                DistanceOpen = fromTail.DistanceOpen + fromTail.LastPoint.CalculateDistanceTo(point);
            }

            points.Add(point);
            Points = points.ToArray();

            Head = fromTail.Head;
            LastPoint = point;
        }

        public PartialSolutionTail(PartialSolution partialSolution)
        {
            Head = partialSolution;
            Points = new Point[0];
        }

        public PartialSolution Head { get; }

        public double ClosedDistance =>
            DistanceOpen
            + Head.DistanceOpen
            + LastPoint.CalculateDistanceTo(Head.Points.First());

        public double DistanceOpen { get; }

        public Point LastPoint { get; }

        public Point[] Points { get; }
    }
}