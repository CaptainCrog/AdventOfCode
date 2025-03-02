using AdventOfCode2016.CommonInternalTypes;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day23 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _initialRegisterValue = 0;
        string[] _instructions = [];
        Dictionary<string, int> _registers = new();
        const string _cpy = "cpy";
        const string _jnz = "jnz";
        const string _inc = "inc";
        const string _dec = "dec";
        const string _tgl = "tgl";


        #endregion

        #region Properties
        string InputPath
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
        public Day23(string inputPath, int initialRegisterValue)
        {
            _inputPath = inputPath;
            _initialRegisterValue = initialRegisterValue;
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


            _registers = new Dictionary<string, int>()
            {
                { "a", _initialRegisterValue },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 },
            };

            RunProgram();

            return (T)Convert.ChangeType(_registers["a"], typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            _registers = new Dictionary<string, int>()
            {
                { "a", 12 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 },
            };

            RunProgram();

            return (T)Convert.ChangeType(_registers["a"], typeof(T));
        }


        void RunProgram()
        {
            var instructionCopy = _instructions.ToArray();
            for (int i = 0; i < instructionCopy.Length; i++)
            {
                var instruction = instructionCopy[i];
                var instructionParts = instruction.Split(" ");
                var isNum = false;

                //Detect multiplication pattern
                if (i + 6 < instructionCopy.Length && RegisterFunctions.OptimizeMultiplication(i, instructionCopy, ref _registers, out int newI))
                {
                    i = newI; // Skip the multiplication loop
                    continue;
                }

                switch (instructionParts[0])
                {
                    case _cpy:
                        isNum = int.TryParse(instructionParts[2], out _);
                        if (isNum)
                            continue;
                        RegisterFunctions.Copy(instructionParts[1], instructionParts[2], ref _registers);
                        break;
                    case _jnz:
                        isNum = int.TryParse(instructionParts[2], out int jumpValue);
                        if (!isNum)
                            jumpValue = _registers[instructionParts[2]];
                        i = RegisterFunctions.Jump(instructionParts[1], jumpValue, i, ref _registers);
                        break;
                    case _inc:
                            RegisterFunctions.Increase(instructionParts[1], ref _registers);
                        break;
                    case _dec:
                        RegisterFunctions.Decrease(instructionParts[1], ref _registers);
                        break;
                    case _tgl:
                        RegisterFunctions.Toggle(instructionParts[1], i, ref instructionCopy, _registers);
                        break;

                }
            }
        }

        #endregion

    }
}