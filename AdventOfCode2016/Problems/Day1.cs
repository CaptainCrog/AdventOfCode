namespace AdventOfCode2016.Problems
{
    public class Day1 : DayBase
    {
        string _inputPath = string.Empty;
        int _firstResult;
        int _secondResult;
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

        public Day1(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }

        public override void InitialiseProblem()
        {
            throw new NotImplementedException();
        }

        public override void OutputSolution()
        {
            throw new NotImplementedException();
        }

        public override T SolveFirstProblem<T>()
        {
            throw new NotImplementedException();
        }

        public override T SolveSecondProblem<T>()
        {
            throw new NotImplementedException();
        }
    }
}
