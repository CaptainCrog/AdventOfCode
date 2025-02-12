using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public partial class Day16 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Regex _sueRegex;
        Regex _childrenRegex;
        Regex _catsRegex;
        Regex _samoyedsRegex;
        Regex _pomeraniansRegex;
        Regex _akitasRegex;
        Regex _vizslasRegex;
        Regex _goldfishRegex;
        Regex _treesRegex;
        Regex _carsRegex;
        Regex _perfumesRegex;
        List<AuntSue> _auntSues = new();
        AuntSue _sueToSearch = new AuntSue()
        {
            SueId = int.MaxValue,
            ChildrenCount = 3,
            CatsCount = 7,
            SamoyedsCount = 2,
            PomeraniansCount = 3,
            AkitasCount = 0,
            VizslasCount = 0,
            GoldfishCount = 5,
            TreesCount = 3,
            CarsCount = 2,
            PerfumesCount = 1,
        };

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
        public Day16(string inputPath)
        {
            _inputPath = inputPath;

            _sueRegex = SueRegex();
            _childrenRegex = ChildrenRegex();
            _catsRegex = CatsRegex();
            _samoyedsRegex = SamoyedsRegex();
            _pomeraniansRegex = PomeraniansRegex();
            _akitasRegex = AkitasRegex();
            _vizslasRegex = VizslasRegex();
            _goldfishRegex = GoldfishRegex();
            _treesRegex = TreesRegex();
            _carsRegex = CarsRegex();
            _perfumesRegex = PerfumesRegex();

            InitialiseProblem();
            SolveBothProblems();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            var aunts = File.ReadAllLines(InputPath);
            foreach (var aunt in aunts)
            {
                CreateAuntSue(aunt);
            }
        }

        void SolveBothProblems()
        {
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var childrenFilter = _auntSues.Where(x => x.ChildrenCount == _sueToSearch.ChildrenCount || !x.ChildrenCount.HasValue).Select(x => x.SueId).ToList();
            var catFilter = _auntSues.Where(x => x.CatsCount == _sueToSearch.CatsCount || !x.CatsCount.HasValue).Select(x => x.SueId).ToList();
            var samoyedFilter = _auntSues.Where(x => x.SamoyedsCount == _sueToSearch.SamoyedsCount || !x.SamoyedsCount.HasValue).Select(x => x.SueId).ToList();
            var pomeranianFilter = _auntSues.Where(x => x.PomeraniansCount == _sueToSearch.PomeraniansCount || !x.PomeraniansCount.HasValue).Select(x => x.SueId).ToList();
            var akitaFilter = _auntSues.Where(x => x.AkitasCount == _sueToSearch.AkitasCount || !x.AkitasCount.HasValue).Select(x => x.SueId).ToList();
            var vizslasFilter = _auntSues.Where(x => x.VizslasCount == _sueToSearch.VizslasCount || !x.VizslasCount.HasValue).Select(x => x.SueId).ToList();
            var goldfishFilter = _auntSues.Where(x => x.GoldfishCount == _sueToSearch.GoldfishCount || !x.GoldfishCount.HasValue).Select(x => x.SueId).ToList();
            var treeFilter = _auntSues.Where(x => x.TreesCount == _sueToSearch.TreesCount || !x.TreesCount.HasValue).Select(x => x.SueId).ToList();
            var carsFilter = _auntSues.Where(x => x.CarsCount == _sueToSearch.CarsCount || !x.CarsCount.HasValue).Select(x => x.SueId).ToList();
            var perfumeFilter = _auntSues.Where(x => x.PerfumesCount == _sueToSearch.PerfumesCount || !x.PerfumesCount.HasValue).Select(x => x.SueId).ToList();


            var result = childrenFilter.Intersect(catFilter)
                                       .Intersect(samoyedFilter)
                                       .Intersect(pomeranianFilter)
                                       .Intersect(akitaFilter)
                                       .Intersect(vizslasFilter)
                                       .Intersect(goldfishFilter)
                                       .Intersect(treeFilter)
                                       .Intersect(carsFilter)
                                       .Intersect(perfumeFilter).ToList();

            return (T)Convert.ChangeType(result.Single(), typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {

            var childrenFilter = _auntSues.Where(x => x.ChildrenCount == _sueToSearch.ChildrenCount || !x.ChildrenCount.HasValue).Select(x => x.SueId).ToList();
            var catFilter = _auntSues.Where(x => x.CatsCount > _sueToSearch.CatsCount || !x.CatsCount.HasValue).Select(x => x.SueId).ToList();
            var samoyedFilter = _auntSues.Where(x => x.SamoyedsCount == _sueToSearch.SamoyedsCount || !x.SamoyedsCount.HasValue).Select(x => x.SueId).ToList();
            var pomeranianFilter = _auntSues.Where(x => x.PomeraniansCount < _sueToSearch.PomeraniansCount || !x.PomeraniansCount.HasValue).Select(x => x.SueId).ToList();
            var akitaFilter = _auntSues.Where(x => x.AkitasCount == _sueToSearch.AkitasCount || !x.AkitasCount.HasValue).Select(x => x.SueId).ToList();
            var vizslasFilter = _auntSues.Where(x => x.VizslasCount == _sueToSearch.VizslasCount || !x.VizslasCount.HasValue).Select(x => x.SueId).ToList();
            var goldfishFilter = _auntSues.Where(x => x.GoldfishCount < _sueToSearch.GoldfishCount || !x.GoldfishCount.HasValue).Select(x => x.SueId).ToList();
            var treeFilter = _auntSues.Where(x => x.TreesCount > _sueToSearch.TreesCount || !x.TreesCount.HasValue).Select(x => x.SueId).ToList();
            var carsFilter = _auntSues.Where(x => x.CarsCount == _sueToSearch.CarsCount || !x.CarsCount.HasValue).Select(x => x.SueId).ToList();
            var perfumeFilter = _auntSues.Where(x => x.PerfumesCount == _sueToSearch.PerfumesCount || !x.PerfumesCount.HasValue).Select(x => x.SueId).ToList();


            var result = childrenFilter.Intersect(catFilter)
                                       .Intersect(samoyedFilter)
                                       .Intersect(pomeranianFilter)
                                       .Intersect(akitaFilter)
                                       .Intersect(vizslasFilter)
                                       .Intersect(goldfishFilter)
                                       .Intersect(treeFilter)
                                       .Intersect(carsFilter)
                                       .Intersect(perfumeFilter).ToList();

            return (T)Convert.ChangeType(result.Single(), typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        void CreateAuntSue(string auntDetails)
        {
            MatchCollection matches;
            matches = _sueRegex.Matches(auntDetails);
            var sueId = int.Parse(CommonRegexHelpers.NumberRegex().Match(matches.First().Value).Value);
            var childrenCount = GetValueForRegex(_childrenRegex, matches, auntDetails);
            var catsCount = GetValueForRegex(_catsRegex, matches, auntDetails);
            var samoyedsCount = GetValueForRegex(_samoyedsRegex, matches, auntDetails);
            var pomeraniansCount = GetValueForRegex(_pomeraniansRegex, matches, auntDetails);
            var akitasCount = GetValueForRegex(_akitasRegex, matches, auntDetails);
            var vizslasCount = GetValueForRegex(_vizslasRegex, matches, auntDetails);
            var goldfishCount = GetValueForRegex(_goldfishRegex, matches, auntDetails);
            var treesCount = GetValueForRegex(_treesRegex, matches, auntDetails);
            var carsCount = GetValueForRegex(_carsRegex, matches, auntDetails);
            var perfumesCount = GetValueForRegex(_perfumesRegex, matches, auntDetails);

            _auntSues.Add(new AuntSue()
            {
                SueId = sueId,
                ChildrenCount = childrenCount,
                CatsCount = catsCount,
                SamoyedsCount = samoyedsCount,
                PomeraniansCount = pomeraniansCount,
                AkitasCount = akitasCount,
                VizslasCount = vizslasCount,
                GoldfishCount = goldfishCount,
                TreesCount = treesCount,
                CarsCount = carsCount,
                PerfumesCount = perfumesCount,
            });
        }

        int? GetValueForRegex(Regex regex, MatchCollection matches, string auntDetails)
        {
            matches = regex.Matches(auntDetails);
            if (matches.Any())
            {
                var match = CommonRegexHelpers.NumberRegex().Match(matches.First().Value);
                return int.Parse(match.Value);
            }
            else
                return null;
        }

        [GeneratedRegex(@"Sue \d+")]
        private static partial Regex SueRegex();

        [GeneratedRegex(@"children: \d+")]
        private static partial Regex ChildrenRegex();

        [GeneratedRegex(@"cats: \d+")]
        private static partial Regex CatsRegex();

        [GeneratedRegex(@"samoyeds: \d+")]
        private static partial Regex SamoyedsRegex();

        [GeneratedRegex(@"pomeranians: \d+")]
        private static partial Regex PomeraniansRegex()
            ;
        [GeneratedRegex(@"akitas: \d+")]
        private static partial Regex AkitasRegex();

        [GeneratedRegex(@"vizslas: \d+")]
        private static partial Regex VizslasRegex();

        [GeneratedRegex(@"goldfish: \d+")]
        private static partial Regex GoldfishRegex();

        [GeneratedRegex(@"trees: \d+")]
        private static partial Regex TreesRegex();

        [GeneratedRegex(@"cars: \d+")]
        private static partial Regex CarsRegex();

        [GeneratedRegex(@"perfumes: \d+")]
        private static partial Regex PerfumesRegex();
        #endregion

        internal record AuntSue()
        {
            public required int SueId { get; init; }
            public int? ChildrenCount { get; init; }
            public int? CatsCount { get; init; }
            public int? SamoyedsCount { get; init; }
            public int? PomeraniansCount { get; init; }
            public int? AkitasCount { get; init; }
            public int? VizslasCount { get; init; }
            public int? GoldfishCount { get; init; }
            public int? TreesCount { get; init; }
            public int? CarsCount { get; init; }
            public int? PerfumesCount { get; init; }
        }


    }
}
