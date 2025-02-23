using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day01 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _captchaInput = string.Empty;
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
        public Day01(string inputPath) 
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
            _captchaInput = File.ReadAllText(_inputPath);
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            int sum = ProcessCaptcha(1);

            return (T)Convert.ChangeType(sum, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            int sum = ProcessCaptcha(_captchaInput.Length / 2);

            return (T)Convert.ChangeType(sum, typeof(T));
        }


        int ProcessCaptcha(int lookAhead)
        {
            int sum = 0;
            for (int i = 0; i < _captchaInput.Length; i++)
            {
                var nextIndex = i + lookAhead;
                if (nextIndex >= _captchaInput.Length)
                    nextIndex %= _captchaInput.Length;

                if (_captchaInput[i] == _captchaInput[nextIndex])
                    sum += int.Parse(_captchaInput[i].ToString());
            }

            return sum;
        }

        #endregion
    }
}
