using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TspLib.Extensions;
using TspLib.Metaheuristics.Abstraction;

namespace TspLib.Metaheuristics
{
    public class PilotMethodSolver : ISolver
    {
        private readonly IPathFinder _pathFinder;

        public PilotMethodSolver(IPathFinder pathFinder) => _pathFinder = pathFinder;

        public string Id => "PilotMethodSolver";

        public IEnumerable<Point> Solve(IEnumerable<Point> pointsInput)
        {
            var sortedPoints = pointsInput
                .OrderBy(p => p.Id);

            var startPoint = sortedPoints.First();
            var nextPoints = sortedPoints
                .WithoutFirst();

            var list = NewMethod(startPoint, startPoint, nextPoints);
            list.Add(startPoint);
            list.Reverse();
            return list;
        }

        private List<Point> NewMethod(Point startPoint, Point currentPoint, IEnumerable<Point> fromSecond)
        {
            Console.WriteLine("currentPoint {0} remaining number of points {1}", currentPoint.Id, fromSecond.Count());

            var results = new List<PathResult>();
            Parallel.ForEach(fromSecond, point =>
            {
                var result = _pathFinder.Find(point, fromSecond.Except(new List<Point> {point}));
                result.AddFirstPoint(point);
                results.Add(result);
            });

            var nextPoint = results
                .OrderBy(r => r.Distance)
                .First()
                .FirstPoint;

            var nextPoints = fromSecond.Except(new List<Point> {nextPoint});
            if (nextPoints.Count() > 1)
            {
                var list = NewMethod(startPoint, nextPoint, nextPoints);
                list.Add(nextPoint);
                return list;
            }

            return new List<Point> {nextPoints.Single(), nextPoint};
        }
    }
}