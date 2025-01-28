using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Classes.Shapes;

namespace AdventOfCode2016.Problems
{
    public class Day3 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Triangle[] _triangles = [];
        Queue<int> _firstColumn = new();
        Queue<int> _secondColumn = new();
        Queue<int> _thirdColumn = new();

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
        public Result<int> FirstResult
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
        public Result<int> SecondResult
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
        public Day3(string inputPath)
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
            var input = File.ReadAllLines(_inputPath);
            _triangles = new Triangle[input.Length];
            for(int i= 0; i < input.Length; i++)
            {
                var triangle = input[i];
                var sides = triangle.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                _firstColumn.Enqueue(sides[0]);
                _secondColumn.Enqueue(sides[1]);
                _thirdColumn.Enqueue(sides[2]);

                sides = sides.Order().ToArray();

                _triangles[i] = new Triangle(sides[0], sides[1], sides[2]);
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var result = 0;
            foreach (var triangle in _triangles)
            {
                // adjacent + opposite
                var ao = triangle.Adjacent + triangle.Opposite;
                if (ao > triangle.Hypotenuse)
                    result++;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            var result = 0;
            result = ProcessQueue(_firstColumn, result);
            result = ProcessQueue(_secondColumn, result);
            result = ProcessQueue(_thirdColumn, result);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        int ProcessQueue(Queue<int> column, int result)
        {
            var sides = new int[3];
            while (column.Count >= 3)
            {
                sides[0] = column.Dequeue();
                sides[1] = column.Dequeue();
                sides[2] = column.Dequeue();
                sides = sides.Order().ToArray();

                var triangle = new Triangle(sides[0], sides[1], sides[2]);
                // adjacent + opposite
                var ao = triangle.Adjacent + triangle.Opposite;
                if (ao > triangle.Hypotenuse)
                    result++;
            }
            return result;
        }
        #endregion
    }
}
