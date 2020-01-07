using System.Collections.Generic;
using System.Linq;
using TspLib.Extensions;
using TspLib.Metaheuristics.Abstraction;

namespace TspLib.Metaheuristics
{
    public class NearestNeighbourPathFinder : IPathFinder
    {
        public PathResult Find(Point startPoint, IEnumerable<Point> points) => GetDistanceToNearestNeightbourOfFirstElement(startPoint, points);

        private static PathResult GetDistanceToNearestNeightbourOfFirstElement(Point currentPoint, IEnumerable<Point> points)
        {
            var sortedNextPoints = points
                .OrderBy(p => p.CalculateDistanceTo(currentPoint));

            var distance = sortedNextPoints
                    .First()
                    .CalculateDistanceTo(currentPoint);

            var nextPoints = sortedNextPoints.WithoutFirst();
            if (nextPoints.Any())
            {
                return GetDistanceToNearestNeightbourOfFirstElement(sortedNextPoints.First(), nextPoints)
                    .Plus(distance);
            }

            return new PathResult(distance, points.Single());
        }
    }
}
