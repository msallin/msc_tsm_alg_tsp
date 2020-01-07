using System.Collections.Generic;
using System.Linq;
using TspLib.Metaheuristics.Abstraction;

namespace TspLib.Metaheuristics
{
    public class GreedyInsertionSolver : ISolver
    {
        public string Id => nameof(GreedyInsertionSolver);

        public IEnumerable<Point> Solve(IEnumerable<Point> pointsInput)
        {
            var points = pointsInput
                .OrderBy(p => p.Id)
                .ToArray();

            // Array with the indices of the next nodes
            var nextIndices = new int[points.Length];

            // Initial partial tour 0 -> 1 -> 0
            nextIndices[0] = 1;

            // Find the best position to insert for each remaining point
            for (var i = 2; i < points.Length; i++)
            {
                var lowestDistanceIncrease = double.PositiveInfinity;
                var lowestDistanceIncreaseIdx = -1;

                for (var j = 0; j < i; j++)
                {
                    //Increased cost of tour if point i is inserted in place j
                    var distanceIncrease =
                        points[j].CalculateDistanceTo(points[i])
                        + points[i].CalculateDistanceTo(points[nextIndices[j]])
                        - points[j].CalculateDistanceTo(points[nextIndices[j]]);

                    if (distanceIncrease < lowestDistanceIncrease)
                    {
                        lowestDistanceIncrease = distanceIncrease;
                        lowestDistanceIncreaseIdx = j;
                    }
                }

                nextIndices[i] = nextIndices[lowestDistanceIncreaseIdx];
                nextIndices[lowestDistanceIncreaseIdx] = i;
            }

            // Walk along next indices to build solution.
            var solution = new List<Point>();
            var index = 0;
            for (var i = 0; i < points.Length; i++)
            {
                solution.Add(points[index]);
                index = nextIndices[index];
            }

            return solution;
        }
    }
}