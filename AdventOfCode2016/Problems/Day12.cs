using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Constants;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Regex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day12 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string[] _instructions = [];
        Dictionary<string, int> _registers = new();
        const string _cpy = "cpy";
        const string _jnz = "jnz";
        const string _inc = "inc";
        const string _dec = "dec";

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
        public Result<int> FirstResult
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
        public Result<int> SecondResult
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
        public Day12(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _instructions = File.ReadAllLines(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult.ResultValue}");
            Console.WriteLine($"Second Solution is: {SecondResult.ResultValue}");
        }


        public override T SolveFirstProblem<T>()
        {

            _registers = new Dictionary<string, int>()
            {
                { "a", 0 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 },
            };

            RunProgram();
           
            var result = _registers["a"];
            return (T)Convert.ChangeType(result, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            _registers = new Dictionary<string, int>()
            {
                { "a", 0 },
                { "b", 0 },
                { "c", 1 },
                { "d", 0 },
            };

            RunProgram();

            var result = _registers["a"];
            return (T)Convert.ChangeType(result, typeof(T));
        }

        void RunProgram()
        {
            for (int i = 0; i < _instructions.Length; i++)
            {
                var instruction = _instructions[i];
                var instructionParts = instruction.Split(" ");
                switch (instructionParts[0])
                {
                    case _cpy:
                        Copy(instructionParts[1], instructionParts[2]);
                        break;
                    case _jnz:
                        i = Jump(instructionParts[1], int.Parse(instructionParts[2]), i);
                        break;
                    case _inc:
                        Increase(instructionParts[1]);
                        break;
                    case _dec:
                        Decrease(instructionParts[1]);
                        break;
                }

            }
        }

        void Copy(string copy, string register)
        {
            if (int.TryParse(copy, out int copyValue))
                _registers[register] = copyValue;
            else
            {
                copyValue = _registers[copy];
                _registers[register] = copyValue;
            }
        }

        void Increase(string register)
        {
            _registers[register]++;
        }

        void Decrease(string register) 
        {
            _registers[register]--;
        }

        int Jump(string register, int jumpMovement, int currentIndex)
        {
            if (!int.TryParse(register, out int value))
            {
                if (_registers[register] == 0)
                    return currentIndex;
                else
                    return currentIndex + jumpMovement - 1;
            }
            else
            {
                if (value == 0)
                    return currentIndex;
                else
                    return currentIndex + jumpMovement - 1;
            }
        }
        #endregion
    }
}