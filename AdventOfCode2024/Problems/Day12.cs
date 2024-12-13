using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace AdventOfCode2024.Problems
{
    public class Day12 : DayBase
    {

        #region Fields
        //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day12PuzzleInput.txt";
        //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\TestInputs\AdventOfCode2024Day12TestInput2.txt";
        //string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024TestInputDay12.txt";
        string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024PuzzleInputDay12.txt";
        int _firstResult = 0;
        ulong _secondResult = 0;
        string[] _gardenPlot = [];
        char[] _distinctPlotValues = [];
        string _rawInput;

        Dictionary<string, List<(int row, int col)>> _plotSummary = new Dictionary<string, List<(int row, int col)>>();

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


        int FirstResult
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
        ulong SecondResult
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

        string[] GardenPlot
        {
            get => _gardenPlot;
            set
            {
                if (_gardenPlot != value)
                {
                    _gardenPlot = value;
                }
            }
        }
        char[] DistinctPlotValues
        {
            get => _distinctPlotValues;
            set
            {
                if (_distinctPlotValues != value)
                {
                    _distinctPlotValues = value;
                }
            }
        }


        #endregion

        #region Constructor
        public Day12()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            _rawInput = File.ReadAllText(InputPath);
            GardenPlot = _rawInput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            long sum = 0;

            _plotSummary = FindAllSeparatePlot(GardenPlot);

            foreach (var x in _plotSummary.Keys)
            {
                var y2 = _plotSummary.Select(x => x.Value.Count).ToList();
                var coordinateValues = _plotSummary.GetValueOrDefault(x);
                if (coordinateValues.Count == 1)
                    sum += 4;
                else
                {
                    HashSet<(int, int)> coordinates = coordinateValues.ToHashSet();


                    int perimeter = CalculatePerimeter(coordinates);
                    var area = perimeter * coordinates.Count();
                    sum += area;
                    Console.WriteLine($"The perimeter of the shape is: {perimeter}");
                }

            }

            return (T)Convert.ChangeType(sum, typeof(T));
        }


        public override T SolveSecondProblem<T>()
        {
            var sum = 0;
            return (T)Convert.ChangeType(sum, typeof(T));
        }


        int CalculatePerimeter(HashSet<(int row, int col)> coordinates)
        {
            int perimeter = 0;

            foreach (var (row, col) in coordinates)
            {
                // Check each of the 4 possible neighbors
                if (!coordinates.Contains((row - 1, col))) perimeter++; // Left
                if (!coordinates.Contains((row + 1, col))) perimeter++; // Right
                if (!coordinates.Contains((row, col - 1))) perimeter++; // Down
                if (!coordinates.Contains((row, col + 1))) perimeter++; // Up
            }

            return perimeter;
        }

        static Dictionary<string, List<(int, int)>> FindAllSeparatePlot(string[] gardenPlot)
        {
            var visited = new bool[gardenPlot.Length, gardenPlot[0].Length];
            var groups = new Dictionary<string, List<(int, int)>>();
            int groupCounter = 1;

            for (int i = 0; i < gardenPlot.Length; i++)
            {
                for (int j = 0; j < gardenPlot[i].Length; j++)
                {
                    if (!visited[i, j] && gardenPlot[i][j] != ' ')
                    {
                        var group = new List<(int, int)>();
                        SearchPlot(gardenPlot, visited, i, j, gardenPlot[i][j], group);
                        groups.Add($"{gardenPlot[i][j]}{groupCounter++}", group);
                    }
                }
            }

            return groups;
        }

        static void SearchPlot(string[] gardenPlot, bool[,] visited, int row, int col, char plotValue, List<(int, int)> group)
        {
            if (row < 0 || row >= gardenPlot.Length || col < 0 || col >= gardenPlot[row].Length || visited[row, col] || gardenPlot[row][col] != plotValue)
                return;

            visited[row, col] = true;
            group.Add((row, col));

            SearchPlot(gardenPlot, visited, row + 1, col, plotValue, group);
            SearchPlot(gardenPlot, visited, row - 1, col, plotValue, group);
            SearchPlot(gardenPlot, visited, row, col + 1, plotValue, group);
            SearchPlot(gardenPlot, visited, row, col - 1, plotValue, group);
        }
        #endregion
    }
}
