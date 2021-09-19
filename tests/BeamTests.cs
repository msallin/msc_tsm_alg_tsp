using System.Collections.Generic;
using TspLib;
using TspLib.Metaheuristics.BeamSearch;
using Xunit;

namespace tests
{
    public class BeamTests
    {
        [Fact]
        public void CalculateLength()
        {
            var beam = new Beam();

            var startPoint = new Point(1, 0, 0);
            var startPointTwo = new Point(2, 1, 1);

            var nextPoints = new Point[3];

            nextPoints[0] = new Point(3, 0, 5);
            nextPoints[1] = new Point(4, 0, 2);
            nextPoints[2] = new Point(5, 5, 0);

            var partialSolutions = new List<PartialSolution>
            {
                new(startPoint),
                new(startPointTwo)
            };

            var solution = beam.GetNextSolutionSet(new SolutionSet(partialSolutions.ToArray()), nextPoints, 1);

            Assert.Equal(nextPoints[3], solution.PartialSolutionList[0].Points[1]);
            Assert.Equal(nextPoints[3], solution.PartialSolutionList[1].Points[1]);
        }
    }
}