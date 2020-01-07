using System.Linq;

namespace TspLib.Metaheuristics.BeamSearch
{
    public class PartialSolution
    {
        public PartialSolution(PartialSolution partialSolution, PartialSolutionTail partialSolutionTail, int id)
        {
            Id = id;

            var points = partialSolution.Points.ToList();
            points.AddRange(partialSolutionTail.Points);
            Points = points.ToArray();

            DistanceClosed += partialSolutionTail.ClosedDistance;
            DistanceOpen = partialSolution.DistanceOpen + partialSolutionTail.DistanceOpen;

            LastPoint = partialSolutionTail.LastPoint;
        }

        public PartialSolution(Point startPoint)
        {
            Points = new Point[1];
            Points[0] = startPoint;

            LastPoint = startPoint;
        }

        public Point[] Points { get; }

        public Point LastPoint { get; }

        public double DistanceClosed { get; }

        public double DistanceOpen { get; }

        public int Id { get; }
    }
}