using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day02 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int[][] _spreadsheetData = new int [0][];
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
        public Day02(string inputPath) 
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
            var input = File.ReadAllLines(_inputPath);
            _spreadsheetData = new int[input.Length][];
            for (int i = 0; i < input.Length; i++) 
            {
                var numbers = input[i].Split("\t");
                _spreadsheetData[i] = numbers.Select(x => int.Parse(x.Trim())).ToArray();
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            int checkSum = 0;
            foreach ( var row in _spreadsheetData ) 
            {
                var min = row.Min();
                var max = row.Max();
                var difference = Math.Abs(max - min);
                checkSum += difference;
            }


            return (T)Convert.ChangeType(checkSum, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            int sum = 0;

            foreach (var row in _spreadsheetData)
            {
                var combinations = ArrayHelperFunctions.GetAllCombinations(row).Where(x => x.Length == 2).ToArray();
                var result = combinations.Where(x => (x[0] % x[1] == 0) || (x[1] % x[0] == 0)).Select(x => x).Single();
                var division = result.Max() / result.Min();
                sum += division;
            }

            return (T)Convert.ChangeType(sum, typeof(T));
        }



        #endregion
    }
}
