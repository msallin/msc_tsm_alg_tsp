using System.Collections.Generic;

namespace TspLib.Metaheuristics.Abstraction
{
    public interface ISolver
    {
        string Id { get; }

        IEnumerable<Point> Solve(IEnumerable<Point> points);
    }
}
