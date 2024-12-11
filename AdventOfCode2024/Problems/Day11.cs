using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day11 : DayBase
    {

        #region Fields

        string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024PuzzleInputDay11.txt";
        int _firstResult = 0;
        int _secondResult = 0;
        int _trailHeadScore = 0;
        int _sumOfStones = 0;
        string _initialArrangement = string.Empty;
        List<ulong> _iniitialNumbers = new List<ulong>();
        Dictionary<ulong, List<ulong>> _tempDictionary = new Dictionary<ulong, List<ulong>>()
        {
            { 0, new List<ulong>() { 1 } }
        }; // Maximum number the dictionary gets to is 1436

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


        int FirstResult
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
        int SecondResult
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

        string InitialArrangement
        {
            get => _initialArrangement;
            set
            {
                if (_initialArrangement != value)
                {
                    _initialArrangement = value;
                }
            }
        }

        int SumOfStones
        {
            get => _sumOfStones;
            set
            {
                if (_sumOfStones != value)
                {
                    _sumOfStones = value;
                }
            }
        }
        List<ulong> InitialNumbers
        {
            get => _iniitialNumbers;
            set
            {
                if (_iniitialNumbers != value)
                {
                    _iniitialNumbers = value;
                }
            }
        }

        #endregion

        #region Constructor
        public Day11()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            InitialArrangement = File.ReadAllText(InputPath);
            var numberStrings = InitialArrangement.Split(" ");
            foreach (var numberString in numberStrings)
            {
                InitialNumbers.Add(ulong.Parse(numberString));
            }

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            SumOfStones = ProcessRocks(25);

            return (T)Convert.ChangeType(SumOfStones, typeof(T));
            //194557 Correct
        }


        public override T SolveSecondProblem<T>()
        {
            SumOfStones = ProcessRocks2(75);

            return (T)Convert.ChangeType(SumOfStones, typeof(T));
        }


        private int ProcessRocks(int iterationLimit)
        {
            var iteration = 0;
            var numbers = InitialNumbers.ToList();
            while (iteration != iterationLimit)
            {
                //foreach (var number in numbers)
                //{
                //    Console.Write($"{number} ");
                //}
                //Console.WriteLine();

                var numbersCopy = new List<ulong>();

                //ulong[] ones = Enumerable.Repeat((ulong)1, numbers.Where(x => x == 0).Count()).ToArray();
                //numbersCopy.AddRange(ones);
                //var splitNumbers = numbers.Where(x => Math.Floor(Math.Log10(x) + 1) % 2 == 0).ToList();
                //foreach (var number in splitNumbers)
                //{
                //    (ulong leftNumber, ulong rightNumber) = GetSplitNumbers(number);
                //    numbersCopy.AddRange(new List<ulong>() { leftNumber, rightNumber });
                //}
                //var numbersToMultiply = numbers.Where(x => x != 0 && Math.Floor(Math.Log10(x) + 1) % 2 != 0).ToList();
                //numbersToMultiply.ForEach(x => numbersCopy.Add(x *= 2024));

                for (int i = 0; i <= numbers.Count - 1; i++)
                {
                    if (_tempDictionary.TryGetValue(numbers[i], out var cachedNumberList))
                    {
                        numbersCopy.AddRange(cachedNumberList);
                    }
                    else if (Math.Floor(Math.Log10(numbers[i]) + 1) % 2 == 0)
                    {
                        var numberToSplit = numbers[i].ToString();
                        var halfSize = numberToSplit.Length / 2;
                        var leftNumber = ulong.Parse(numberToSplit.Substring(0, halfSize));
                        var rightNumber = ulong.Parse(numberToSplit.Substring(halfSize, halfSize));
                        _tempDictionary.Add(numbers[i], new List<ulong>() { leftNumber, rightNumber });
                        numbersCopy.Add(leftNumber);
                        numbersCopy.Add(rightNumber);
                    }
                    else
                    {
                        _tempDictionary.Add(numbers[i], new List<ulong>() { numbers[i] * 2024 });
                        numbersCopy.Add(numbers[i] * 2024);
                    }

                }
                numbers = numbersCopy;
                Console.WriteLine($"Processed iteration: {iteration}");

                iteration++;
            }

            return numbers.Count;
        }

        private int ProcessRocks2(int iterationLimit)
        {
            var numbers = InitialNumbers.ToList();
            int sum = 0;
            foreach (var num in numbers)
            {
                var iteration = 0;
                List<ulong> numbersCopy = new List<ulong>();
                while (iteration < iterationLimit)
                {
                    if (iteration == 0)
                        numbersCopy = new List<ulong>() { num };
                    numbersCopy = ProcessNumber(numbersCopy);
                    sum = numbersCopy.Count;
                    Console.WriteLine($"Processed Iteration: {iteration}");
                    iteration++;
                }
            }
            return sum;
        }

        private List<ulong> ProcessNumber(List<ulong> numbersCopy)
        {
            var temp3 = new List<ulong>();
            for (int i = 0; i < numbersCopy.Count; i++)
            {
                if (_tempDictionary.TryGetValue(numbersCopy[i], out var cachedNumberList))
                {
                    temp3.AddRange(cachedNumberList);
                }
                else if (Math.Floor(Math.Log10(numbersCopy[i]) + 1) % 2 == 0)
                {
                    var numberToSplit = numbersCopy[i].ToString();
                    var halfSize = numberToSplit.Length / 2;
                    var leftNumber = ulong.Parse(numberToSplit.Substring(0, halfSize));
                    var rightNumber = ulong.Parse(numberToSplit.Substring(halfSize, halfSize));
                    _tempDictionary.Add(numbersCopy[i], new List<ulong>() { leftNumber, rightNumber });
                    temp3.Add(leftNumber);
                    temp3.Add(rightNumber);
                }
                else
                {
                    _tempDictionary.Add(numbersCopy[i], new List<ulong>() { numbersCopy[i] * 2024 });
                    temp3.Add(numbersCopy[i] * 2024);
                }
            }
            return temp3;
        }

        (ulong leftNumber, ulong rightNumber) GetSplitNumbers(ulong number)
        {
            var numberToSplit = number.ToString();
            var halfSize = numberToSplit.Length / 2;
            var leftNumber = ulong.Parse(numberToSplit.Substring(0, halfSize));
            var rightNumber = ulong.Parse(numberToSplit.Substring(halfSize, halfSize));
            return (leftNumber, rightNumber);
        }
    }
        #endregion
}
