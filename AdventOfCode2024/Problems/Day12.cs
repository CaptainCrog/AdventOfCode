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
        string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day12PuzzleInput.txt";
        //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\TestInputs\AdventOfCode2024Day12TestInput2.txt";
        int _firstResult = 0;
        ulong _secondResult = 0;
        ulong _sumOfStones = 0;
        int _maxX = 0;
        int _maxY = 0;
        string[] _gardenPlot = [];
        char[] _distinctPlotValues = [];

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

        ulong SumOfStones
        {
            get => _sumOfStones;
            set
            {
                if (_sumOfStones != value)
                {
                    _sumOfStones = value;
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
            GardenPlot = File.ReadAllLines(InputPath);
            _maxX = GardenPlot.Length - 1;
            _maxY = GardenPlot[0].Length - 1;
            DistinctPlotValues = string.Join(Environment.NewLine, GardenPlot).Select(x => x).Where(x => x != '\r' && x != '\n').Distinct().ToArray();
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            long sum = 0;


            var filteredGardenPlot = GardenPlot.ToArray();
            var plotKeyEnumerator = 0;
            var allPlotsCovered = new List<(int row, int col)>();
            for (int i = 0; i <= filteredGardenPlot.Length - 1; i++)
            {
                for (int j = 0; j < filteredGardenPlot[0].Length - 1; j++)
                {
                    if (allPlotsCovered.Contains((i, j)))
                        continue;

                    var plotValue = filteredGardenPlot[i][j];
                    var wholePlot = FindWholePlot(plotValue, new List<(int row, int col)> { (i, j) }, new List<(int row, int col)>());
                    _plotSummary.Add($"{plotValue}{plotKeyEnumerator}", wholePlot);
                    allPlotsCovered.AddRange(wholePlot);
                    plotKeyEnumerator++;
                }
            }

            foreach (var x in _plotSummary.Keys)
            {
                var y2 = _plotSummary.Select(x => x.Value.Count).ToList();
                var temp = _plotSummary.GetValueOrDefault(x);
                if (temp.Count == 1)
                {
                    //for (int i = 0; i <= filteredGardenPlot.Length - 1; i++)
                    //{
                    //    for (int j = 0; j < filteredGardenPlot[0].Length - 1; j++)
                    //    {
                    //        if (temp.Contains((i, j)))
                    //            Console.ForegroundColor = ConsoleColor.Green;
                    //        else
                    //            Console.ForegroundColor = ConsoleColor.White;
                    //        Console.Write(filteredGardenPlot[i][j]);
                    //    }
                    //    Console.WriteLine();
                    //}

                    sum += 4;
                }
                else
                {
                    var temp2 = temp.OrderBy(x => x.row).ThenBy(x => x.col).ToList();
                    HashSet<(int, int)> coordinates = temp2.ToHashSet();

                    //for (int i = 0; i <= filteredGardenPlot.Length - 1; i++)
                    //{
                    //    for (int j = 0; j < filteredGardenPlot[0].Length - 1; j++)
                    //    {
                    //        if (coordinates.Contains((i, j)))
                    //            Console.ForegroundColor = ConsoleColor.Green;
                    //        else
                    //            Console.ForegroundColor = ConsoleColor.White;
                    //        Console.Write(filteredGardenPlot[i][j]);
                    //    }
                    //    Console.WriteLine();
                    //}


                    int perimeter = CalculatePerimeter(coordinates);
                    var area = perimeter * coordinates.Count();
                    sum += area;
                    Console.WriteLine($"The perimeter of the shape is: {perimeter}");
                }

            }


            return (T)Convert.ChangeType(sum, typeof(T));
            //1532992 TOO LOW
            //1533024
        }


        public override T SolveSecondProblem<T>()
        {
            var sum = 0;
            return (T)Convert.ChangeType(sum, typeof(T));
        }


        List<(int row, int col)> FindWholePlot(char plotValue, List<(int row, int col)> plotsToCheck, List<(int row, int col)> plotsAlreadyChecked)
        {
            plotsAlreadyChecked.AddRange(plotsToCheck);
            var nextPlotsToCheck = new List<(int row, int col)> ();

            foreach (var plot in plotsToCheck)
            {
                if (plot.col-1 >= 0 && GardenPlot[plot.row][plot.col-1] == plotValue && !plotsAlreadyChecked.Contains((plot.row, plot.col-1)))
                {
                    nextPlotsToCheck.Add((plot.row, plot.col - 1));
                }
                if (plot.col + 1 <= _maxY && GardenPlot[plot.row][plot.col + 1] == plotValue && !plotsAlreadyChecked.Contains((plot.row, plot.col + 1)))
                {
                    nextPlotsToCheck.Add((plot.row, plot.col + 1));
                }
                if (plot.row + 1 <= _maxX && GardenPlot[plot.row + 1][plot.col] == plotValue && !plotsAlreadyChecked.Contains((plot.row + 1, plot.col)))
                {
                    nextPlotsToCheck.Add((plot.row + 1, plot.col));
                }
                if (plot.row - 1 >= 0 && GardenPlot[plot.row - 1][plot.col] == plotValue && !plotsAlreadyChecked.Contains((plot.row - 1, plot.col)))
                {
                    nextPlotsToCheck.Add((plot.row - 1, plot.col));
                }
            }

            nextPlotsToCheck = nextPlotsToCheck.Distinct().ToList();

            if (nextPlotsToCheck.Count > 0)
                FindWholePlot(plotValue, nextPlotsToCheck, plotsAlreadyChecked);

            return plotsAlreadyChecked;
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
        #endregion
    }
}
