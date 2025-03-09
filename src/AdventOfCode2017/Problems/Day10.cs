using CommonTypes.CommonTypes.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public class Day10 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        string _secondResult = string.Empty;
        string[] _instructions = [];
        LinkedList<int> _numbers = [];

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
        public string SecondResult
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
        public Day10(string inputPath, int listLength) 
        {
            _inputPath = inputPath;
            _numbers = new LinkedList<int>(Enumerable.Range(0, listLength).ToArray());
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            _instructions = Regex.Split(File.ReadAllText(_inputPath), @"(,)"); //.Split(',').Select(int.Parse).ToArray();
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            int[] part1Instructions = _instructions.Where(x => int.TryParse(x, out _)).Select(int.Parse).ToArray();
            var numbersCopy = new LinkedList<int>(_numbers);
            int numberIterator = 0;
            int skipSize = 0;
            for (int i = 0; i < part1Instructions.Length; i++)
            {
                var currentNumberIterator = numberIterator % numbersCopy.Count;
                var instruction = part1Instructions[i];
                if (instruction > numbersCopy.Count)
                    continue;

                var numberRange = GetNumberRange(currentNumberIterator, instruction, numbersCopy);
                var reversedRange = numberRange.Reverse().ToArray();
                ReplaceNumbers(currentNumberIterator, reversedRange, numbersCopy);
                numberIterator += instruction + skipSize;
                skipSize++;

            }

            var result = numbersCopy.First.Value * numbersCopy.First.Next.Value;
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            int[] part2Instructions = [.._instructions.SelectMany(x => x.ToCharArray()).Select(x => (int)x).ToArray(), 17, 31, 73, 47, 23];
            var numbersCopy = new LinkedList<int>(_numbers);
            List<int> denseHashes = new List<int>();

            int numberIterator = 0;
            int skipSize = 0;
            for (int i = 0; i < 64; i++)
            {
                for (int j= 0; j< part2Instructions.Length; j++)
                {
                    var currentNumberIterator = numberIterator % numbersCopy.Count;
                    var instruction = part2Instructions[j];
                    if (instruction > numbersCopy.Count)
                        continue;

                    var numberRange = GetNumberRange(currentNumberIterator, instruction, numbersCopy);
                    var reversedRange = numberRange.Reverse().ToArray();
                    ReplaceNumbers(currentNumberIterator, reversedRange, numbersCopy);
                    numberIterator += instruction + skipSize;
                    skipSize++;
                }
            }

            for (int i = 0; i < numbersCopy.Count; i += 16)
            {
                denseHashes.Add(ReduceSparseHash(numbersCopy.Skip(i).Take(16).ToArray()));
            }

            var result = string.Join(string.Empty, denseHashes.Select(x => x.ToString("X2"))).ToLower();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        int[] GetNumberRange(int numberIterator, int instruction, LinkedList<int> numbers)
        {
            var currentNumberValue = numbers.Skip(numberIterator).First();
            var currentNumberNode = numbers.Find(currentNumberValue);
            var numberRange = new List<int>();
            for (int i = 0; i < instruction; i++)
            {
                numberRange.Add(currentNumberNode.Value);
                currentNumberNode = currentNumberNode.Next ?? numbers.First;
            }

            return numberRange.ToArray();
        }

        void ReplaceNumbers(int numberIterator, int[] reversedRange, LinkedList<int> numbers)
        {
            var currentNumberValue = numbers.Skip(numberIterator).First();
            var currentNumberNode = numbers.Find(currentNumberValue);

            for (int i = 0; i < reversedRange.Length; i++)
            {
                currentNumberNode.ValueRef = reversedRange[i];
                currentNumberNode = currentNumberNode.Next ?? numbers.First;
            }
        }

        int ReduceSparseHash(int[] sparseHash)
        {
            int denseHash = 0;
            for (int i = 0; i < sparseHash.Length; i++)
            {
                denseHash ^= sparseHash[i];
            }
            return denseHash;
        }
        #endregion
    }
}
