using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Problems
{
    public partial class Day06 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _distanceLimit = 0;
        List<Point> _coordinates = [];
        List<Point> _grid = [];
        int _leftEdge = 0;
        int _topEdge = 0;
        int _rightEdge = 0;
        int _bottomEdge = 0;
        Regex _numberRegex = CommonRegexHelpers.PositiveNumberRegex();

        #endregion

        #region Properties
        public int FirstResult
        {
            get => _firstResult;
            set
            {
                if (_firstResult != value)
                {
                    _firstResult = value;
                }
            }
        }
        public int SecondResult
        {
            get => _secondResult;
            set
            {
                if (_secondResult != value)
                {
                    _secondResult = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day06(string inputPath, int distanceLimit)
        {
            _inputPath = inputPath;
            _distanceLimit = distanceLimit;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            foreach (var line in input)
            {
                var matches = _numberRegex.Matches(line);
                _coordinates.Add(new Point(int.Parse(matches[0].Value), int.Parse(matches[1].Value)));
            }

            _leftEdge = _coordinates.MinBy(x => x.X).X;
            _topEdge = _coordinates.MinBy(x => x.Y).Y;
            _rightEdge = _coordinates.MaxBy(x => x.X).X;
            _bottomEdge = _coordinates.MaxBy(x => x.Y).Y;
            for (int i = _leftEdge; i <= _rightEdge; i++)
            {
                for (int j = _topEdge; j <= _bottomEdge; j++)
                {
                    _grid.Add(new Point(i, j));
                }
            }
        }


        public T SolveFirstProblem<T>() where T : IConvertible
        {
            Dictionary<Point, int> closestPositionCount = new();

            var convexHullCoordinates = GetConvexHull(_coordinates); //Determines the edge pieces which will reach out to infinity

            foreach (var position in _grid)
            {
                var manhattanDistances = _coordinates.Select(coord => new { Coordinate = coord, ManhattanDistance = Math.Abs((position.X - coord.X)) + Math.Abs((position.Y - coord.Y)) }).ToList();
                var minDistance = manhattanDistances.MinBy(x => x.ManhattanDistance).ManhattanDistance;
                manhattanDistances = manhattanDistances.Where(x => x.ManhattanDistance == minDistance).ToList();

                if (manhattanDistances.Count() > 1)
                    continue;
                else
                {
                    if (!closestPositionCount.TryAdd(manhattanDistances.First().Coordinate, 1))
                    {
                        closestPositionCount[manhattanDistances.First().Coordinate]++;
                    }
                }
            }

            var result = closestPositionCount.Where(x => !convexHullCoordinates.Contains(x.Key)).ToDictionary().OrderByDescending(x => x.Value).First().Value;


            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = 0;
            foreach (var position in _grid)
            {
                var manhattanDistanceSum = _coordinates.Select(coord => new { Coordinate = coord, ManhattanDistance = Math.Abs((position.X - coord.X)) + Math.Abs((position.Y - coord.Y)) }).Sum(x => x.ManhattanDistance);
                if (manhattanDistanceSum < _distanceLimit)
                    result++;
            }



            return (T)Convert.ChangeType(result, typeof(T));
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        List<Point> GetConvexHull(List<Point> coordinates)
        {
            var n = coordinates.Count;
            var k = 0;
            List<Point> H = new List<Point>(new Point[2 * n]);

            coordinates.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

            // Build lower hull
            for (int i = 0; i < n; ++i)
            {
                while (k >= 2 && Cross(H[k - 2], H[k - 1], coordinates[i]) <= 0)
                    k--;
                H[k++] = coordinates[i];
            }

            // Build upper hull
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && Cross(H[k - 2], H[k - 1], coordinates[i]) <= 0)
                    k--;
                H[k++] = coordinates[i];
            }

            return H.Take(k - 1).ToList();
        }

        public static double Cross(Point O, Point A, Point B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        #endregion
    }
}
