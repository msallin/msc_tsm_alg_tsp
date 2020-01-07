using System.Collections.Generic;

namespace TspLib.Metaheuristics.Abstraction
{
    public interface IPathFinder
    {
        PathResult Find(Point startPoint, IEnumerable<Point> points);
    }
}
