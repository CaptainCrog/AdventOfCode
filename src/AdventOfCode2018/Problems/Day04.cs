using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018.Problems
{
    public class Day04 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        Dictionary<DateTime, string> _orderedEventsDictionary = [];
        int _firstResult = 0;
        int _secondResult = 0;
        List<Guard> _guards = [];
        Regex numberRegex = CommonRegexHelpers.PositiveNumberRegex();
        #endregion

        #region Properties
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
        public Day04(string inputPath)
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
            var input = File.ReadAllLines(_inputPath);
            foreach (var line in input)
            {
                var matches = numberRegex.Matches(line);
                _orderedEventsDictionary.Add(new DateTime(int.Parse(matches[0].Value), int.Parse(matches[1].Value), int.Parse(matches[2].Value), int.Parse(matches[3].Value), int.Parse(matches[4].Value), 0), line.Split("] ").Last());
            }
            _orderedEventsDictionary = _orderedEventsDictionary.OrderBy(x => x.Key).ToDictionary();
            //var temp = new DateTime(1518,11,01, 0,5)
        }

        //Read in the inputs, order them chronologically
        //Store each minute the guard is asleep in a given shift
        //Calculate and select guard with most time asleep
        //Group by the minutes spent asleep and select the minute with the most time asleep

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            Guard selectedGuard = null;
            Shift selectedShift = null;
            foreach (var guardEvent in _orderedEventsDictionary)
            {
                if (guardEvent.Value.Contains("Guard"))
                {
                    var guardId = int.Parse(numberRegex.Match(guardEvent.Value).Value);
                    if (!_guards.Any(x => x.Id == guardId))
                        _guards.Add(new Guard(guardId));

                    selectedGuard = _guards.Where(x => x.Id == guardId).Single();
                    selectedGuard.Shifts.Add(new Shift(guardEvent.Key));
                    selectedShift = selectedGuard.Shifts.Where(x => x.ShiftStart == guardEvent.Key).Single();
                }
                else if (guardEvent.Value.Contains("falls"))
                {
                    selectedShift.ShiftPatterns.Add((guardEvent.Key, true));
                }
                else
                {
                    var asleepStart = selectedShift.ShiftPatterns.Last().Item1.Minute;
                    for (int i = asleepStart; i < guardEvent.Key.Minute; i++)
                    {
                        selectedShift.MinutesAsleep.Add(i);
                    }
                    selectedShift.ShiftPatterns.Add((guardEvent.Key, false));
                }
            }
            var longestGuardAsleep = _guards.Where(x => x.Id == _guards.ToDictionary(g => g.Id, g => g.Shifts.SelectMany(s => s.MinutesAsleep).Count()).MaxBy(x => x.Value).Key).First();
            var mostCommonMinute = longestGuardAsleep.Shifts.SelectMany(s => s.MinutesAsleep).GroupBy(m => m).OrderByDescending(x => x.Count()).First();


            var result = mostCommonMinute.Key * longestGuardAsleep.Id;


            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var guardSleepDictionary = _guards.ToDictionary(g => g.Id, g => g.Shifts.SelectMany(s => s.MinutesAsleep).GroupBy(m => m).ToDictionary(x => x.Key, x => x.Count()));
            var guardsLongestSleepMinute = guardSleepDictionary.Where(x => x.Value.Values.Count > 0).Select(x => x.Value.OrderByDescending(xx => xx.Value).Select(xx => (x.Key, xx.Key, xx.Value)).First()).ToList();
            var result = guardsLongestSleepMinute.OrderByDescending(x => x.Item3).Select(xx => xx.Item1 * xx.Item2).First();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion

        class Guard
        {
            public int Id { get; set; }
            public List<Shift> Shifts { get; set; }

            public Guard(int id) 
            {
                Id = id;
                Shifts = new List<Shift>();
            }
        }

        class Shift
        {
            public DateTime ShiftStart { get; set; }
            public List<(DateTime, bool)> ShiftPatterns { get; set; }
            public List<int> MinutesAsleep { get; set; }

            public Shift(DateTime shiftStart)
            {
                ShiftStart = shiftStart;
                ShiftPatterns = new List<(DateTime, bool)>();
                MinutesAsleep = new List<int>();
            }
        }
    }
}
