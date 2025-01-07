using CommonTypes.CommonTypes.Constants;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2015.Problems
{
    public partial class Day7 : DayBase
    {

        #region Fields
        string _inputPath = string.Empty;
        string _search = string.Empty;
        ushort _firstResult = 0;
        ushort _secondResult = 0;
        Dictionary<string, ushort> _wireValues;
        List<(string Input1, string Gate, string Input2, string Output)> _gates = new();


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

        public ushort FirstResult
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
        public ushort SecondResult
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
        public Day7(string inputPath, string search)
        {
            _inputPath = inputPath;
            _search = search;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<ushort>();
            SecondResult = SolveSecondProblem<ushort>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _gates = new();
            _wireValues = new();
            var input = File.ReadLines(_inputPath).ToArray();
            foreach (var line in input)
            {
                var parts = line.Split(new[] { " -> " }, StringSplitOptions.None);
                var gateParts = parts[0].Split(' ');
                if (ushort.TryParse(gateParts.First(), out ushort number))
                {
                    if (gateParts.Count() == 1)
                        _wireValues[parts[1].Trim()] = number;
                    else
                        _gates.Add((gateParts[0], gateParts[1], gateParts[2], parts[1]));
                }
                else if (gateParts.First() == BitwiseLogicConstants.NOT)
                {
                    _gates.Add((gateParts[1], gateParts[0], int.MaxValue.ToString(), parts[1]));
                }
                else if (gateParts.Count() == 1)
                {
                    _gates.Add((gateParts[0], string.Empty, int.MaxValue.ToString(), parts[1]));
                }
                else
                    _gates.Add((gateParts[0], gateParts[1], gateParts[2], parts[1]));
            }
        }

        public override T SolveFirstProblem<T>()
        {
            var ranWireCircuit = RunCircuit(_gates.ToList(), _wireValues.ToDictionary());
            var result = ranWireCircuit.Where(kvp => kvp.Key == "a").First().Value;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            _wireValues["b"] = FirstResult;
            var ranWireCircuit = RunCircuit(_gates.ToList(), _wireValues.ToDictionary());
            var result = ranWireCircuit.Where(kvp => kvp.Key == "a").First().Value;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        private Dictionary<string, ushort> RunCircuit(List<(string Input1, string Gate, string Input2, string Output)> gatesCopy, Dictionary<string, ushort> wireValuesCopy)
        {
            // Simulate the circuit
            while (gatesCopy.Count > 0)
            {
                foreach (var gate in gatesCopy.ToList())
                {
                    if ((wireValuesCopy.ContainsKey(gate.Input1) || int.TryParse(gate.Input1, out _)) && (wireValuesCopy.ContainsKey(gate.Input2) || int.TryParse(gate.Input2, out _)))
                    {

                        var value1 = ProcessGateInput(gate.Input1, wireValuesCopy);
                        var value2 = ProcessGateInput(gate.Input2, wireValuesCopy);

                        ushort outputValue;
                        switch (gate.Gate)
                        {
                            case BitwiseLogicConstants.AND:
                                outputValue = (ushort)(value1 & value2);
                                break;
                            case BitwiseLogicConstants.OR:
                                outputValue = (ushort)(value1 | value2);
                                break;
                            case BitwiseLogicConstants.XOR:
                                outputValue = (ushort)(value1 ^ value2);
                                break;
                            case BitwiseLogicConstants.LSHIFT:
                                outputValue = (ushort)(value1 << value2);
                                break;
                            case BitwiseLogicConstants.RSHIFT:
                                outputValue = (ushort)(value1 >> value2);
                                break;
                            case BitwiseLogicConstants.NOT:
                                outputValue = (ushort)~value1;
                                break;
                            default:
                                outputValue = value1;
                                break;
                        }
                        wireValuesCopy[gate.Output] = outputValue;
                        gatesCopy.Remove(gate);
                    }
                }
            }

            return wireValuesCopy;
        }


        ushort ProcessGateInput(string input, Dictionary<string, ushort> wireValuesCopy)
        {
            int.TryParse(input, out int valueInt);
            ushort.TryParse(input, out ushort value);
            if (value == 0 && valueInt != int.MaxValue)
                value = wireValuesCopy[input];

            return value;
        }
        #endregion

    }
}
