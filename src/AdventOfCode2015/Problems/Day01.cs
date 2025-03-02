using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2015.Problems
{
    public class Day01 : IDayBase
    {
        string _inputPath = string.Empty;
        string _input = string.Empty;
        int _startingFloor = 0;
        int _firstResult;
        int _secondResult;
        int[] _firstList = Array.Empty<int>();
        int[] _secondList = Array.Empty<int>();
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

        public int[] FirstList
        {

            get => _firstList;
            set
            {
                if (_firstList != value)
                {
                    _firstList = value;
                }
            }
        }
        public int[] SecondList
        {

            get => _secondList;
            set
            {
                if (_secondList != value)
                {
                    _secondList = value;
                }
            }
        }
        public  void InitialiseProblem()
        {
            _input = File.ReadAllText(_inputPath);
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var floor = _startingFloor;
            foreach (var parenthesis in _input)
            {
                if (parenthesis == '(')
                    floor++;
                else
                    floor--;
            }

            return (T)Convert.ChangeType(floor, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var floor = _startingFloor;
            var position = 0;
            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[i] == '(')
                    floor++;
                else
                {
                    floor--;
                    if (floor == -1)
                    {
                        position = i + 1; // Result isn't 0 indexed
                        break;
                    }
                }
            }
            return (T)Convert.ChangeType(position, typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public Day01(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }

    }
}
