using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Constants;
using CommonTypes.CommonTypes.Regex;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public class Day10 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        (int comparatorValue1, int comparatorValue2) _comparator = (0, 0);
        string[] _botInstructions = [];
        List<Bot> _bots = new();
        Dictionary<int, Output> _outputs = new();
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();

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
        public Result<int> FirstResult
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
        public Result<int> SecondResult
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
        public Day10(string inputPath, (int comparatorValue1, int comparatorValue2) comparator)
        {
            _inputPath = inputPath;
            _comparator = comparator;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var instructions = File.ReadAllLines(_inputPath);
            _botInstructions = instructions.Where(x => x.StartsWith("bot")).ToArray();
            var valueInstructions = instructions.Where(x => x.StartsWith("value")).ToArray();
            foreach ( var botInstruction in _botInstructions) 
            {
                var numbers = _numberRegex.Matches(botInstruction);
                var bot = new Bot()
                {
                    Id = int.Parse(numbers[0].Value),
                    PassLowValueTo = int.Parse(numbers[1].Value),
                    LowValueIsOutput = botInstruction.Contains("low to output"),
                    PassHighValueTo = int.Parse(numbers[2].Value),
                    HighValueIsOutput = botInstruction.Contains("high to output"),
                    CarriedNumbers = new int[2],
                };
                if (bot.HighValueIsOutput)
                {
                    _outputs.TryAdd(bot.PassHighValueTo, new Output(bot.PassHighValueTo));
                }
                if (bot.LowValueIsOutput)
                {
                    _outputs.TryAdd(bot.PassLowValueTo, new Output(bot.PassLowValueTo));
                }

                _bots.Add(bot);
            }
            foreach ( var valueInstruction in valueInstructions)
            {
                var numbers = _numberRegex.Matches(valueInstruction);
                var bot = _bots.Where(x => x.Id == int.Parse(numbers[1].Value)).Single();
                if (bot.CarriedNumbers[0] == 0)
                    bot.CarriedNumbers[0] = int.Parse(numbers[0].Value);
                else
                    bot.CarriedNumbers[1] = int.Parse(numbers[0].Value);

            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult.ResultValue}");
            Console.WriteLine($"Second Solution is: {SecondResult.ResultValue}");
        }

        public override T SolveFirstProblem<T>()
        {
            var resultBot = 0;
            while (_bots.Count() > 0 )
            {
                var botsCopy = _bots.ToArray();
                foreach ( var bot in botsCopy)
                {
                    if (bot.CarriedNumbers[0] != 0 && bot.CarriedNumbers[1] != 0)
                    {
                        ProcessBot(bot, botsCopy, ref resultBot);
                    }
                }
            }

            return (T)Convert.ChangeType(resultBot, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            var allRequiredOutputs = _outputs.Where(x => x.Key == 0 || x.Key == 1 || x.Key == 2 ).Select(x => x.Value.CarriedNumbers.First()).ToList();
            var result = allRequiredOutputs[0] * allRequiredOutputs[1] * allRequiredOutputs[2]; 


            return (T)Convert.ChangeType(result, typeof(T));
        }

        void ProcessBot(Bot bot, Bot[] botsCopy, ref int resultBot)
        {
            var min = bot.CarriedNumbers.Min();
            var max = bot.CarriedNumbers.Max();
            if ((min == _comparator.comparatorValue1 && max == _comparator.comparatorValue2) || (min == _comparator.comparatorValue2 && max == _comparator.comparatorValue1))
            {
                resultBot = bot.Id;
            }


            if (bot.LowValueIsOutput)
            {
                _outputs[bot.PassLowValueTo].CarriedNumbers.Add(min);
            }
            else
            {
                var lowBot = botsCopy.Where(x => x.Id == bot.PassLowValueTo).Single();
                if (lowBot.CarriedNumbers[0] == 0)
                    lowBot.CarriedNumbers[0] = min;
                else
                    lowBot.CarriedNumbers[1] = min;
            }

            if (bot.HighValueIsOutput)
            {
                _outputs[bot.PassHighValueTo].CarriedNumbers.Add(max);
            }
            else
            {
                var highBot = botsCopy.Where(x => x.Id == bot.PassHighValueTo).Single();
                if (highBot.CarriedNumbers[0] == 0)
                    highBot.CarriedNumbers[0] = max;
                else
                    highBot.CarriedNumbers[1] = max;
            }

            bot.CarriedNumbers = new int[2];
            _bots.Remove(_bots.Where(x => x.Id == bot.Id).Single());
        }

        class Bot
        {
            public int Id { get; init; }
            public int PassLowValueTo { get; init; }
            public int PassHighValueTo { get; init; }
            public bool LowValueIsOutput { get; init; }
            public bool HighValueIsOutput { get; init; }
            public int[]? CarriedNumbers { get; set; }
        }

        class Output
        {
            public int Id { get; init; }
            public List<int> CarriedNumbers { get; set; }

            public Output(int id)
            {
                Id = id;
                CarriedNumbers = new List<int>();
            }

        }
        #endregion
    }
}