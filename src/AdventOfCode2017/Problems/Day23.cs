﻿using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day23 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _instructions = [];


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
        public Day23(string inputPath) 
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
            long result = 0;
            Dictionary<string, long> registers = new(){ {"a", 0}, {"b", 0}, {"c", 0 }, {"d", 0 }, {"e", 0 }, {"f", 0 }, {"g", 0 }, {"h", 0 } };
            for (long i = 0; i < _instructions.Length; i++)
            {
                var instruction = _instructions[i];
                var parts = instruction.Split(' ');
                var registerKey = parts[1];
                var registerAdjustment = parts.Length == 3 ? int.TryParse(parts[2], out int _) ? int.Parse(parts[2]) : AddOrGetRegister(ref registers, parts[2]) : 0;
                switch (parts[0])
                {
                    case "set":
                        SetRegister(ref registers, registerKey, registerAdjustment);
                        break;
                    case "sub":
                        SetRegister(ref registers, registerKey, AddOrGetRegister(ref registers, registerKey) - registerAdjustment);
                        break;
                    case "mul":
                        SetRegister(ref registers, registerKey, AddOrGetRegister(ref registers, registerKey) * registerAdjustment);
                        result++;
                        break;
                    case "jnz":
                        var registerValue = int.TryParse(registerKey, out int _) ? int.Parse(registerKey) : AddOrGetRegister(ref registers, registerKey);
                        if (registerValue != 0)
                        {
                            i += registerAdjustment - 1;
                        }
                        break;
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            long result = 0;
            Dictionary<string, long> registers = new() { { "a", 1 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 } };
            for (long i = 0; i < _instructions.Length; i++)
            {
                var instruction = _instructions[i];
                var parts = instruction.Split(' ');
                var registerKey = parts[1];
                var registerAdjustment = parts.Length == 3 ? int.TryParse(parts[2], out int _) ? int.Parse(parts[2]) : AddOrGetRegister(ref registers, parts[2]) : 0;
                switch (parts[0])
                {
                    case "set":
                        SetRegister(ref registers, registerKey, registerAdjustment);
                        break;
                    case "sub":
                        SetRegister(ref registers, registerKey, AddOrGetRegister(ref registers, registerKey) - registerAdjustment);
                        break;
                    case "mul":
                        SetRegister(ref registers, registerKey, AddOrGetRegister(ref registers, registerKey) * registerAdjustment);
                        result++;
                        break;
                    case "jnz":
                        var registerValue = int.TryParse(registerKey, out int _) ? int.Parse(registerKey) : AddOrGetRegister(ref registers, registerKey);
                        if (registerValue != 0)
                        {
                            i += registerAdjustment - 1;
                        }
                        break;
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        long AddOrGetRegister(ref Dictionary<string, long> registers, string registerKey)
        {
            if (registers.TryGetValue(registerKey, out long value))
            {
                return value;
            }
            else
            {
                registers.Add(registerKey, 0);
                return registers[registerKey];
            }
        }
        void SetRegister(ref Dictionary<string, long> registers, string registerKey, long value)
        {
            registers[registerKey] = value;
        }
        #endregion
    }
}
