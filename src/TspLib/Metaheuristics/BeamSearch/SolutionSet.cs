using System.Linq;

namespace TspLib.Metaheuristics.BeamSearch
{
    public class SolutionSet
    {
        public static int BeamWidth = 11;

        public SolutionSet(PartialSolution[] ordered)
        {
            PartialSolutionList = new PartialSolution[BeamWidth];
            Set(ordered);
        }

        public PartialSolution[] PartialSolutionList { get; }

        internal void Set(PartialSolution[] partialSolutions)
        {
            int width = BeamWidth;
            if (partialSolutions.Length < BeamWidth)
            {
                width = partialSolutions.Length;
            }
            for (var i = 0; i < width; i++)
            {
                PartialSolutionList[i] = partialSolutions[i];
            }
        }

        internal void Attach(PartialSolutionTail[] tails)
        {
            for (var i = 0; i < tails.Length; i++)
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