using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2018.Problems
{
    public class Day02 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string[] _boxIds = [];
        Dictionary<string, int> _boxIdAsciiSum = [];
        int _firstResult = 0;
        string _secondResult = string.Empty;
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
        public Day02(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public void InitialiseProblem()
        {
            _boxIds = File.ReadAllLines(_inputPath);
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var twoCharChecksum = 0;
            var threeCharChecksum = 0;
            foreach (var boxId in _boxIds)
            {
                var boxIdsGroups = boxId.GroupBy(x => x).Where(x => x.Count() >= 2).ToList();
                if (boxIdsGroups.Any(x => x.Count() == 2))
                    twoCharChecksum++;
                if (boxIdsGroups.Any(x => x.Count() == 3))
                    threeCharChecksum++;
            }
            var result = twoCharChecksum * threeCharChecksum;
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = string.Empty;
            var boxIdDictionary = _boxIds.Select(x => new { Key = x, Value = x.Sum(xx => (int)xx) }).ToDictionary(x => x.Key, x => x.Value);
            List<(string, string)> potentialPairs = new();
            for (int i = 0; i < boxIdDictionary.Count; i++)
            {
                var comparitor1 = boxIdDictionary.ElementAt(i);
                for (int j = i+1; j < boxIdDictionary.Count; j++)
                {
                    var comparitor2 = boxIdDictionary.ElementAt(j);
                    if (Math.Abs(comparitor1.Value - comparitor2.Value) <= 25)
                        potentialPairs.Add((comparitor1.Key, comparitor2.Key));
                }
            }

            foreach(var pair in potentialPairs)
            {
                var differences = 0;
                var tempResult = string.Empty;
                for (int i = 0; i < pair.Item1.Length; i++)
                {
                    if (pair.Item1[i] != pair.Item2[i])
                        differences++;
                    else
                        tempResult += pair.Item1[i];
                    if (differences > 1)
                        continue;
                }
                if (differences == 1)
                {
                    result = tempResult;
                    break;
                }

            }


            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion

    }
}
