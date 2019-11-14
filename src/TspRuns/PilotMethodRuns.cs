using tests.Infrastructure;
using TspLib;
using TspLib.Metaheuristics;
using TspLib.Metaheuristics.Interfaces;
using Xunit;

namespace TspRuns
{
    public class PilotMethodRuns : TestsBase
    {
        public PilotMethodRuns()
        {
            Container.Register<IPathFinder, NearestNeighbour>();
            Container.Register<ISolver, PilotMethod>();
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