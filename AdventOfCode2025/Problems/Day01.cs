using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2025.Problems
{
    public class Day01 : IDayBase
    {
        string _inputPath = string.Empty;
        int _firstResult;
        int _secondResult;
        string[] _input;

        protected  string InputPath
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

        public  void InitialiseProblem()
        {
            _input = File.ReadAllLines(InputPath);
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = 0;
            var currentPosition = 50;
            foreach (var line in _input)
            {
                var value = int.Parse(line.Substring(1));
                var isLeft = line.First() == 'L';
                currentPosition = isLeft ? currentPosition - value : currentPosition + value;
                currentPosition = Mod(currentPosition, 100);

                if (currentPosition == 0)
                    result++;
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            int result = 0;
            int currentPosition = 50;

            foreach (var line in _input)
            {
                int value = int.Parse(line.Substring(1));
                bool isLeft = line.First() == 'L';

                int stepsUntilZero;

                if (isLeft)
                {
                    // Moving left toward lower numbers
                    stepsUntilZero = currentPosition == 0 ? 0 : currentPosition;
                }
                else
                {
                    // Moving right toward higher numbers
                    stepsUntilZero = (100 - currentPosition) % 100;
                }

                int kFirst = stepsUntilZero == 0 ? 100 : stepsUntilZero;

                if (value >= kFirst)
                    result += 1 + (value - kFirst) / 100;

                currentPosition = isLeft
                    ? Mod(currentPosition - value, 100)
                    : Mod(currentPosition + value, 100);
            }

            return (T)Convert.ChangeType(result, typeof(T));
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

        static int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
