using AdventOfCode2016.CommonInternalTypes;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public class Day12 : IDayBase
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
        protected  string InputPath
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
        public  void InitialiseProblem()
        {
            _instructions = File.ReadAllLines(_inputPath);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }


        public  T SolveFirstProblem<T>() where T : IConvertible
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
        public  T SolveSecondProblem<T>() where T : IConvertible
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
                        RegisterFunctions.Copy(instructionParts[1], instructionParts[2], ref _registers);
                        break;
                    case _jnz:
                        i = RegisterFunctions.Jump(instructionParts[1], int.Parse(instructionParts[2]), i, ref _registers);
                        break;
                    case _inc:
                        RegisterFunctions.Increase(instructionParts[1], ref _registers);
                        break;
                    case _dec:
                        RegisterFunctions.Decrease(instructionParts[1], ref _registers);
                        break;
                }

            }
        }
        #endregion
    }
}