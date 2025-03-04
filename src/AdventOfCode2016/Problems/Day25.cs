using AdventOfCode2016.CommonInternalTypes;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day25 : IDayBase
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
        const string _out = "out";
        string _clockSignal = string.Empty;



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
        public Day25(string inputPath)
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
            int iterator = 0;
            var isValid = false;

            while (!isValid)
            {
                _registers = new Dictionary<string, int>()
                {
                    { "a", iterator },
                    { "b", 0 },
                    { "c", 0 },
                    { "d", 0 },
                };

                isValid = RunProgram();
                if (isValid)
                    break;
                iterator++;
            }


            return (T)Convert.ChangeType(iterator, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }


        bool RunProgram()
        {
            _clockSignal = string.Empty;
            var instructionCopy = _instructions.ToArray();
            for (int i = 0; i < instructionCopy.Length; i++)
            {
                var instruction = instructionCopy[i];
                var instructionParts = instruction.Split(" ");
                var isNum = false;
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
                    case _out:

                        var isValid = RegisterFunctions.Output(instructionParts[1], ref _clockSignal, _registers);
                        if (!isValid)
                            return false;

                        if (_clockSignal.Length >= 10)
                            return true;
                        break;

                }
            }

            return true;
        }

        #endregion

    }
}