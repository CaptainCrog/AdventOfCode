using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Problems
{
    public partial class Day07 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        int _secondResult = 0;
        int _instructionTime = 0;
        int _sleighWorkerCount = 0;
        Dictionary<char, StepState> _stepState = new();
        Dictionary<char, List<char>> _stepRules = new();
        List<SleighWorker> _sleighWorkers = new();

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
        public Day07(string inputPath, int instructionTime, int sleighWorkerCount)
        {
            _inputPath = inputPath;
            _instructionTime = instructionTime;
            _sleighWorkerCount = sleighWorkerCount;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            var stepRegex = StepRegex();
            foreach (var line in input)
            {
                var matches = stepRegex.Matches(line);
                if (!_stepRules.TryAdd(matches.First().Value.Last(), new List<char>() { matches.Last().Value.Last() }))
                {
                    _stepRules[matches.First().Value.Last()].Add(matches.Last().Value.Last());
                }

                _stepState.TryAdd(matches.First().Value.Last(), StepState.Unavailable);
                _stepState.TryAdd(matches.Last().Value.Last(), StepState.Unavailable);
            }

            var initialSteps = _stepRules.Select(x => x.Key).ToList().Except(_stepRules.SelectMany(x => x.Value).ToList()).ToList();
            foreach (var step in initialSteps)
                _stepState[step] = StepState.Available;
        }


        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = string.Empty;
            var stepStateCopy = _stepState.ToDictionary();
            while (stepStateCopy.Any(x => x.Value != StepState.Complete))
            {
                var currentStep = stepStateCopy.Where(x => x.Value == StepState.Available).Select(x => x.Key).Order().First();
                stepStateCopy[currentStep] = StepState.Complete;
                result += currentStep;

                if (_stepRules.TryGetValue(currentStep, out var nextSteps))
                {
                    foreach (var nextStep in nextSteps)
                    {
                        var connectedStepStates = _stepRules.Where(x => x.Value.Contains(nextStep)).Select(xx => stepStateCopy[xx.Key]).ToList();

                        if (connectedStepStates.All(x => x == StepState.Complete))
                            stepStateCopy[nextStep] = StepState.Available;
                    }
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            int startTime = -1;
            for (int i = 0; i < _sleighWorkerCount; i ++)
            {
                _sleighWorkers.Add(new SleighWorker());
            }

            var stepStateCopy = _stepState.ToDictionary();
            while (stepStateCopy.Any(x => x.Value != StepState.Complete))
            {
                startTime++;
                var availableSteps = stepStateCopy.Where(x => x.Value == StepState.Available).Select(x => x.Key).ToList();
                var availableWorkers = _sleighWorkers.Where(x => x.AssignedChar == null).ToList();
                foreach (var availableStep in availableSteps) 
                {
                    
                }
            }

            return (T)Convert.ChangeType(0, typeof(T));
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        [GeneratedRegex(@"[sS]tep [A-Z]")]
        private static partial Regex StepRegex();

        enum StepState
        {
            Unavailable = 0,
            Available = 1,
            Complete = 2,
        }

        class SleighWorker
        {
            public char? AssignedChar { get; set; }
            public int InstructionTime { get; set; }

            public SleighWorker() 
            { 

            }
        }

        #endregion
    }
}
