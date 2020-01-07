using System.Collections.Generic;
using TspLib.Extensions;
using TspLib.Metaheuristics.Abstraction;

namespace TspLib.Metaheuristics
{
    internal class RandomSolver : ISolver
    {
        public string Id => nameof(RandomSolver);

        public IEnumerable<Point> Solve(IEnumerable<Point> points) => points.Shuffle();
    }
}