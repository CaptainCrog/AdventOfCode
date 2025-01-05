using System.Text.RegularExpressions;

namespace AdventOfCode2024.Problems
{
    public partial class Day7 : DayBase
    {

        #region Fields
        string _inputPath = string.Empty;
        string[] _bridgeCalibrations = [];
        ulong _firstResult = 0;
        ulong _secondResult = 0;
        ulong _sum = 0;
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

        string[] BridgeCalibrations
        {
            get => _bridgeCalibrations;
            set
            {
                if (_bridgeCalibrations != value)
                {
                    _bridgeCalibrations = value;
                }
            }
        }

        public ulong FirstResult
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
        public ulong SecondResult
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

        ulong Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }


        #endregion

        #region Constructor
        public Day7(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<ulong>();
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            BridgeCalibrations = File.ReadLines(_inputPath).ToArray();
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            foreach (var calibration in BridgeCalibrations)
            {
                Sum += CalculateCalibration(calibration, 2);
            }

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = 0;

            foreach (var calibration in BridgeCalibrations)
            {
                Sum += CalculateCalibration(calibration, 3);
            }

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }


        public ulong CalculateCalibration(string calibration, int baseValue)
        {
            var calibrationRegex = GetNumbersRegex();
            var allMatches = calibrationRegex.Matches(calibration).ToList();
            var testResult = ulong.Parse(allMatches.First().Value);
            allMatches.Remove(allMatches.First());
            var operators = allMatches.Select(x => int.Parse(x.Value)).ToList();
            var totalCombinations = Math.Pow(baseValue, operators.Count() - 1);


            for (int i = 0; i <= totalCombinations - 1; i++)
            {
                // Create a combination map using either a binary or ternary baseValue
                string combination = CreateCombinationMap(operators, i, baseValue);
                string operatorMap = "";

                foreach (char bit in combination)
                {
                    if (bit == '0')
                        operatorMap += '+';
                    else if (bit == '1')
                        operatorMap += '*';
                    else
                        operatorMap += '|';
                }

                var result = ProcessNumbers(operators, operatorMap, testResult);
                if (result == testResult)
                    return result;

            }
            return 0;
        }

        public ulong ProcessNumbers(List<int> operators, string operatorMap, ulong testResult)
        {
            ulong sum = 0;
            for (int i = 1; i <= operatorMap.Count(); i++)
            {
                if (sum > testResult)
                    return sum;
                if (sum == 0)
                {
                    if (operatorMap[i - 1] == '+')
                        sum = (ulong)(operators[i - 1] + operators[i]);
                    else if (operatorMap[i - 1] == '*')
                        sum = (ulong)(operators[i - 1] * operators[i]);
                    else
                        sum = ulong.Parse(operators[i - 1].ToString() + operators[i].ToString());
                }
                else
                {
                    if (operatorMap[i - 1] == '+')
                        sum += (ulong)operators[i];
                    else if (operatorMap[i - 1] == '*')
                        sum *= (ulong)operators[i];
                    else
                    {
                        var sumString = sum.ToString();
                        sumString = sumString + operators[i].ToString();
                        sum = ulong.Parse(sumString);
                    }
                }
            }
            return sum;
        }

        public string CreateCombinationMap(List<int> operators, int iterator, int baseValue)
        {
            var finalCombinationMap = string.Empty;
            int modulusValue;
            do
            {
                if (iterator == 0)
                    break;

                modulusValue = iterator % baseValue;
                iterator /= baseValue;
                finalCombinationMap = modulusValue.ToString() + finalCombinationMap;
            }
            while (iterator > 0);

            return finalCombinationMap.PadLeft(operators.Count() - 1, '0');

        }

        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex GetNumbersRegex();

        #endregion

    }
}
