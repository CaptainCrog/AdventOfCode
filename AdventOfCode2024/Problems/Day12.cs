using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day12 : DayBase
    {

        #region Fields

        string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024TestInputDay12.txt";
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
            var sum = 0;


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
                var temp = _plotSummary.GetValueOrDefault(x);
                var temp2 = temp.OrderBy(x => x.row).ThenBy(x => x.col).ToList();

                if (temp.Count == 1)
                {
                    sum += 4;
                }

                //2 + i along the top

            }


            //Antinodes = new List<(int row, int col)>();
            //foreach (var frequency in AntennaFrequencies)
            //{
            //    var frequencyPositions = new List<(int, int)>();
            //    var filteredAntennaSignals = AntennaSignals.ToArray();
            //    for (int i = 0; i <= filteredAntennaSignals.Length - 1; i++)
            //    {
            //        for (int j = 0; j < filteredAntennaSignals[0].Length - 1; j++)
            //        {
            //            if (filteredAntennaSignals[i][j] == frequency)
            //            {
            //                frequencyPositions.Add((i, j));
            //            }
            //        }
            //    }

            //    ProcessSignal(frequencyPositions, isPartTwo);

            //}
            //Antinodes = Antinodes.Distinct().ToList();
            //return Antinodes.Count;


            return (T)Convert.ChangeType(sum, typeof(T));
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
            }

            nextPlotsToCheck = nextPlotsToCheck.Distinct().ToList();

            if (nextPlotsToCheck.Count > 0)
                FindWholePlot(plotValue, nextPlotsToCheck, plotsAlreadyChecked);

            return plotsAlreadyChecked;
        }

        #endregion
    }
}
