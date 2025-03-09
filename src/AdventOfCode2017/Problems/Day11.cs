using CommonTypes.CommonTypes.Interfaces;
using System.Numerics;

namespace AdventOfCode2017.Problems
{
    /// <summary>
    /// This solution will be using an axial coordinate based system as per this link https://www.redblobgames.com/grids/hexagons/
    /// </summary>
    public class Day11 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _path = [];
        readonly Dictionary<string, Vector3> _directionVectors = new()
        {
            { "n",  new Vector3(0, 1, -1) },
            { "s", new Vector3(0, -1, 1) },
            { "nw", new Vector3(-1, 1, 0) },
            { "se", new Vector3(1, -1, 0) },
            { "sw", new Vector3(-1, 0, 1) },
            { "ne", new Vector3(1, 0, -1) },
        };

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
        public Day11(string inputPath) 
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
            _path = File.ReadAllText(_inputPath).Split(',');
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        /// <summary>
        ///   \ n  /
        /// nw +--+ ne
        ///   /    \
        /// -+      +-
        ///   \    /
        /// sw +--+ se
        ///   / s  \
        ///   x == 1
        ///   y == s
        ///   z == r
        ///   
        ///   n  = (x = 0, y = + 1, z = - 1)
        ///   s  = (x = 0, y = - 1, z = + 1)
        ///   nw = (x = - 1, y = + 1, z = 0)
        ///   se = (x = + 1, y = - 1, z = 0)
        ///   sw = (x = - 1, y = 0, z = + 1)
        ///   ne = (x = + 1, y = 0, z = - 1)
        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var currentVector = new Vector3(0, 0, 0);
            foreach (var direction in _path)
            {
                var directionVector = _directionVectors[direction];
                currentVector += directionVector;
            }

            var result = (Math.Abs(currentVector.X) + Math.Abs(currentVector.Y) + Math.Abs(currentVector.Z)) / 2;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var max = 0;
            var currentVector = new Vector3(0, 0, 0);
            foreach (var direction in _path)
            {
                var directionVector = _directionVectors[direction];
                currentVector += directionVector;

                max = Math.Max(max, Convert.ToInt32(Math.Abs(currentVector.X) + Math.Abs(currentVector.Y) + Math.Abs(currentVector.Z)) / 2);
            }
            return (T)Convert.ChangeType(max, typeof(T));
        }
        #endregion
    }
}
