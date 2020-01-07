using System.Linq;

namespace TspLib.Metaheuristics.BeamSearch
{
    public class SolutionSet
    {
        public static int BeamWith = 11;

        public SolutionSet(PartialSolution[] ordered)
        {
            PartialSolutionList = new PartialSolution[BeamWith];
            Set(ordered);
        }

        public PartialSolution[] PartialSolutionList { get; }

        internal void Set(PartialSolution[] partialSolutions)
        {
            for (var i = 0; i < BeamWith; i++)
            {
                PartialSolutionList[i] = partialSolutions[i];
            }
        }

        internal void Attach(PartialSolutionTail[] tails)
        {
            for (var i = 0; i < tails.Count(); i++)
            {
                var tail = tails[i];
                PartialSolutionList[i] = new PartialSolution(tail.Head, tail, i);
            }
        }

        internal Point[] BestSolution()
        {
            return PartialSolutionList
                .OrderBy(p => p.DistanceClosed)
                .First()
                .Points;
        }
    }
}