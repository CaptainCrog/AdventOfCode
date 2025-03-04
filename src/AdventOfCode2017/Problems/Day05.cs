using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day05 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int[] _instructions = [];
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
        public Day05(string inputPath) 
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
            _instructions = File.ReadAllLines(_inputPath).Select(int.Parse).ToArray();
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var stepCounter = 0;
            var instructions = _instructions.ToArray();
            for (int i = 0; i < instructions.Length;)
            {
                var instruction = instructions[i];
                instructions[i]++;
                i += instruction;
                stepCounter++;
            }

            return (T)Convert.ChangeType(stepCounter, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var stepCounter = 0;
            var instructions = _instructions.ToArray();
            for (int i = 0; i < instructions.Length;)
            {
                var instruction = instructions[i];
                if (instruction >= 3)
                    instructions[i]--;
                else
                    instructions[i]++;
                i += instruction;
                stepCounter++;
            }
            return (T)Convert.ChangeType(stepCounter, typeof(T));
        }

        #endregion
    }
}
