using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode2024.CommonTypes.HelperFunctions.BinaryHelperFunctions;
using Microsoft.Win32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2024.Problems
{
    public class Day24 : DayBase
    {
        #region Fields

        string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\TestInputs\Day24\AdventOfCode2024Day24TestInput2.txt";
       //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day24PuzzleInput.txt";
        long _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        Dictionary<string, int> _wireValues = new(); 
        List<(string Input1, string Gate, string Input2, string Output)> _gates = new();

        const string AND = "AND";
        const string OR = "OR";
        const string XOR = "XOR";

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


        long FirstResult
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

        int Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day24()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            foreach (var line in input) 
            {
                if (line.Contains(':'))
                {
                    var parts = line.Split(':');
                    _wireValues[parts[0].Trim()] = int.Parse(parts[1].Trim());
                }
                else if (line.Contains(" -> "))
                {
                    var parts = line.Split(new[] { " -> " }, StringSplitOptions.None);
                    var gateParts = parts[0].Split(' ');
                    _gates.Add((gateParts[0], gateParts[1], gateParts[2], parts[1]));
                }
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            var gatesCopy = _gates.ToList();
            var wireValuesCopy = _wireValues.ToDictionary();

            var simulation = RunSimulation(gatesCopy, wireValuesCopy);

            // Combine results
            string binaryResult = string.Join("", simulation
                .Where(kvp => kvp.Key.StartsWith("z"))
                .OrderByDescending(kvp => int.Parse(kvp.Key.Substring(1)))
                .Select(kvp => kvp.Value.ToString()));

            long decimalResult = Convert.ToInt64(binaryResult, 2);

            return (T)Convert.ChangeType(decimalResult, typeof(T));
        }




        public override T SolveSecondProblem<T>()
        {
            Sum = 0;
            var gatesCopy = _gates.ToList();
            var wireValuesCopy = _wireValues.ToDictionary();

            // Find gates violating the rules
            var nxz = gatesCopy.Where(gate => gate.Output.StartsWith("z") && gate.Output != "z45" && gate.Gate != XOR).ToList();
            var xnz = gatesCopy.Where(gate => !gate.Input1.StartsWith("x") && !gate.Input1.StartsWith("y") &&
                                       !gate.Input2.StartsWith("x") && !gate.Input2.StartsWith("y") &&
                                       !gate.Output.StartsWith("z") && gate.Gate == XOR).ToList();

            // Perform swaps
            for (int i = 0; i < xnz.Count(); i++)
            {
                var gateCopy = gatesCopy[i];
                var matchingGate = nxz.First(gate => gate.Output == FirstZThatUsesC(gatesCopy, gateCopy.Output));
                var temp = gateCopy.Output;
                gateCopy.Output = matchingGate.Output;
                matchingGate.Output = temp;
            }


            string xBinaryResult = string.Join("", wireValuesCopy
                .Where(kvp => kvp.Key.StartsWith("x"))
                .OrderByDescending(kvp => int.Parse(kvp.Key.Substring(1)))
                .Select(kvp => kvp.Value.ToString()));

            string yBinaryResult = string.Join("", wireValuesCopy
                .Where(kvp => kvp.Key.StartsWith("y"))
                .OrderByDescending(kvp => int.Parse(kvp.Key.Substring(1)))
                .Select(kvp => kvp.Value.ToString()));

            long xDecimalResult = Convert.ToInt64(xBinaryResult, 2);
            long yDecimalResult = Convert.ToInt64(yBinaryResult, 2);




            var simulation = RunSimulation(gatesCopy, wireValuesCopy);


            string zBinaryResult = string.Join("", simulation
                .Where(kvp => kvp.Key.StartsWith("z"))
                .OrderByDescending(kvp => int.Parse(kvp.Key.Substring(1)))
                .Select(kvp => kvp.Value.ToString()));

            long zDecimalResult = Convert.ToInt64(zBinaryResult, 2);

            // Fix carry issue
            var falseCarry = CountTrailingZeroBits(xDecimalResult + yDecimalResult ^ zDecimalResult).ToString();
            var finalGates = nxz.Concat(xnz)
            .Concat(gatesCopy.Where(gate => gate.Input1.EndsWith(falseCarry) && gate.Input2.EndsWith(falseCarry)))
                .Select(gate => gate.Output)
                .OrderBy(output => output);


            return (T)Convert.ChangeType(Sum, typeof(T));
        }


        private Dictionary<string, int> RunSimulation(List<(string Input1, string Gate, string Input2, string Output)> gatesCopy, Dictionary<string, int> wireValuesCopy)
        {
            // Simulate the circuit
            while (gatesCopy.Count > 0)
            {
                foreach (var gate in gatesCopy.ToList())
                {
                    if (wireValuesCopy.ContainsKey(gate.Input1) && wireValuesCopy.ContainsKey(gate.Input2))
                    {
                        int value1 = wireValuesCopy[gate.Input1];
                        int value2 = wireValuesCopy[gate.Input2];
                        int outputValue = 0;
                        switch (gate.Gate)
                        {
                            case AND:
                                outputValue = value1 & value2;
                                break;
                            case OR:
                                outputValue = value1 | value2;
                                break;
                            case XOR:
                                outputValue = value1 ^ value2;
                                break;
                        }
                        wireValuesCopy[gate.Output] = outputValue;
                        gatesCopy.Remove(gate);
                    }
                }
            }

            return wireValuesCopy;
        }
        string FirstZThatUsesC(List<(string Input1, string Gate, string Input2, string Output)> gates, string c)
        {
            var dependentGates = gates.Where(gate => gate.Input1 == c || gate.Input2 == c).ToList();
            var firstZGate = dependentGates.FirstOrDefault(gate => gate.Output.StartsWith("z"));
            if (firstZGate.Input1 != null && firstZGate.Gate != null && firstZGate.Input2 != null && firstZGate.Output != null)
            {
                var result = firstZGate.Output;
                return result;
            }

            foreach (var gate in dependentGates)
            {
                var result = FirstZThatUsesC(gates, gate.Output);
                if (result != null) return result;
            }

            return null;
        }

        int CountTrailingZeroBits(long value)
        {
            int count = 0;
            while ((value & 1) == 0 && value != 0)
            {
                count++;
                value >>= 1;
            }
            return count;
        }
        #endregion
    }
}
