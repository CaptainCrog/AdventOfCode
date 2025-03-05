using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public class Day08 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Dictionary<string, int> _registers = new();
        string[] _instructions = [];
        int _highestValue = 0;

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
        public Day08(string inputPath) 
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
            _instructions = File.ReadAllLines(_inputPath);
            ProcessAllInstructions();
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(_registers.Select(x => x.Value).Max(), typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {

            return (T)Convert.ChangeType(_highestValue, typeof(T));
        }

        void ProcessAllInstructions()
        {
            for (int i = 0; i < _instructions.Length; i++)
            {
                var instruction = _instructions[i];
                var parts = instruction.Split(' ');

                _registers.TryAdd(parts[0], 0);
                _registers.TryAdd(parts[4], 0);
                var canCompleteInstruction = false;
                var checkRegisterValue = _registers[parts[4]];
                var checkComparatorValue = int.Parse(parts[6]);

                switch (parts[5])
                {
                    case ">":
                        canCompleteInstruction = checkRegisterValue > checkComparatorValue;
                        break;
                    case "<":
                        canCompleteInstruction = checkRegisterValue < checkComparatorValue;
                        break;
                    case ">=":
                        canCompleteInstruction = checkRegisterValue >= checkComparatorValue;
                        break;
                    case "<=":
                        canCompleteInstruction = checkRegisterValue <= checkComparatorValue;
                        break;
                    case "==":
                        canCompleteInstruction = checkRegisterValue == checkComparatorValue;
                        break;
                    case "!=":
                        canCompleteInstruction = checkRegisterValue != checkComparatorValue;
                        break;
                }

                if (canCompleteInstruction)
                {
                    ProcessInstruction(parts[0], parts[1], int.Parse(parts[2]));
                }

                _highestValue = Math.Max(_highestValue, _registers.Select(x => x.Value).Max());
            }
        }

        void ProcessInstruction(string registerKey, string instructionType, int adjustmentValue)
        {
            if (instructionType == "inc")
                _registers[registerKey] += adjustmentValue;
            else
                _registers[registerKey] -= adjustmentValue;
        }

        #endregion
    }
}
