using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdventOfCode2017.Problems
{
    public class Day21 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _iterationLimit = 0;
        List<string> _grid = [];
        Dictionary<string, string> _rules = [];
        HashSet<string> _startingConfigurations =
        [
            ".#./..#/###",
            ".#./#../###",
            "#../#.#/##.",
            "###/..#/.#.",
            "###/#../.#.",
            ".##/#.#/..#",
            "..#/#.#/.##",
            "##./#.#/#.."
        ];


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
        public Day21(string inputPath, int iterationLimit) 
        {
            _inputPath = inputPath;
            _iterationLimit = iterationLimit;
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
            foreach (var rule in input)
            {
                var parts = rule.Split(" => ");
                var rotatableRule = parts[0];
                var ruleOutput = parts[1];
                for (int i = 0; i < 4; i++)
                {
                    rotatableRule = RotateRule(rotatableRule);
                    _rules.TryAdd(rotatableRule, ruleOutput);
                    _rules.TryAdd(FlipRule(rotatableRule), ruleOutput);
                }
            }
            var startingConfiguration = _rules.Keys.Intersect(_startingConfigurations).First();
            _grid = new List<string>(startingConfiguration.Split('/'));
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            int result = 0;
            var gridCopy = _grid.ToList();
            for (int i = 0; i < _iterationLimit; i++)
            {
                gridCopy = ProcessGrid(gridCopy);
            }

            result = string.Join("", gridCopy.ToArray()).Count(x => x == '#');
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            int result = 0;
            var gridCopy = _grid.ToList();
            for (int i = 0; i < 18; i++)
            {
                gridCopy = ProcessGrid(gridCopy);
            }

            result = string.Join("", gridCopy.ToArray()).Count(x => x == '#');
            return (T)Convert.ChangeType(result, typeof(T));
        }

        string RotateRule(string currentRule)
        {
            var ruleParts = currentRule.Split('/');
            var matrix = ruleParts.Select(row => row.ToCharArray()).ToArray();

            var layerCount = ruleParts.Length/2;
            for (int i = 0; i < layerCount; i++)
            {
                var first = i;
                var last = matrix.Length - i - 1;

                for (int j = first; j < last; j++)
                {
                    var offset = j - first;

                    var top = matrix[first][j];
                    var right = matrix[j][last];
                    var bottom = matrix[last][last - offset];
                    var left = matrix[last - offset][first];

                    matrix[first][j] = left;
                    matrix[j][last] = top;
                    matrix[last][last-offset] = right;
                    matrix[last-offset][first] = bottom;
                }
            }

            return string.Join("/", matrix.Select(row => new string(row)).ToArray());
        }

        string FlipRule(string currentRule)
        {
            var ruleParts = currentRule.Split('/');
            var matrix = ruleParts.Select(row => row.ToCharArray()).ToArray();
            matrix = matrix.Reverse().ToArray();

            return string.Join("/", matrix.Select(row => new string(row)).ToArray());
        }

        List<string> ProcessGrid(List<string> grid)
        {
            int size = grid.Count;
            int blockSize = (size % 2 == 0) ? 2 : 3;
            int newBlockSize = blockSize + 1;
            int newSize = (size / blockSize) * newBlockSize;

            List<string> newGrid = Enumerable.Repeat(new string('.', newSize), newSize).ToList();

            for (int i = 0; i < size; i += blockSize)
            {
                for (int j = 0; j < size; j += blockSize)
                {
                    string block = GetBlock(grid, i, j, blockSize);
                    string[] enhancedBlock = _rules[block].Split('/');

                    PlaceBlock(newGrid, enhancedBlock, i / blockSize * newBlockSize, j / blockSize * newBlockSize);
                }
            }

            return newGrid;
        }
        string GetBlock(List<string> grid, int row, int col, int size)
        {
            List<string> block = [];
            for (int i = 0; i < size; i++)
            {
                block.Add(grid[row + i].Substring(col, size));
            }
            return string.Join("/", block);
        }
        void PlaceBlock(List<string> grid, string[] block, int row, int col)
        {
            for (int i = 0; i < block.Length; i++)
            {
                char[] newRow = grid[row + i].ToCharArray();
                for (int j = 0; j < block[i].Length; j++)
                {
                    newRow[col + j] = block[i][j];
                }
                grid[row + i] = new string(newRow);
            }
        }
        #endregion
    }
}

// ##.
// #.#
// ..#

//##./#.#/..#
//.##/..#/##.
//#../#.#/.##
//.##/#../##.