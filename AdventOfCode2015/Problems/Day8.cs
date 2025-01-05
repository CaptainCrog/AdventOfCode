namespace AdventOfCode2015.Problems
{
    public class Day8 : DayBase
    {


        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        string[] _antennaSignals = [];
        char[] _antennaFrequencies = [];
        List<(int row, int col)> _antinodes = new List<(int, int)>();
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
        string[] AntennaSignals
        {
            get => _antennaSignals;
            set
            {
                if (_antennaSignals != value)
                {
                    _antennaSignals = value;
                }
            }
        }

        char[] AntennaFrequencies
        {
            get => _antennaFrequencies;
            set
            {
                if (_antennaFrequencies != value)
                {
                    _antennaFrequencies = value;
                }
            }
        }

        List<(int row, int col)> Antinodes
        {
            get => _antinodes;
            set
            {
                if (_antinodes != value)
                {
                    _antinodes = value;
                }
            }
        }


        #endregion

        #region Constructor
        public Day8(string inputPath)
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
            AntennaSignals = File.ReadLines(_inputPath).ToArray();
            AntennaFrequencies = string.Join(Environment.NewLine, AntennaSignals).Select(x => x).Where(x => x != '\r' && x != '\n' && x != '.').Distinct().ToArray();
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = CreateFrequencyPositions(false);

            return (T)Convert.ChangeType(Sum, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            Sum = CreateFrequencyPositions(true);
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        private int CreateFrequencyPositions(bool isPartTwo)
        {
            Antinodes = new List<(int row, int col)>();
            foreach (var frequency in AntennaFrequencies)
            {
                var frequencyPositions = new List<(int, int)>();
                var filteredAntennaSignals = AntennaSignals.ToArray();
                for (int i = 0; i <= filteredAntennaSignals.Length - 1; i++)
                {
                    for (int j = 0; j < filteredAntennaSignals[0].Length - 1; j++)
                    {
                        if (filteredAntennaSignals[i][j] == frequency)
                        {
                            frequencyPositions.Add((i, j));
                        }
                    }
                }

                ProcessSignal(frequencyPositions, isPartTwo);

            }
            Antinodes = Antinodes.Distinct().ToList();
            return Antinodes.Count;
        }

        void ProcessSignal(List<(int, int)> frequencyPositions, bool isPartTwo)
        {
            foreach ((int row, int col) frequencyPosition in frequencyPositions)
            {
                var otherFrequencyPositions = frequencyPositions.Where(x => x != frequencyPosition).ToList();
                foreach ((int row, int col) otherFrequencyPosition in otherFrequencyPositions)
                {
                    (int row, int col) distance = (frequencyPosition.row - otherFrequencyPosition.row, frequencyPosition.col - otherFrequencyPosition.col);
                    (int row, int col) antinode = (frequencyPosition.row + distance.row, frequencyPosition.col + distance.col);
                    if (isPartTwo)
                    {
                        Antinodes.Add(frequencyPosition);
                        while (antinode.row >= 0 && antinode.row <= AntennaSignals.Length - 1 && antinode.col >= 0 && antinode.col <= AntennaSignals[0].Length - 1)
                        {
                            Antinodes.Add(antinode);
                            antinode = (antinode.row + distance.row, antinode.col + distance.col);
                        }
                    }
                    else
                    {
                        if (antinode.row < 0 || antinode.row > AntennaSignals.Length - 1 || antinode.col < 0 || antinode.col > AntennaSignals[0].Length - 1)
                            continue;
                        else
                            Antinodes.Add(antinode);
                    }
                }
            }
        }

        #endregion
    }
}
