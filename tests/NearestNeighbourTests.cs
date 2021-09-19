using System.Collections.Generic;
using tests.Infrastructure;
using TspLib;
using TspLib.Metaheuristics;
using TspLib.Metaheuristics.Abstraction;
using Xunit;

namespace tests
{
    public class NearestNeighbourTests : TestsBase
    {
        [Fact]
        public void CalculateLength()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();

            var first = new Point(2, 0, 2.5);
            var points = new List<Point>
            {
                new (4, 0, 1.5),
                new (3, 0, 0.5),
                new (1, 0.5, 2),
                new (5, 0.5, 1),
                new (6, 0.5, 0)
            };

            var nearestNeighbour = Container.Resolve<IPathFinder>();
            var test = nearestNeighbour.Find(first, points);
        }

        [Fact]
        public void CalculateLength_OnlyFew()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();

            var first = new Point(2, 0, 2.5);
            var points = new List<Point>
            {
                new (1, 0.5, 2),
                new (4, 0, 1.5)
            };

            var nearestNeighbour = Container.Resolve<IPathFinder>();
            var test = nearestNeighbour.Find(first, points);
        }

        [Fact]
        public void CalculateLength_OnlyOne()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();

            var first = new Point(2, 0, 2.5);
            var points = new List<Point>
            {
                new (1, 0.5, 2)
            };

            var nearestNeighbour = Container.Resolve<IPathFinder>();
            var test = nearestNeighbour.Find(first, points);
        }
    }
}