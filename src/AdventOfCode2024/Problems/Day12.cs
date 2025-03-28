﻿using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2024.Problems
{
    public class Day12 : IDayBase
    {

        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        ulong _secondResult = 0;
        string[] _gardenPlot = [];
        char[] _distinctPlotValues = [];

        Dictionary<string, List<(int row, int col)>> _plotSummary = new Dictionary<string, List<(int row, int col)>>();

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
        public ulong SecondResult
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
        Dictionary<string, List<(int row, int col)>> PlotSummary
        {
            get => _plotSummary;
            set
            {
                if (_plotSummary != value)
                {
                    _plotSummary = value;
                }
            }
        }


        #endregion

        #region Constructor
        public Day12(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            GardenPlot = File.ReadAllText(InputPath).Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            PlotSummary = FindAllSeparatePlot(GardenPlot);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(Calculate(1), typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(Calculate(2), typeof(T));
        }



        private long Calculate(int part)
        {
            long sum = 0;

            foreach (var plot in PlotSummary.Keys)
            {
                var coordinateValues = PlotSummary.GetValueOrDefault(plot);
                if (coordinateValues.Count == 1)
                    sum += 4;
                else
                {
                    HashSet<(int, int)> coordinates = coordinateValues.ToHashSet();

                    if (part == 1)
                    {
                        int perimeter = CalculatePerimeter(coordinates);
                        var area = perimeter * coordinates.Count();
                        sum += area;
                    }
                    else if (part == 2)
                    {
                        int corners = CalculateCorners(coordinates);
                        var area = corners * coordinates.Count();
                        sum += area;
                    }
                }

            }

            return sum;
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

        int CalculateCorners(HashSet<(int row, int col)> coordinates)
        {
            int corners = 0;

            foreach (var (row, col) in coordinates)
            {
                bool left = coordinates.Contains((row, col - 1));
                bool right = coordinates.Contains((row, col + 1));
                bool top = coordinates.Contains((row - 1, col));
                bool bottom = coordinates.Contains((row + 1, col));


                bool topLeft = coordinates.Contains((row - 1, col - 1));
                bool topRight = coordinates.Contains((row - 1, col + 1));
                bool bottomRight = coordinates.Contains((row + 1, col + 1));
                bool bottomLeft = coordinates.Contains((row + 1, col - 1));

                if (!left && !top)
                    corners++;
                else if (left && top && !topLeft)
                    corners++;

                if (!right && !top)
                    corners++;
                else if (right && top && !topRight)
                    corners++;

                if (!right && !bottom)
                    corners++;
                else if (right && bottom && !bottomRight)
                    corners++;

                if (!left && !bottom)
                    corners++;
                else if (left && bottom && !bottomLeft)
                    corners++;

            }

            return corners;
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
