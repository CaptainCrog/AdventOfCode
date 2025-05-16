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
        List<Point> _coordinates = [];
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
        public Day06(string inputPath)
        {
            _inputPath = inputPath;
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
        }


        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var convexHullCoordinates = GetConvexHull(_coordinates); //Determines the edge pieces which will reach out to infinity
            return (T)Convert.ChangeType(0, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(0, typeof(T));
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
                while (k >= 2 && cross(H[k - 2], H[k - 1], coordinates[i]) <= 0)
                    k--;
                H[k++] = coordinates[i];
            }

            // Build upper hull
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && cross(H[k - 2], H[k - 1], coordinates[i]) <= 0)
                    k--;
                H[k++] = coordinates[i];
            }

            return H.Take(k - 1).ToList();
        }

        public static double cross(Point O, Point A, Point B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        #endregion
    }
}
