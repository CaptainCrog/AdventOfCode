using AdventOfCode2017.CommonInternalTypes;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public class Day14 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _baseHash = string.Empty;
        LinkedList<int> _numbers = [];
        string[] _grid = [];

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
        public Day14(string inputPath) 
        {
            _inputPath = inputPath;
            _numbers = new LinkedList<int>(Enumerable.Range(0, 256).ToArray());
            _grid = new string[128];
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            _baseHash = File.ReadAllText(_inputPath);
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = 0;
            for (int i = 0; i < 128; i++)
            {
                var numbersCopy = new LinkedList<int>(_numbers);
                var rowHash = $"{_baseHash}-{i}";
                int[] knotHashingInstructions = [.. ArrayHelperFunctions.GetAsciiValues([rowHash]), 17, 31, 73, 47, 23];
                var sparseHash = KnotHashing.CreateSparseHash(knotHashingInstructions, numbersCopy);
                List<int> denseHashes = new List<int>();
                for (int j = 0; j < sparseHash.Count; j += 16)
                {
                    denseHashes.Add(KnotHashing.ReduceSparseHash(sparseHash.Skip(j).Take(16).ToArray()));
                }
                var rowDenseHash = string.Join(string.Empty, denseHashes.Select(x => x.ToString("X2"))).ToLower();
                var hexToBinary = string.Join(string.Empty, rowDenseHash.Select(x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')));
                _grid[i] = hexToBinary;
                result += hexToBinary.ToCharArray().Where(x => x == '1').Count();
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = FindAllSeparateGroups(_grid).Count();


            return (T)Convert.ChangeType(result, typeof(T));
        }


        static Dictionary<string, List<(int, int)>> FindAllSeparateGroups(string[] grid)
        {
            var visited = new bool[grid.Length, grid[0].Length];
            var groups = new Dictionary<string, List<(int, int)>>();
            int groupCounter = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (!visited[i, j] && grid[i][j] != '0')
                    {
                        var group = new List<(int, int)>();
                        SearchGrid(grid, visited, i, j, '1', group);
                        groups.Add($"{groupCounter++}", group);
                    }
                }
            }

            return groups;
        }

        static void SearchGrid(string[] grid, bool[,] visited, int row, int col, char searchValue, List<(int, int)> group)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[row].Length || visited[row, col] || grid[row][col] != searchValue)
                return;

            visited[row, col] = true;
            group.Add((row, col));

            SearchGrid(grid, visited, row + 1, col, searchValue, group);
            SearchGrid(grid, visited, row - 1, col, searchValue, group);
            SearchGrid(grid, visited, row, col + 1, searchValue, group);
            SearchGrid(grid, visited, row, col - 1, searchValue, group);
        }

        #endregion
    }
}
