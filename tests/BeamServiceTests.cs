using TspLib;
using TspLib.Metaheuristics;
using Xunit;

namespace tests
{
    public class BeamServiceTests
    {
        [Fact]
        public void Sometest()
        {
            var service = new BeamSearchSolver();

            var points = new Point[4];

            points[0] = new Point(1, 0, 0);
            points[1] = new Point(2, 0, 1);
            points[2] = new Point(3, 1, 1);
            points[3] = new Point(4, 1, 0);

            var solution = service.GetOptimalPoints(points);
        }
    }
}