using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using System.Diagnostics;

namespace AdventOfCode2017.Problems
{
    public class Day16 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        string _secondResult = string.Empty;
        string[] _instructions = [];
        char[] _programs = [];
        HashSet<string> _hashset = [];



        #endregion

        #region Properties

        public string FirstResult
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
        public Day16(string inputPath, char[] programs) 
        {
            _inputPath = inputPath;
            _programs = programs;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            _instructions = File.ReadAllText(_inputPath).Split(',');
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            _hashset.Add(string.Join(string.Empty, _programs));
            var instructionsCopy = _instructions.ToArray();
            ProcessInstructions();

            var result = string.Join(string.Empty, _programs);
            _hashset.Add(result);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            while (true)
            {

                ProcessInstructions();
                if (!_hashset.Add(string.Join(string.Empty, _programs)))
                    break;
            }
            var position = 1000000000 % _hashset.Count;
            var result = _hashset.ElementAt(position);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        void ProcessInstructions()
        {
            for (int i = 0; i < _instructions.Length; i++)
            {
                var instructionType = _instructions[i].First();
                var instructionValues = _instructions[i].Substring(1).Split('/');
                switch (instructionType)
                {
                    case 's':
                        _programs = ArrayHelperFunctions.ShiftBackwards(_programs, int.Parse(instructionValues.First().ToString()));
                        break;
                    case 'x':
                        _programs = ArrayHelperFunctions.SwapPositions(_programs, int.Parse(instructionValues.First()), int.Parse(instructionValues.Last()));
                        break;
                    case 'p':
                        _programs = ArrayHelperFunctions.SwapValues(_programs, instructionValues.First().First(), instructionValues.Last().Last());
                        break;
                }
            }
        }
        #endregion
    }
}
