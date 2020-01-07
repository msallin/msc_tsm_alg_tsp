using System;
using System.Collections.Generic;
using System.Linq;
using TspLib.Metaheuristics.Abstraction;
using TspLib.Metaheuristics.BeamSearch;

namespace TspLib.Metaheuristics
{
    public class BeamSearchSolver : ISolver
    {
        private const int BeamDepth = 3;

        public string Id => nameof(BeamSearchSolver);

        public IEnumerable<Point> Solve(IEnumerable<Point> points) => GetOptimalPoints(points.ToArray());

        public Point[] GetOptimalPoints(Point[] points)
        {
            Console.WriteLine("Start");
            var beam = new Beam();

            var solution = CreateFirstSolutionSet(points);

            var i = 0;
            while (solution.PartialSolutionList[0].Points.Count() < points.Count())
            {
                i++;
                solution = beam.GetNextSolutionSet(solution, points, BeamDepth);
                Console.WriteLine("{0} of {1} done", i, points.Length);
            }

            return solution.BestSolution();
        }

        private static SolutionSet CreateFirstSolutionSet(Point[] points)
        {
            var partialSolutions = new PartialSolution[SolutionSet.BeamWith];
            for (var i = 0; i < SolutionSet.BeamWith; i++)
            {
                partialSolutions[i] = new PartialSolution(points[i]);
            }

            return new SolutionSet(partialSolutions);
        }
    }
}