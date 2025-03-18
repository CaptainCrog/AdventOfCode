using AdventOfCode2017.CommonInternalTypes;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public class Day18 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _instructions = [];
        Dictionary<string, int> _registers = [];


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
        public Day18(string inputPath) 
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
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var lastPlayedFrequency = 0;
            var recovered = false;
            for (int i = 0; i < _instructions.Length; i++)
            {
                var instruction = _instructions[i];
                var parts = instruction.Split(' ');
                var registerKey = parts[1];
                var registerAdjustment = parts.Length == 3 ? int.TryParse(parts[2], out int _) ? int.Parse(parts[2]) : AddOrGetRegister(parts[2]) : 0;
                switch (parts[0])
                {
                    case "snd":
                        lastPlayedFrequency = AddOrGetRegister(registerKey);
                        break;
                    case "set":
                        SetRegister(registerKey, registerAdjustment);
                        break;
                    case "add":
                        SetRegister(registerKey, AddOrGetRegister(registerKey) + registerAdjustment);
                        break;
                    case "mul":
                        SetRegister(registerKey, AddOrGetRegister(registerKey) * registerAdjustment);
                        break;
                    case "mod":
                        SetRegister(registerKey, AddOrGetRegister(registerKey) % registerAdjustment);
                        break;
                    case "rcv":
                        if (AddOrGetRegister(registerKey) > 0)
                            recovered = true;
                        break;
                    case "jgz":
                        if (AddOrGetRegister(registerKey) > 0)
                        {
                            i += registerAdjustment - 1;
                        }
                        break;
                }

                if (recovered)
                    break;
            }

            return (T)Convert.ChangeType(lastPlayedFrequency, typeof(T));
            //-923 wrong
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        int AddOrGetRegister(string registerKey)
        {
            if (_registers.TryGetValue(registerKey, out int value))
            {
                return value;
            }
            else
            {
                _registers.Add(registerKey, 0);
                return _registers[registerKey];
            }
        }
        void SetRegister(string registerKey, int value)
        {
            _registers[registerKey] = value;
        }
        #endregion
    }
}
