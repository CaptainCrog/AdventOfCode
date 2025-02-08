using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day15 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _time = 0;
        List<Disc> _discs = new();

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
        public Day15(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            var numberRegex = CommonRegexHelpers.NumberRegex();
            foreach (var disc in input) 
            {
                var numbers = numberRegex.Matches(disc);
                _discs.Add(new Disc() 
                {
                    DiscId = int.Parse(numbers[0].Value), 
                    Divisions = int.Parse(numbers[1].Value), 
                    CurrentDivisionPosition = int.Parse(numbers[3].Value) 
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
            var currentDiscConfiguration = new List<Disc>();
            foreach (var disc in _discs)
            {
                currentDiscConfiguration.Add((Disc)disc.Clone());
            }

            _time = 0;
            while (true)
            {
                var currentTime = _time;
                var success = PressButton(currentTime, currentDiscConfiguration);
                if (success)
                    break;
                _time++;
                foreach (var disc in currentDiscConfiguration)
                {
                    disc.MoveDisc();
                }
            }

            return (T)Convert.ChangeType(_time, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            var currentDiscConfiguration = new List<Disc>();
            foreach (var disc in _discs)
            {
                currentDiscConfiguration.Add((Disc)disc.Clone());
            }
            currentDiscConfiguration.Add(new Disc() { DiscId = currentDiscConfiguration.Count + 1, CurrentDivisionPosition = 0, Divisions = 11 });

            _time = 0;
            while (true)
            {
                var currentTime = _time;
                var success = PressButton(currentTime, currentDiscConfiguration);
                if (success)
                    break;
                _time++;
                foreach (var disc in currentDiscConfiguration)
                {
                    disc.MoveDisc();
                }
            }


            return (T)Convert.ChangeType(_time, typeof(T));
        }

        bool PressButton(int currentTime, List<Disc> currentDiscConfiguration)
        {
            var discs = new List<Disc>();
            foreach (var disc in currentDiscConfiguration)
            {
                discs.Add((Disc)disc.Clone());
            }

            var isValid = true;

            var capsule = new Capsule() { NextDiscId = 1 };
            while (true)
            {
                isValid = CheckDisc(capsule, discs.ToArray(), ref currentTime);
                if (!isValid)
                    return false;
                else if (capsule.NextDiscId > discs.Count())
                    return true;
            }
        }

        bool CheckDisc(Capsule capsule, Disc[] discs, ref int currentTime)
        {
            foreach (var disc in discs)
            {
                disc.MoveDisc();
            }
            currentTime++;


            if (discs.Where(x => x.DiscId == capsule.NextDiscId).Single().CurrentDivisionPosition != 0)
                return false;

            capsule.NextDiscId++;

            return true;
        }

        //https://regex101.com/r/w1JsoH/1
        [GeneratedRegex(@"(.)\1{4}")]
        private static partial Regex CharSequentialOccurrences5Times();


        //https://regex101.com/r/w1JsoH/1
        [GeneratedRegex(@"(.)\1{2}")]
        private static partial Regex CharSequentialOccurrences3Times();
        #endregion

        class Disc : ICloneable
        {
            public int DiscId { get; init; }
            public int Divisions { get; init; }
            public int CurrentDivisionPosition { get; set; }
            public Disc() { }

            public void MoveDisc()
            {
                CurrentDivisionPosition++;
                if (CurrentDivisionPosition == Divisions)
                    CurrentDivisionPosition = 0;
            }

            public object Clone()
            {
                
                return new Disc()
                {
                    DiscId = this.DiscId,
                    Divisions = this.Divisions,
                    CurrentDivisionPosition = this.CurrentDivisionPosition
                };
            }
        }

        class Capsule
        {
            public int NextDiscId { get; set; }
            public Capsule() { }
        }

    }
}