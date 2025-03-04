using CommonTypes.CommonTypes.Interfaces;
using System.Linq;

namespace AdventOfCode2017.Problems
{
    public class Day06 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int[] _memoryBank = [];
        string key = string.Empty;
        Dictionary<string, int> _previousMemoryBankOrientations = new();
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
        public Day06(string inputPath) 
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
            _memoryBank = File.ReadAllText(_inputPath).Split('\t').Select(int.Parse).ToArray();
            _previousMemoryBankOrientations.Add(string.Join(',', _memoryBank), 0);
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var stepCounter = 0;
            while (true)
            {
                _memoryBank = ProcessMemoryBank();
                stepCounter++;
                if (!_previousMemoryBankOrientations.TryAdd(string.Join(',', _memoryBank), stepCounter))
                {
                    key = string.Join(',', _memoryBank);
                    break;
                }
            }

            return (T)Convert.ChangeType(stepCounter, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var lastPosition = FirstResult;
            var initialPosition = _previousMemoryBankOrientations[key];
            var result = lastPosition - initialPosition;
            return (T)Convert.ChangeType(result, typeof(T));
        }

        int[] ProcessMemoryBank()
        {
            var newMemoryBank = _memoryBank.ToArray();

            int largestValue = newMemoryBank.Max();
            int index = Array.IndexOf(newMemoryBank, largestValue);
            newMemoryBank[index] = 0;
            int distribution = largestValue / newMemoryBank.Length;
            
            if (largestValue % newMemoryBank.Length == 0)
                newMemoryBank = newMemoryBank.Select(x => x += distribution).ToArray();
            else
            {
                if (largestValue > newMemoryBank.Length)
                    newMemoryBank[index] = distribution;

                distribution = (largestValue - distribution) / (newMemoryBank.Length - 1);
                var leftOverNumbers = largestValue - distribution;
                for (int i = 0; i < newMemoryBank.Length; i++)
                {
                    if (i == index)
                        continue;
                    newMemoryBank[i] += distribution;
                    leftOverNumbers -= distribution;
                }
                if (leftOverNumbers > 0)
                {
                    for (int i = 0; i < leftOverNumbers; i++)
                    {
                        var nextIndex = index + 1 + i;
                        if (nextIndex >= newMemoryBank.Length)
                            nextIndex %= newMemoryBank.Length;
                        newMemoryBank[nextIndex]++;
                    }
                }


            }
            return newMemoryBank;
        }

        #endregion
    }
}
