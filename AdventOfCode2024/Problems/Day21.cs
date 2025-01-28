using CommonTypes.CommonTypes.Classes;

namespace AdventOfCode2024.Problems
{
    public class Day21 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        long _firstResult = 0;
        long _secondResult = 0;
        string[] _codes = [];

        (Dictionary<string, int[]>, string) _numericalKeypadLookup = new();
        (Dictionary<string, int[]>, string) _directionalKeypadLookup = new();

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


        public long FirstResult
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
        public long SecondResult
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
        public Day21(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<long>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _codes = File.ReadAllLines(_inputPath);

            var numericPad = new List<string> { "789", "456", "123", " 0A" };
            var directionalPad = new List<string> { " ^A", "<v>" };

            _numericalKeypadLookup = PadLookup(numericPad);
            _directionalKeypadLookup = PadLookup(directionalPad);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var sum = GetComplexity(2);
            return (T)Convert.ChangeType(sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var sum = GetComplexity(25);
            return (T)Convert.ChangeType(sum, typeof(T));
        }

        #region Part 1 Legacy
        (Dictionary<string, int[]>, string) PadLookup(List<string> padRows)
        {
            var coords = new Dictionary<string, int[]>();
            string gap = padRows.Count == 2 ? "0,0" : "3,0";

            for (int row = 0; row < padRows.Count; row++)
            {
                string keys = padRows[row];
                for (int col = 0; col < keys.Length; col++)
                {
                    char key = keys[col];
                    if (key != ' ')
                    {
                        coords[key.ToString()] = [row, col];
                    }
                }
            }

            return (coords, gap);
        }

        string FindShortestPath(string fromKey, string toKey, (Dictionary<string, int[]> coords, string gap) pad)
        {
            int[] fromPos = pad.coords[fromKey];
            int[] toPos = pad.coords[toKey];

            int row1 = fromPos[0], col1 = fromPos[1];
            int row2 = toPos[0], col2 = toPos[1];

            string verticalDirection = row2 > row1 ? new string('v', row2 - row1) : new string('^', row1 - row2);
            string horizontalDirection = col2 > col1 ? new string('>', col2 - col1) : new string('<', col1 - col2);

            if (col2 > col1 && $"{row2},{col1}" != pad.gap)
            {
                return $"{verticalDirection}{horizontalDirection}A";
            }
            if ($"{row1},{col2}" != pad.gap)
            {
                return $"{horizontalDirection}{verticalDirection}A";
            }
            return $"{verticalDirection}{horizontalDirection}A";
        }

        List<string> GetSequence(string currentSequence, (Dictionary<string, int[]> coords, string gap) pad)
        {
            List<string> keys = [];
            string prevKey = "A";
            foreach (var key in currentSequence)
            {
                var keyString = key.ToString();
                keys.Add(FindShortestPath(prevKey, keyString, pad));
                prevKey = keyString;
            }
            return keys;
        }

        #endregion

        #region Part 1 and Part 2

        long GetComplexity(int numberOfRobots)
        {
            var frequencyTables = _codes.Select(code => new Dictionary<string, long> { { string.Join("", GetSequence(code, _numericalKeypadLookup)), 1 } }).ToList();

            for (int i = 0; i < numberOfRobots; i++)
            {
                frequencyTables = frequencyTables.Select(frequencyTable =>
                {
                    var subFrequencyTable = new Dictionary<string, long>();
                    foreach (var entry in frequencyTable)
                    {
                        var subCount = GetSequenceCounts(entry.Key, _directionalKeypadLookup);
                        foreach (var subEntry in subCount)
                        {
                            AddToFrequencyTable(subFrequencyTable, subEntry.Key, subEntry.Value * entry.Value);
                        }
                    }
                    return subFrequencyTable;
                }).ToList();
            }

            long sum = 0;
            for (int i = 0; i < _codes.Count(); i++)
            {
                var frequencyTable = frequencyTables[i];
                long tableComplexity = frequencyTable.Sum(entry => entry.Key.Length * entry.Value);
                sum += (tableComplexity * Convert.ToInt64(_codes[i].Substring(0, _codes[i].Length - 1)));
            }

            return sum;
        }

        void AddToFrequencyTable(Dictionary<string, long> frequencyTable, string key, long value)
        {
            if (frequencyTable.ContainsKey(key))
                frequencyTable[key] += value;
            else
                frequencyTable[key] = value;
        }

        Dictionary<string, long> GetSequenceCounts(string currentSequence, (Dictionary<string, int[]> coords, string gap) pad)
        {
            var frequencyTable = new Dictionary<string, long>();
            foreach (var subSeq in GetSequence(currentSequence, pad))
            {
                AddToFrequencyTable(frequencyTable, subSeq, 1);
            }
            return frequencyTable;
        }

        #endregion

        #endregion
    }
}
