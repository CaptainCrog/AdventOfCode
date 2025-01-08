namespace AdventOfCode2015.Problems
{
    public class Day9 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        List<SantasRoutes> _routes = new();
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
        public Day9(string inputPath)
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

            foreach (var line in input) 
            {
                var parts = line.Split(" = ");
                var locations = parts[0].Split(" to ");
                _routes.Add(new SantasRoutes() { Distance = int.Parse(parts[1].Trim()), Location1 = locations[0], Location2 = locations[1] });
            }
        }

        public override T SolveFirstProblem<T>()
        {

            return (T)Convert.ChangeType(0, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }


        #endregion
    }


    internal record SantasRoutes
    {
        public required string Location1 { get; init; }
        public required string Location2 { get; init; }
        public required int Distance { get; init;}
    }
}
