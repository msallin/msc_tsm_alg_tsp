using System.Collections.Generic;
using tests.Infrastructure;
using TspLib;
using TspLib.Metaheuristics;
using TspLib.Metaheuristics.Interfaces;
using Xunit;

namespace tests
{
    public class PilotMethodTests : TestsBase
    {
        [Fact]
        public void CalculateLength()
        {
            Container.Register<IPathFinder, NearestNeighbour>();
            Container.Register<ISolver, PilotMethod>();

            var points = new List<Point>
            {
                new Point(3, 0, 0),
                new Point(6, 1, 0),
                new Point(4, 2, 0),
                new Point(1, 2, 2),
                new Point(5, 1, 2),
                new Point(2, 0, 2)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }

        [Fact]
        public void CalculateLength_New()
        {
            Container.Register<IPathFinder, NearestNeighbour>();
            Container.Register<ISolver, PilotMethod>();

            var points = new List<Point>
            {
                new Point(1, 0, 0),
                new Point(2, 5, 5),
                new Point(3, 0, 5),
                new Point(4, 5, 0),
                new Point(5, 1, 2.5)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }

        [Fact]
        public void CalculateLength_OnlyFour()
        {
            Container.Register<IPathFinder, NearestNeighbour>();
            Container.Register<ISolver, PilotMethod>();

            var points = new List<Point>
            {
                new Point(4, 2, 0),
                new Point(1, 2, 2),
                new Point(5, 1, 2),
                new Point(2, 1, 0)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }

        [Fact]
        public void CalculateLength_OnlyTwo()
        {
            Container.Register<IPathFinder, NearestNeighbour>();
            Container.Register<ISolver, PilotMethod>();

            var points = new List<Point>
            {
                new Point(4, 2, 0),
                new Point(1, 2, 2),
                new Point(5, 1, 2)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }
    }
}