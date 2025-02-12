using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2015.Problems
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
            var result = RunProgram(0, 0);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = RunProgram(1, 0);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        uint RunProgram(uint registerA, uint registerB)
        {
            var programFinished = false;
            var iter = 0;

            while (true)
            {

                if (programFinished)
                    break;

                var instruction = _instructions[iter];
                var parts = instruction.Split(' ');
                var isRegisterA = parts[1].Contains('a');
                var isRegisterB = parts[1].Contains('b');

                uint register = 0;
                if (isRegisterA)
                    register = registerA;
                else if (isRegisterB)
                    register = registerB;

                int newIndex;
                switch (parts[0])
                {
                    case "hlf":
                        register = Hlf(register);
                        iter++;
                        break;
                    case "tpl":
                        register = Tpl(register);
                        iter++;
                        break;
                    case "inc":
                        register = Inc(register);
                        iter++;
                        break;
                    case "jmp":
                        newIndex = Jmp(iter, int.Parse(parts[1]));
                        if (newIndex >= _instructions.Length)
                            programFinished = true;
                        else
                            iter = newIndex;
                        break;
                    case "jie":
                        newIndex = Jie(iter, register, int.Parse(parts[2]));
                        if (newIndex >= _instructions.Length)
                            programFinished = true;
                        else
                            iter = newIndex;
                        break;
                    case "jio":
                        newIndex = Jio(iter, register, int.Parse(parts[2]));
                        if (newIndex >= _instructions.Length)
                            programFinished = true;
                        else
                            iter = newIndex;
                        break;
                }


                if (isRegisterA)
                    registerA = register;
                else if (isRegisterB)
                    registerB = register;
            }

            return registerB;
        }

        uint Hlf(uint register)
            => register / 2;

        uint Tpl(uint register)
            => register * 3;

        uint Inc(uint register)
            => ++register;

        int Jmp(int instructionIndex, int offset)
            => instructionIndex + offset;

        int Jie(int instructionIndex, uint register, int offset)
        {
            if (register % 2 != 0)
                return ++instructionIndex;

            return instructionIndex + offset;
        }

        int Jio(int instructionIndex, uint register, int offset)
        {
            if (register != 1)
                return ++instructionIndex;

            return instructionIndex + offset;
        }

        #endregion
    }
}
