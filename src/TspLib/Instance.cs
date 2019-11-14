using System.Collections.Generic;

namespace TspLib
{
    public class Instance
    {
        public Instance(string name, string comment, IEnumerable<Point> points)
        {
            Name = name;
            Comment = comment;
            Points = points;
        }

        public string Name { get; }

        public string Comment { get; }

        public IEnumerable<Point> Points { get; }
    }
}