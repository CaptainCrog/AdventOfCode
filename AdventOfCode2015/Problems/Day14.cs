using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Regex;

namespace AdventOfCode2015.Problems
{
    public partial class Day14 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _raceTime = 0;
        List<int> _reindeerFinalDistances = new();
        List<Reindeer> _reindeers = new();

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
        public Day14(string inputPath, int raceTime)
        {
            _inputPath = inputPath;
            _raceTime = raceTime;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllLines(InputPath);
            var regex = CommonRegexHelpers.NumberRegex();
            foreach (var line in input)
            {
                var matches = regex.Matches(line);
                var speed = int.Parse(matches[0].Value);
                var runningTime = int.Parse(matches[1].Value);
                var restingTime = int.Parse(matches[2].Value);

                _reindeers.Add(new Reindeer(speed, runningTime, restingTime)
                {
                    TimeLeftRunning = runningTime,
                    TimeLeftResting = restingTime,
                    TraversedDistance = 0,
                    IsResting = false
                });
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            _reindeerFinalDistances = new();
            foreach (var reindeer in _reindeers)
            {
                var totalRunningCycles = _raceTime / reindeer.TotalTimePerRun;
                var totalDistanceTraversed = totalRunningCycles * reindeer.TotalRunDistance;

                var leftOverTime = _raceTime % reindeer.TotalTimePerRun;
                int iter = 0;

                while (iter < reindeer.RunningTime)
                {
                    if (iter >= leftOverTime)
                        break;
                    totalDistanceTraversed += reindeer.Speed;
                    iter++;
                }

                _reindeerFinalDistances.Add(totalDistanceTraversed);
            }
            var result = _reindeerFinalDistances.OrderDescending().First();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            _reindeerFinalDistances = new();
            int iter = 0;

            while (iter < _raceTime)
            {
                _reindeers.ForEach(x =>
                {
                    if (x.TimeLeftRunning == 0)
                    {
                        x.IsResting = true;
                        x.TimeLeftRunning = x.RunningTime;
                    }
                    else if (x.TimeLeftResting == 0)
                    {
                        x.IsResting = false;
                        x.TimeLeftResting = x.RestingTime;
                    }

                    if (x.IsResting)
                        x.TimeLeftResting--;
                    else
                    {
                        x.TimeLeftRunning--;
                        x.TraversedDistance += x.Speed;
                    }
                });

                var currentBestDistance = _reindeers.OrderByDescending(x => x.TraversedDistance).First().TraversedDistance;
                _reindeers.Where(x => x.TraversedDistance == currentBestDistance).ToList().ForEach(x => x.LeadingPoints++);
                iter++;
            }

            foreach (var reindeer in _reindeers)
            {
                _reindeerFinalDistances.Add(reindeer.LeadingPoints);
            }
            var result = _reindeerFinalDistances.OrderDescending().First();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        #endregion

    }

    internal class Reindeer
    {
        public int Speed { get; init; }
        public int RunningTime { get; init; }
        public int RestingTime { get; init; }
        public bool IsResting { get; set; }

        public int TotalTimePerRun { get => RunningTime + RestingTime; }
        public int TotalRunDistance { get => RunningTime * Speed; }

        public int TraversedDistance { get; set; }
        public int TimeLeftRunning { get; set; }
        public int TimeLeftResting { get; set; }
        public int LeadingPoints { get; set; }

        internal Reindeer(int speed, int runningTime, int restingTime)
        {
            Speed = speed;
            RunningTime = runningTime;
            RestingTime = restingTime;
        }
    }
}
