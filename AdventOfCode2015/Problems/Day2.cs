using CommonTypes.CommonTypes.Classes;

namespace AdventOfCode2015.Problems
{
    public class Day2 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        ThreeDimensionalObject[] _allMeasurements = [];
        int _firstResult = 0;
        int _secondResult = 0;
        #endregion

        #region Properties
        protected override string InputPath
        {
            get => _inputPath;
            set
            {
                if (_inputPath != value)
                {
                    _inputPath = value;
                }
            }
        }

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
        public Day2(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadLines(_inputPath).ToArray();
            _allMeasurements = new ThreeDimensionalObject [input.Count()];
            for (int i = 0; i < input.Count(); i++) 
            {
                var stringMeasurements = input[i].Split(['x']);
                _allMeasurements[i] = new ThreeDimensionalObject(int.Parse(stringMeasurements[0]), int.Parse(stringMeasurements[1]), int.Parse(stringMeasurements[2]));
            }
        }

        public override T SolveFirstProblem<T>()
        {
            var squareFeet = 0;

            foreach (var measurement in _allMeasurements)
            {
                var smallestArea = int.MaxValue;

                var lw = measurement.Length * measurement.Width;
                smallestArea = Math.Min(smallestArea, lw);
                var wh = measurement.Width * measurement.Height;
                smallestArea = Math.Min(smallestArea, wh);
                var hl = measurement.Height * measurement.Length;
                smallestArea = Math.Min(smallestArea, hl);

                squareFeet += (2 * lw) + (2 * wh) + (2 * hl) + smallestArea;
            }

            return (T)Convert.ChangeType(squareFeet, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var feet = 0;
            foreach (var measurement in _allMeasurements)
            {
                var smallestPerimeter = int.MaxValue;
                var lwh = measurement.Length * measurement.Width * measurement.Height;
                var lwPerimeter = measurement.Length * 2 + measurement.Width * 2;
                smallestPerimeter = Math.Min(smallestPerimeter, lwPerimeter);
                var whPerimeter = measurement.Width * 2 + measurement.Height * 2;
                smallestPerimeter = Math.Min(smallestPerimeter, whPerimeter);
                var hlPerimeter = measurement.Height * 2 + measurement.Length * 2;
                smallestPerimeter = Math.Min(smallestPerimeter, hlPerimeter);

                feet += lwh + smallestPerimeter;
            }

            return (T)Convert.ChangeType(feet, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion
    }
}
