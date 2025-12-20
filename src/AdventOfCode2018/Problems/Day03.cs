using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2018.Problems
{
    public class Day03 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int[,] _fabric = new int [1000, 1000];
        FabricClaim[] _fabricClaims = [];
        Dictionary<(int, int), List<int>> _fabricDictionary = [];
        int _firstResult = 0;
        int _secondResult = 0;
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
        public Day03(string inputPath)
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
            _fabricClaims = new FabricClaim[input.Length];
            var numberRegex = CommonRegexHelpers.NumberRegex();
            for (int i = 0; i < input.Length; i++)
            {
                var matches = numberRegex.Matches(input[i]);
                _fabricClaims[i] = new FabricClaim()
                {
                    FabricClaimId = int.Parse(matches[0].Value),
                    InchesFromLeft = int.Parse(matches[1].Value),
                    InchesFromTop = int.Parse(matches[2].Value),
                    Width = int.Parse(matches[3].Value),
                    Height = int.Parse(matches[4].Value),
                };
            }
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            foreach (var fabricClaim in _fabricClaims)
            {
                for (int i = fabricClaim.InchesFromTop; i < fabricClaim.InchesFromTop + fabricClaim.Height; i++)
                {
                    for (int j = fabricClaim.InchesFromLeft; j < fabricClaim.InchesFromLeft + fabricClaim.Width; j++)
                    {
                        _fabric[i, j]++;
                        _fabricDictionary.TryAdd((i, j), new List<int>());
                        _fabricDictionary[(i, j)].Add(fabricClaim.FabricClaimId);

                    }
                }
            }

            var result = (from int squareInch in _fabric
                         where squareInch >= 2
                         select squareInch).Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {

            var overlappingClaimIds = _fabricDictionary.Where(x => x.Value.Count > 1).SelectMany(x => x.Value).Distinct().ToList();
            foreach (var id in overlappingClaimIds)
            {
                _fabricClaims.Where(x => x.FabricClaimId == id).First().IsOverlapping = true;
            }

            var result = _fabricClaims.Where(x => !x.IsOverlapping).Single().FabricClaimId;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion


        record FabricClaim
        {
            public required int FabricClaimId { get; init; }
            public required int InchesFromLeft { get; init; }
            public required int InchesFromTop { get; init; }
            public required int Width { get; init; }
            public required int Height { get; init; }
            public bool IsOverlapping { get; set; }
        };
    }
}
