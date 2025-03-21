using AdventOfCode2017.CommonInternalTypes;
using CommonTypes.CommonTypes.ExtensionMethods;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using Microsoft.Win32;
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
            long lastPlayedFrequency = 0;
            var recovered = false;
            Dictionary<string, long> registers = [];
            for (long i = 0; i < _instructions.Length; i++)
            {
                var instruction = _instructions[i];
                var parts = instruction.Split(' ');
                var registerKey = parts[1];
                var registerAdjustment = parts.Length == 3 ? int.TryParse(parts[2], out int _) ? int.Parse(parts[2]) : AddOrGetRegister(ref registers, parts[2]) : 0;
                switch (parts[0])
                {
                    case "snd":
                        lastPlayedFrequency = AddOrGetRegister(ref registers, registerKey);
                        break;
                    case "set":
                        SetRegister(ref registers, registerKey, registerAdjustment);
                        break;
                    case "add":
                        SetRegister(ref registers, registerKey, AddOrGetRegister(ref registers, registerKey) + registerAdjustment);
                        break;
                    case "mul":
                        SetRegister(ref registers, registerKey, AddOrGetRegister(ref registers, registerKey) * registerAdjustment);
                        break;
                    case "mod":
                        SetRegister(ref registers, registerKey, AddOrGetRegister(ref registers, registerKey) % registerAdjustment);
                        break;
                    case "rcv":
                        if (AddOrGetRegister(ref registers, registerKey) > 0)
                            recovered = true;
                        break;
                    case "jgz":
                        var registerValue = int.TryParse(registerKey, out int _) ? int.Parse(registerKey) : AddOrGetRegister(ref registers, registerKey);
                        if (registerValue > 0)
                        {
                            i += registerAdjustment - 1;
                        }
                        break;
                }

                if (recovered)
                    break;
            }

            return (T)Convert.ChangeType(lastPlayedFrequency, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = 0;

            Queue<long> program0Bus = new();
            Queue<long> program1Bus = new();
            Queue<(long, long)> indexHistory = new();
            var program0Registers = new Dictionary<string, long>() { { "p", 0 } };
            var program1Registers = new Dictionary<string, long>() { { "p", 1 } };
            long lastInstructionIndexProgram0 = 0;
            long lastInstructionIndexProgram1 = 0;
            bool isProgram0 = true;
            bool hasSwapped = false;

            for (long i = 0; i < _instructions.Length; i++)
            {
                Dictionary<string, long> currentRegisters;
                Queue<long> currentBus;
                if (isProgram0)
                {
                    currentRegisters = program0Registers;
                    currentBus = program0Bus;
                    lastInstructionIndexProgram0 = i;
                }
                else
                {
                    currentRegisters = program1Registers;
                    currentBus = program1Bus;
                    lastInstructionIndexProgram1 = i;
                }

                var instruction = _instructions[i];
                var parts = instruction.Split(' ');
                var registerKey = parts[1];
                var registerAdjustment = parts.Length == 3 ? int.TryParse(parts[2], out int _) ? int.Parse(parts[2]) : AddOrGetRegister(ref currentRegisters, parts[2]) : 0;
                switch (parts[0])
                {
                    case "snd":
                        if (!long.TryParse(parts[1], out long value))
                            value = AddOrGetRegister(ref currentRegisters, registerKey);
                        if (isProgram0)
                            program1Bus.Enqueue(value);
                        else
                        {
                            program0Bus.Enqueue(value);
                            result++;
                        }
                        break;

                    case "set":
                        SetRegister(ref currentRegisters, registerKey, registerAdjustment);
                        break;

                    case "add":
                        SetRegister(ref currentRegisters, registerKey, AddOrGetRegister(ref currentRegisters, registerKey) + registerAdjustment);
                        break;

                    case "mul":
                        SetRegister(ref currentRegisters, registerKey, AddOrGetRegister(ref currentRegisters, registerKey) * registerAdjustment);
                        break;

                    case "mod":
                        SetRegister(ref currentRegisters, registerKey, AddOrGetRegister(ref currentRegisters, registerKey) % registerAdjustment);
                        break;

                    case "rcv":
                        if (currentBus.Count > 0)
                            SetRegister(ref currentRegisters, registerKey, currentBus.Dequeue());
                        else
                        {
                            if (indexHistory.Count == 3)
                                indexHistory.Dequeue();
                            i = isProgram0 ? lastInstructionIndexProgram1 : lastInstructionIndexProgram0;
                            i--;
                            isProgram0 = !isProgram0;
                            hasSwapped = true;
                            indexHistory.Enqueue((lastInstructionIndexProgram0, lastInstructionIndexProgram1));
                        }
                        break;

                    case "jgz":
                        var registerValue = int.TryParse(registerKey, out int _) ? int.Parse(registerKey) : AddOrGetRegister(ref currentRegisters, registerKey);
                        if (registerValue > 0)
                        {
                            i += registerAdjustment - 1;
                        }
                        break;
                }

                if (hasSwapped && program0Bus.Count() == 0 && program1Bus.Count() == 0 && indexHistory.Count == 3 && indexHistory.Distinct().Count() == 1)
                    break;
                hasSwapped = false;
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
