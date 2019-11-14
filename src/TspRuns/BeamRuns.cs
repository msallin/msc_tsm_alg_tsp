using TspLib;
using TspLib.Metaheuristics.BeamSearch;
using Xunit;

namespace TspRuns
{
    public class BeamRuns
    {
        [Fact]
        public void BeamService()
        {
            var service = new TspService(new BeamService());
            service.Run("pr2392");
        }
    }
}