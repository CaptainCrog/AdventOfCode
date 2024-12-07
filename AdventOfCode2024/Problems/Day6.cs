using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day6 : DayBase
    {
        #region Fields
        string _inputPath = @"PASTE PATH HERE";
        char[,] _map = new char[0, 0];
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        int _maxX = 0;
        int _maxY = 0;
        (int yPos, int xPos, char direction) _guard;
        (int yPos, int xPos, char direction) _initialStart;
        HashSet<(int yPos, int xPos, char direction)> _traversedCoordinates = new();
        int _callCount = 0;
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

        char[,] Map
        {
            get => _map;
            set
            {
                if (_map != value)
                {
                    _map = value;
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
        int SecondResult
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
        (int yPos, int xPos, char direction) Guard
        {
            get => _guard;
            set
            {
                if (_guard != value)
                {
                    _guard = value;
                }
            }
        }
        HashSet<(int yPos, int xPos, char direction)> TraversedCoordinates
        {
            get => _traversedCoordinates;
            set
            {
                if (_traversedCoordinates != value)
                {
                    _traversedCoordinates = value;
                }
            }
        }
        int MaxX
        {
            get => _maxX;
            set
            {
                if (_maxX != value)
                {
                    _maxX = value;
                }
            }
        }
        int MaxY
        {
            get => _maxY;
            set
            {
                if (_maxY != value)
                {
                    _maxY = value;
                }
            }
        }


        #endregion

        #region Constructor
        public Day6()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadLines(_inputPath).ToArray();
            MaxX = input[0].Length;
            MaxY = input.Length;
            Map = new char[MaxY, MaxX];
            for (int i = 0; i < MaxY; i++)
            {
                for (int j = 0; j < MaxX; j++)
                {
                    Map[i, j] = input[i][j];
                    if (Map[i, j] == '^')
                    {
                        Guard = (i, j, '^');
                        _initialStart = (i, j, '^');
                        TraversedCoordinates.Add((_initialStart.yPos, _initialStart.xPos, '^'));
                    }
                }
            }
        }

        public override T SolveFirstProblem<T>()
        {
            CalculateGuardsTrajectory((-1, 0));
            Sum = TraversedCoordinates.Select(x => (x.xPos, x.yPos)).Distinct().Count();

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {

            Console.WriteLine("Starting PART 2");
            Sum = 0;
            // Navigate only the co-ordinates we know the guard will move across
            var distinctTraversalGridPath = TraversedCoordinates.Select(x => (x.yPos, x.xPos)).Distinct().ToList();
            foreach (var gridPath in distinctTraversalGridPath)
            {
                TraversedCoordinates = new();
                Console.WriteLine($"Current Iteration {gridPath.yPos},{gridPath.xPos}");
                Guard = _initialStart;

                if (gridPath == (_initialStart.yPos, _initialStart.xPos))
                    continue;

                Map[gridPath.yPos, gridPath.xPos] = '0';
                CalculateGuardsTrajectory((-1, 0));
                Map[gridPath.yPos, gridPath.xPos] = '.';
                Console.WriteLine($"Call {_callCount}");
            }

            return (T)Convert.ChangeType(Sum, typeof(T));
        }


        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        void CalculateGuardsTrajectory((int yPos, int xPos) direction, char directionalArrow = '^')
        {

            while (true)
            {
                (int yPos, int xPos, char direction) nextPos = (Guard.yPos + direction.yPos, Guard.xPos + direction.xPos, directionalArrow);
                if (IsNextPositionOutOfBounds((Guard.yPos, Guard.xPos), direction))
                    return;
                else if (Map[nextPos.yPos, nextPos.xPos] == '#' || Map[nextPos.yPos, nextPos.xPos] == '0')
                    break;
                else
                {
                    Guard = nextPos;
                    if (!TraversedCoordinates.Add(nextPos))
                    {
                        Sum++;
                        return;
                    }
                }
            }

            if (directionalArrow == '^')
                CalculateGuardsTrajectory((0, 1), '>');
            else if (directionalArrow == '>')
                CalculateGuardsTrajectory((1, 0), 'v');
            else if (directionalArrow == 'v')
                CalculateGuardsTrajectory((0, -1), '<');
            else
                CalculateGuardsTrajectory((-1, 0), '^');
        }

        bool IsNextPositionOutOfBounds((int yPos, int xPos) guardPos, (int yPos, int xPos) direction)
        {
            return guardPos.xPos + direction.xPos == -1 ||
                   guardPos.yPos + direction.yPos == -1 ||
                   guardPos.xPos + direction.xPos == MaxX ||
                   guardPos.yPos + direction.yPos == MaxY;
        }

        #endregion

    }
}
