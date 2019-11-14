using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TspLib.FiloIO
{ 
    public class InstanceFactory
    {
        private const int NameIndex = 0;
        private const int CommentIndex = 1;

        public static Instance Load(string filePath)
        {
            var lines = File.ReadAllLines(filePath, System.Text.Encoding.UTF8);
            var header = lines.Take(2).ToArray();

            var pointLines = lines
                .Reverse()
                .Take(lines.Count() - 2)
                .Reverse();

            var points = new List<Point>();
            foreach (var pointLine in pointLines)
            {
                var segments = pointLine.Split('\t');
                points.Add(new Point(
                    int.Parse(segments[0]),
                    int.Parse(segments[1]),
                    int.Parse(segments[2])));
            }
            
            var name = header[NameIndex].Split('\t')[1];
            var comment = header[CommentIndex].Split('\t')[1];

            return new Instance(name, comment, points);
        }
    }
}
