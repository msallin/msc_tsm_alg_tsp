using System;
using System.Collections.Generic;
using System.Linq;
using TspLib.Metaheuristics.Interfaces;

namespace TspLib.Metaheuristics.BeamSearch
{
    public class BeamService : ISolver
    {
        private readonly int _beamDepth = 3;

        public string Id => "Beam";

        public Point[] GetOptimalPoints(Point[] points)
        {
            Console.WriteLine("Start");
            var beam = new Beam();

            var solution = CreateFirstSolutionSet(points);

            int i = 0;
            while(solution.PartialSolutionList[0].Points.Count() < points.Count())
            {
                i++;
                solution = beam.GetNextSolutionSet(solution, points, _beamDepth);
                Console.WriteLine("{0} of {1} done", i, points.Length);
            }

            return solution.BestSolution() ;
        }

        public IEnumerable<Point> Solve(IEnumerable<Point> points) => GetOptimalPoints(points.ToArray());

        private SolutionSet CreateFirstSolutionSet(Point[] points)
        {
            var partialSolutions = new PartialSolution[SolutionSet.BeamWith];
            for (int i = 0; i < SolutionSet.BeamWith; i++)
            {
                partialSolutions[i] = new PartialSolution(points[i]);
            }
            return new SolutionSet(partialSolutions, points.Length);
        }
    }
}
