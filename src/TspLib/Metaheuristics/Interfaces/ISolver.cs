using System.Collections.Generic;

namespace TspLib.Metaheuristics.Interfaces
{
    public interface ISolver
    {
        string Id { get; }

        IEnumerable<Point> Solve(IEnumerable<Point> points);
    }
}
