using System.Collections.Generic;

namespace TspLib.Metaheuristics.Interfaces
{
    public interface IPathFinder
    {
        PathResult Find(Point startPoint, IEnumerable<Point> points);
    }
}
