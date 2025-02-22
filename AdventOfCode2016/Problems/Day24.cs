using AdventOfCode2016.CommonInternalTypes;
using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Constants;
using CommonTypes.CommonTypes.Enums;
using CommonTypes.CommonTypes.ExtensionMethods;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using System.Linq;

namespace AdventOfCode2016.Problems
{
    public partial class Day24 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        char[,] _grid = new char[0, 0];
        Dictionary<int, Node> _pointsOfInterest = new();
        Node _current = new();
        Node _target = new();
        HashSet<char> _pointOfInterestValues = new() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        (int dx, int dy, Direction direction)[] _directions = DirectionConstants.GetBasicDirections();
        Dictionary<(int, int), int> _positionPairs = new();
        IEnumerable<IEnumerable<int>> _positionPermutations;



        #endregion

        #region Properties
        string InputPath
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
        #endregion

        #region Constructor
        public Day24(string inputPath)
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
            _grid = new char[input.Length, input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (_pointOfInterestValues.Contains(input[i][j]))
                        _pointsOfInterest.Add(int.Parse(input[i][j].ToString()), new Node() { X = i, Y = j });

                    _grid[i, j] = input[i][j];
                }
            }


            for (int i = 0; i < _pointsOfInterest.Count; i++)
            {
                for (int j = i + 1; j < _pointsOfInterest.Count; j++)
                {
                    _current = _pointsOfInterest[i];
                    _target = _pointsOfInterest[j];
                    _positionPairs.Add((i, j), FindShortestPath(_current, _target));
                }
            }



            _positionPermutations = ArrayHelperFunctions.GetAllPermutations(_pointsOfInterest.Select(x => x.Key).ToArray());
            _positionPermutations = _positionPermutations.Where(x => x.First() == 0).ToArray();

        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            int lowestStepCounter = GetFewestSteps(false);
            return (T)Convert.ChangeType(lowestStepCounter, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            int lowestStepCounter = GetFewestSteps(true);
            return (T)Convert.ChangeType(lowestStepCounter, typeof(T));
        }


        int FindShortestPath(Node start, Node target)
        {
            int rows = _grid.GetLength(0);
            int cols = _grid.GetLength(1);
            var distances = new Dictionary<(int x, int y, Direction direction), int>();
            var previousNodes = new Dictionary<(int x, int y, Direction direction), List<Node>>();
            var priorityQueue = new PriorityQueue<Node, int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                    {
                        distances[(i, j, dir)] = int.MaxValue;
                        previousNodes[(i, j, dir)] = new List<Node>();
                    }
                }
            }

            distances[(start.X, start.Y, start.Direction)] = 0;
            priorityQueue.Enqueue(start, 0);

            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.Dequeue();

                if (distances[(current.X, current.Y, current.Direction)] < current.Cost)
                    continue;

                foreach (var (dx, dy, newFacing) in _directions)
                {
                    int newX = current.X + dx;
                    int newY = current.Y + dy;

                    if (IsValid(newX, newY, rows, cols))
                    {
                        int movementCost = 1;
                        int newCost = distances[(current.X, current.Y, current.Direction)] + movementCost;


                        if (newCost < distances[(newX, newY, newFacing)])
                        {
                            distances[(newX, newY, newFacing)] = newCost;
                            previousNodes[(newX, newY, newFacing)] = new List<Node> { current };
                            priorityQueue.Enqueue(new Node { X = newX, Y = newY, Direction = newFacing, Cost = newCost }, newCost);
                        }
                        else if (newCost == distances[(newX, newY, newFacing)])
                        {
                            previousNodes[(newX, newY, newFacing)].Add(current);
                        }
                    }
                }
            }

            int minCostToTarget = int.MaxValue;
            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var directionEnum = (Direction)direction;
                minCostToTarget = Math.Min(minCostToTarget, distances[(target.X, target.Y, directionEnum)]);
            }

            return minCostToTarget;


            bool IsValid(int x, int y, int rows, int cols)
            {
                return x >= 0 && y >= 0 && x < rows && y < cols && _grid[x, y] != '#';
            }
        }

        int GetFewestSteps(bool isPartTwo)
        {
            int lowestStepCounter = int.MaxValue;
            foreach (var permutationEnumerable in _positionPermutations)
            {
                int stepCounter = 0;
                var permutation = permutationEnumerable.ToArray();
                for (int i = 0; i < permutation.Count() - 1; i++)
                {
                    var firstNumber = permutation[i];
                    var secondNumber = permutation[i + 1];
                    //Try first -> second, otherwise try the inverse second -> first
                    if (!_positionPairs.TryGetValue((firstNumber, secondNumber), out int steps))
                        _positionPairs.TryGetValue((secondNumber, firstNumber), out steps);

                    stepCounter += steps;
                }

                if (isPartTwo)
                {
                    if (!_positionPairs.TryGetValue((permutation[0], permutation[permutation.Length - 1]), out int returnSteps))
                        _positionPairs.TryGetValue((permutation[permutation.Length - 1], permutation[0]), out returnSteps);
                    stepCounter += returnSteps;
                }


                lowestStepCounter = Math.Min(lowestStepCounter, stepCounter);
            }

            return lowestStepCounter;
        }

        #endregion

    }
}