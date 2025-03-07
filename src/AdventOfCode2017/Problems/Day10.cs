using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day10 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int[] _instructions = [];
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
        public Day10(string inputPath, int listLength) 
        {
            _inputPath = inputPath;
            _numbers = new LinkedList<int>(Enumerable.Range(0, listLength).ToArray());
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            _instructions = File.ReadAllText(_inputPath).Split(',').Select(int.Parse).ToArray();
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var numbersCopy = new LinkedList<int>(_numbers);
            int numberIterator = 0;
            int skipSize = 0;
            for (int i = 0; i < _instructions.Length; i++)
            {
                var currentNumberIterator = numberIterator % numbersCopy.Count;
                var instruction = _instructions[i];
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
            var numbersCopy = new LinkedList<int>(_numbers);

            return (T)Convert.ChangeType(0, typeof(T));
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
        #endregion
    }
}
