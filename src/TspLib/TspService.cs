using System;
using System.IO;
using System.Linq;
using TspLib.Extensions;
using TspLib.FileIO;
using TspLib.Metaheuristics.Abstraction;

namespace TspLib
{
    public class TspService
    {
        private static readonly string WorkPath = Environment.CurrentDirectory;
        private static readonly string InstancePath = Path.Combine(WorkPath, "TSP_Instances");
        private static readonly string HtmlPath = Path.Combine(WorkPath, "TSP_Solutions");

        private readonly ISolver _solver;

        public TspService(ISolver solver) => _solver = solver;

        public void Run(string instanceName)
        {
            Console.WriteLine("Loading instance " + instanceName + "...");

            string filePath = Path.Combine(InstancePath, instanceName + ".tsp");
            var instance = InstanceFactory.Load(filePath);

            Console.WriteLine("Instance has " + instance.Points.Count() + " points.");

            Console.WriteLine("Start generating a solution...");
            var solution = _solver.Solve(instance.Points);

            Console.WriteLine("Solution for " + instanceName + " has length: " + solution.ToList().EuclideanLength());
            Console.WriteLine();

            // Generate Visualization of Result, will be stored in directory pathToSolutions
            Printer.WriteToSVG(instance, solution, Path.Combine(HtmlPath, _solver.Id, instanceName));
        }
    }
}