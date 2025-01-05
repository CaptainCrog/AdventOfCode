using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day5 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        List<string> _pageOrderingRules = new();
        List<string> _pagesToProduce = new();
        List<string> _invalidPages = new();
        Dictionary<int, List<int>> _groupedRules = new();
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;

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

        int Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }
        List<string> PageOrderingRules
        {
            get => _pageOrderingRules;
            set
            {
                if (_pageOrderingRules != value)
                {
                    _pageOrderingRules = value;
                }
            }
        }
        List<string> PagesToProduce
        {
            get => _pagesToProduce;
            set
            {
                if (_pagesToProduce != value)
                {
                    _pagesToProduce = value;
                }
            }
        }

        List<string> InvalidPages
        {
            get => _invalidPages;
            set
            {
                if (_invalidPages != value)
                {
                    _invalidPages = value;
                }
            }
        }
        Dictionary<int, List<int>> GroupedRules
        {
            get => _groupedRules;
            set
            {
                if (_groupedRules != value)
                {
                    _groupedRules = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day5(string inputPath)
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
            var rawInputData = File.ReadAllLines(_inputPath);
            PageOrderingRules = rawInputData.Where(x => x.Contains('|')).ToList();
            PagesToProduce = rawInputData.Where(x => x.Contains(',')).ToList();


            Regex keyRegex = new Regex(@"[0-9]{2}");
            Regex groupRegex = new Regex(@"\|[0-9]{2}");
            var allRules = new List<Match>();
            var ruleValues = PageOrderingRules.Select(rule => keyRegex.Match(rule).Value).Distinct().ToList();
            foreach (var rule in ruleValues)
            {
                var ruleGroup = PageOrderingRules.Where(x => x.Contains($"{rule}|")).ToList();
                var dictGroup = new List<int>();
                foreach (var value in ruleGroup)
                {
                    dictGroup.Add(int.Parse(groupRegex.Match(value).Value.Substring(1)));
                }
                GroupedRules.Add(int.Parse(rule), dictGroup);
            }

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            ProcessPages();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = 0;
            FixPages();
            return (T)Convert.ChangeType(Sum, typeof(T));
        }


        int ProcessPages()
        {
            foreach(var page in PagesToProduce)
            {
                var pageInvalid = false;
                var numbers = page.Split(',').Select(int.Parse).ToList();
                var middleNumber = numbers[numbers.Count / 2];
                for (int i = 0; i < numbers.Count; i++) 
                {
                    if (pageInvalid)
                        break;

                    GroupedRules.TryGetValue(numbers[i], out var group);
                    for (int j = i + 1; j < numbers.Count; j++)
                    {
                        if (group == null || !group.Contains(numbers[j]))
                        {
                            pageInvalid = true;
                            InvalidPages.Add(page);
                            break;
                        }
                    }
                }
                if (!pageInvalid)
                    Sum += middleNumber;
            }
            return Sum;
        }

        void FixPages()
        {
            foreach(var invalidPage in InvalidPages)
            {
                var numbers = invalidPage.Split(',').Select(int.Parse).ToList();
                var allPageGroups = GroupedRules.Where(x => numbers.Contains(x.Key));
                var numberCorrectPositions = new List<(int number, int corrrectPosition)>();
                var fixedPage = new List<int>();
                for (int i = 0; i < numbers.Count; i++)
                {
                    var groups = allPageGroups.Select(x => x.Value).ToList();
                    var numberCorrectPosition = -1; //Start off negative as each iteration will ammend the position by 1
                    foreach (var group in groups)
                    {
                        if (group.Contains(numbers[i]))
                            numberCorrectPosition++;
                    }

                    numberCorrectPositions.Add((numbers[i], numberCorrectPosition));
                }
                foreach (var fix in numberCorrectPositions.OrderByDescending(x => x.corrrectPosition))
                {
                    fixedPage.Add(fix.number);
                }
                Sum += fixedPage[fixedPage.Count / 2];
            }
        }

        #endregion
    }
}
