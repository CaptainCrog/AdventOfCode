using System.Text.RegularExpressions;

namespace AdventOfCode2024.Problems
{
    public class Day17 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        string _output = string.Empty;
        ulong _secondResult = 0;
        ulong _instructionPointer = 0;
        ulong _registerA = 0;
        ulong _registerB = 0;
        ulong _registerC = 0;
        ulong[] _instructions = [];
        Dictionary<ulong, ulong> _comboOperands = new Dictionary<ulong, ulong>();
        Dictionary<ulong, ProgramFunction> _opcodes = new Dictionary<ulong, ProgramFunction>();
        delegate ulong ProgramFunction(ulong operand);
        ulong[] _reversedInstructions = [];


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


        public string FirstResult
        {
            get;
            set;
        }
        public ulong SecondResult
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
        public Day17(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            SolveFirstProblem<int>();
            FirstResult = _output;
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllText(_inputPath);
            var registersAndInstructions = Regex.Split(input, "Program");

            var registers = Regex.Matches(registersAndInstructions.First(), @"[A-Z]{1}\: [0-9]{1,}");
            _registerA = GetRegisterValue("A", registers);
            _registerB = GetRegisterValue("B", registers);
            _registerC = GetRegisterValue("C", registers);

            var instructionValues = Regex.Matches(registersAndInstructions.Last(), @"\d");
            var instructionValuesReversed = instructionValues;

            _reversedInstructions = new ulong[instructionValues.Count];
            int j = 0;
            for (int i = instructionValues.Count - 1; i >= 0; i--)
            {
                _reversedInstructions[j] = ulong.Parse(instructionValues[i].Value);
                j++;
            }

            _instructions = new ulong[instructionValues.Count];
            for (int i = 0; i < instructionValues.Count; i++)
            {
                _instructions[i] = ulong.Parse(instructionValues[i].Value);
            }

            ProgramFunction dv = DV;    //ADV && BDV && CDV
            ProgramFunction bxl = BXL;
            ProgramFunction bxc = BXC;
            ProgramFunction mod = MOD;  //BST && OUT
            ProgramFunction jnz = JNZ;


            _opcodes = new Dictionary<ulong, ProgramFunction>()
            {
                {0, dv},
                {1, bxl},
                {2, mod},
                {3, jnz},
                {4, bxc},
                {5, mod},
                {6, dv},
                {7, dv},
            };
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var result = ProcessProgram();
            _output = string.Join(",", Array.ConvertAll(result.ToArray(), x => x.ToString()));
            return (T)Convert.ChangeType(0, typeof(T));
        }


        public override T SolveSecondProblem<T>()
        {
            _output = string.Empty;
            var registerAReplacements = new List<ulong>() { 0 };

            for (int i = 0; i < _reversedInstructions.Length; i++) 
            {
                var registerAReplacementsTemp = new List<ulong>(); // temporary storage as we cant edit registerAReplacements when inside the foreach
                foreach (var replacement in registerAReplacements)
                {
                    for (ulong j = 0; j < 8; j++)
                    {
                        _instructionPointer = 0;
                        _registerA = replacement << 3;
                        _registerA += j;
                        var registerResult = ProcessProgram();
                        // take first element since we want to compare the current octal conversion to see if it matches with the reversed instruction
                        if (registerResult.First() == _reversedInstructions[i])
                        {
                            registerAReplacementsTemp.Add(_registerA);
                        }
                    }
                }
                registerAReplacements = registerAReplacementsTemp;
            }
            var result = registerAReplacements.Order().First();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        List<ulong> ProcessProgram()
        {
            _comboOperands = new Dictionary<ulong, ulong>()
                        {
                            {0, 0},
                            {1, 1},
                            {2, 2},
                            {3, 3},
                            {4, _registerA},
                            {5, _registerB},
                            {6, _registerC},
                        };

            List<ulong> output = new();
            bool processProgram = true;
            while (processProgram)
            {
                var opcode = _instructions[_instructionPointer];
                var opcodeFunction = _opcodes.GetValueOrDefault(opcode);
                var operand = _instructions[_instructionPointer + 1];

                var result = opcodeFunction.Invoke(operand);
                switch (opcode)
                {
                    case 0:
                        _comboOperands[4] = result;
                        _instructionPointer += 2;
                        break;
                    case 1:
                    case 2:
                    case 4:
                    case 6:
                        _comboOperands[5] = result;
                        _instructionPointer += 2;
                        break;
                    case 3:
                        if (_comboOperands[4] > 0)
                            _instructionPointer = result;
                        else
                            processProgram = false;
                        break;
                    case 5:
                        output.Add(result);
                        _instructionPointer += 2;
                        break;
                    case 7:
                        _comboOperands[6] = result;
                        _instructionPointer += 2;
                        break;
                }
            }

            return output;
        }

        ulong GetRegisterValue(string registerToFind, MatchCollection registers)
            => registers.Where(x => x.Value.Contains(registerToFind)).Select(x => ulong.Parse(x.Value.Substring(2))).FirstOrDefault();

        ulong DV(ulong comboOperand)
        {
            var comboOperandValue = _comboOperands.GetValueOrDefault(comboOperand);

            return (ulong)(_comboOperands[4] / Math.Pow(2, comboOperandValue));
        }

        ulong BXL(ulong literalOperand)
        {
            return _comboOperands[5] ^ literalOperand;
        }

        ulong BXC(ulong literalOperand)
        {
            return _comboOperands[5] ^ _comboOperands[6];
        }

        ulong MOD(ulong comboOperand)
        {
            var comboOperandValue = _comboOperands.GetValueOrDefault(comboOperand);

            return comboOperandValue % 8;
        }

        ulong JNZ(ulong literalOperand)
        {
            return literalOperand;
        }

        #endregion
    }
}
