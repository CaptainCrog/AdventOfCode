using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2015.Problems
{
    public class Day20 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _target = 0;

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
        public Day20(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _target = int.Parse(File.ReadAllText(_inputPath));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            int houseNumber = 1;
            while (true)
            {
                int presentSum = CalculatePresents(houseNumber, true);
                if (presentSum >= _target)
                    break;
                houseNumber++;
            }

            return (T)Convert.ChangeType(houseNumber, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            int houseNumber = 1;
            while (true)
            {
                int presentSum = CalculatePresents(houseNumber, false);
                if (presentSum >= _target)
                    break;
                houseNumber++;
            }

            return (T)Convert.ChangeType(houseNumber, typeof(T));
        }

        // Part 1: P(H) = 10 * sum of divisors of H
        // Part 2: Amended logic to include D * E <= 50
        int CalculatePresents(int house, bool isPartOne)
        {
            int sum = 0;
            int sqrt = (int)Math.Sqrt(house);

            for (int i = 1; i <= sqrt; i++)
            {
                if (house % i == 0)
                {
                    if (isPartOne)
                    {
                        sum += i * 10;
                        if (i != house / i)
                            sum += (house / i) * 10;
                    }
                    else
                    {
                        if (house / i <= 50)
                            sum += i * 11;

                        if (i <= 50 && i != house / i)
                            sum += (house / i) * 11;
                    }

                }
            }

            return sum;
        }
        #endregion
    }
}