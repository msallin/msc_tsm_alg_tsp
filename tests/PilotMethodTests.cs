using System.Collections.Generic;
using tests.Infrastructure;
using TspLib;
using TspLib.Metaheuristics;
using TspLib.Metaheuristics.Abstraction;
using Xunit;

namespace tests
{
    public class PilotMethodTests : TestsBase
    {
        [Fact]
        public void CalculateLength()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();
            Container.Register<ISolver, PilotMethodSolver>();

            var points = new List<Point>
            {
                new (3, 0, 0),
                new (6, 1, 0),
                new (4, 2, 0),
                new (1, 2, 2),
                new (5, 1, 2),
                new (2, 0, 2)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }

        [Fact]
        public void CalculateLength_New()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();
            Container.Register<ISolver, PilotMethodSolver>();

            var points = new List<Point>
            {
                new (1, 0, 0),
                new (2, 5, 5),
                new (3, 0, 5),
                new (4, 5, 0),
                new (5, 1, 2.5)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }

        [Fact]
        public void CalculateLength_OnlyFour()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();
            Container.Register<ISolver, PilotMethodSolver>();

            var points = new List<Point>
            {
                new (4, 2, 0),
                new (1, 2, 2),
                new (5, 1, 2),
                new (2, 1, 0)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }

        [Fact]
        public void CalculateLength_OnlyTwo()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();
            Container.Register<ISolver, PilotMethodSolver>();

            var points = new List<Point>
            {
                new (4, 2, 0),
                new (1, 2, 2),
                new (5, 1, 2)
            };

            var pilotMethod = Container.Resolve<ISolver>();
            var test = pilotMethod.Solve(points);
        }
    }
}