using CommonTypes.CommonTypes.Interfaces;
using System.Text;

namespace AdventOfCode2015.Problems
{
    public class Day10 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _processLimit = 0;
        string _input = string.Empty;

        #endregion

        #region Properties
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

        #endregion

        #region Constructor
        public Day10(string inputPath, int processLimit)
        {
            _inputPath = inputPath;
            _processLimit = processLimit;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _input = File.ReadAllText(InputPath);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = ProcessInputString();
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            _processLimit = 50;
            var result = ProcessInputString();
            return (T)Convert.ChangeType(result, typeof(T));
        }

        int ProcessInputString()
        {
            int iterator = 0;
            var inputCopy = _input.ToString();
            while (iterator < _processLimit)
            {
                StringBuilder result = new StringBuilder();
                char repeatValue = inputCopy[0];
                inputCopy = inputCopy[1..] + " ";
                int times = 1;

                foreach (char value in inputCopy)
                {
                    if (value == repeatValue)
                        times++;
                    else
                    {
                        result.Append(Convert.ToString(times) + repeatValue);
                        times = 1;
                        repeatValue = value;
                    }
                }

                inputCopy = result.ToString();
                iterator++;
            }

            return inputCopy.Length;
        }
        #endregion

    }
}
