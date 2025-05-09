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

        //Read in the inputs, order them chronologically ✅
        //Calculate each guards total time asleep in minutes
        //Store each shift as a separate time frame
        //Select guard with most time asleep
        //Find the best overlapping point where the guard will most likely be asleep

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
                    selectedGuard.Shifts.Add(new Shift(guardEvent.Key.Date));
                    selectedShift = selectedGuard.Shifts.Where(x => x.Date == guardEvent.Key.Date).Single();
                }
                else if (guardEvent.Value.Contains("falls"))
                {
                    selectedShift.ShiftPatterns.Add((guardEvent.Key.TimeOfDay, true));
                }
                else
                {
                    selectedShift.ShiftPatterns.Add((guardEvent.Key.TimeOfDay, false));
                }
            }



            return (T)Convert.ChangeType(0, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {

            return (T)Convert.ChangeType(0, typeof(T));
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
            public DateTime Date { get; set; }
            public List<(TimeSpan, bool)> ShiftPatterns { get; set; }

            public Shift(DateTime date)
            {
                Date = date;
                ShiftPatterns = new List<(TimeSpan, bool)>();
            }
        }
    }
}
