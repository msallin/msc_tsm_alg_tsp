namespace TspLib.Metaheuristics.BeamSearch
{
    public class BeamLevel
    {
        public Point[] GetBestPoint(Point startPoint, Point[] nextPossiblePoints, int beamWith)
        {
            var bestPoints = new DistanceAndPointIdArray(beamWith);
            foreach (var point in nextPossiblePoints)
            {
                var distance = point.CalculateDistanceTo(startPoint);
                bestPoints.InsertIfPossible(distance, point);
            }
            return bestPoints.CreatePointArray();
        }
             
        private class DistanceAndPointId
        {
            public Point Point { get; }

            public double Distance { get; }

            public DistanceAndPointId(Point point, double distance)
            {
                Point = point;
                this.Distance = distance;
            }
        }

        private class DistanceAndPointIdArray
        {
            private int _emptyCellIndex;
            private readonly DistanceAndPointId[] _list;

            public DistanceAndPointIdArray(int length)
            {
                _list = new DistanceAndPointId[length];
            }

            public void InsertIfPossible(double distance, Point point)
            {
                if(_emptyCellIndex < _list.Length)
                {
                    _list[_emptyCellIndex] = new DistanceAndPointId(point, distance);
                    _emptyCellIndex++;
                    return;
                }

                for (int i = 0; i < _list.Length; i++)
                {
                    if (distance < _list[i].Distance)
                    {
                        _list[i] = new DistanceAndPointId(point, distance);
                        break;
                    }
                }
            }

            public Point[] CreatePointArray()
            {
                var points = new Point[_list.Length];
                for (int i = 0; i < _list.Length; i++)
                {
                    points[i] = _list[i].Point;
                }
                return points;
            }
        }
    }
}
