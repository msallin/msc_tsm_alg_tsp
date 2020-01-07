using tests.Infrastructure;
using TspLib;
using TspLib.Metaheuristics;
using TspLib.Metaheuristics.Abstraction;
using Xunit;

namespace TspRuns
{
    public class PilotMethodRuns : TestsBase
    {
        public PilotMethodRuns()
        {
            Container.Register<IPathFinder, NearestNeighbourPathFinder>();
            Container.Register<ISolver, PilotMethodSolver>();
        }

        [Fact]
        public void PilotMethod_NearestNeighbour_Berlin52()
        {
            var service = new TspService(Container.Resolve<ISolver>());
            service.Run("berlin52");
        }

        [Fact]
        public void PilotMethod_NearestNeighbour_Bier127()
        {
            var service = new TspService(Container.Resolve<ISolver>());
            service.Run("bier127");
        }
    }
}