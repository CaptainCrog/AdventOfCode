﻿namespace AdventOfCode2024.Problems
{
    public class Day24 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        string[] _gatesInput = [];
        long _firstResult = 0;
        string _lastZOutput = string.Empty;
        string _secondResult = string.Empty;
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


        public long FirstResult
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
        public Day24(string inputPath, string lastZOutput)
        {
            _inputPath = inputPath;
            _lastZOutput = lastZOutput;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _gatesInput = File.ReadAllLines(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            _gates = new();
            _wireValues = new();
            foreach (var line in _gatesInput)
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

            var simulation = RunSimulation(_gates, _wireValues);

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
            _gates = new();
            foreach (var line in _gatesInput)
            {
                if (line.Contains(" -> "))
                {
                    var parts = line.Split(new[] { " -> " }, StringSplitOptions.None);
                    var gateParts = parts[0].Split(' ');
                    // re-organise x and y inputs to ensure x variables are INPUT 1 and y variables are INPUT 2
                    _gates.Add((string.Compare(gateParts[0], gateParts[2], StringComparison.Ordinal) < 0 ? gateParts[0] : gateParts[2], 
                        gateParts[1],
                        string.Compare(gateParts[0], gateParts[2], StringComparison.Ordinal) > 0 ? gateParts[0] : gateParts[2], 
                        parts[1]));
                }
            }


            // Find gates violating the rules
            var rule1Violations = _gates.Where(gate => gate.Output.StartsWith("z") && gate.Output != _lastZOutput && gate.Gate != XOR).Select(x => x.Output).ToList();
            var rule2Violations = _gates.Where(gate => !gate.Input1.StartsWith("x") && !gate.Output.StartsWith("z") && gate.Gate == XOR).Select(x => x.Output).ToList();
            var rule3Violations = new List<string>();
            _gates.ForEach(gate =>
            {
                if (gate.Gate == AND && gate.Input1 != "x00")
                {
                    var filter = _gates.Where(g => g.Input1 == gate.Output || g.Input2 == gate.Output).ToList();
                    foreach (var item in filter)
                    {
                        if (item.Gate != OR)
                        {
                            rule3Violations.Add(gate.Output);
                            break;
                        }
                    }
                }
            });
            var rule4Violations = new List<string>();
            _gates.ForEach(gate =>
            {
                if (gate.Gate == OR)
                {
                    var inputFilter = _gates.SingleOrDefault(g => g.Output == gate.Input1);
                    if (inputFilter.Output != null && inputFilter.Gate != AND)
                    {
                        rule4Violations.Add(inputFilter.Output);
                    }

                    inputFilter = _gates.SingleOrDefault(g => g.Output == gate.Input2);
                    if (inputFilter.Output != null && inputFilter.Gate != AND)
                    {
                        rule4Violations.Add(inputFilter.Output);
                    }
                }
            });
            var allViolations = rule1Violations.Concat(rule2Violations).Concat(rule3Violations).Concat(rule4Violations);
            var distinctViolations = allViolations.Distinct().ToList();
            distinctViolations.Sort();

            SecondResult = string.Join(',', distinctViolations);

            return (T)Convert.ChangeType(0, typeof(T));
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
        #endregion
    }
}
