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
        string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024PuzzleInputDay6.txt";
        char[,] _map = new char[0,0];
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        int _maxX = 0;
        int _maxY = 0;
        int _part2HitOccurrences = 0;
        (int yPos, int xPos) _guard;
        (int yPos, int xPos) _initialStart;
        List<(int yPos, int xPos)> _traversedCoordinates = new();
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
        (int yPos, int xPos) Guard
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
        List<(int yPos, int xPos)> TraversedCoordinates
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
        int Part2HitOccurrences
        {
            get => _part2HitOccurrences;
            set
            {
                if (_part2HitOccurrences != value)
                {
                    _part2HitOccurrences = value;
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
            //Line 90 Col69 is where the guard starts at
            var input = File.ReadAllLines(_inputPath);
            MaxX = input[0].Length - 1;
            MaxY = input.Length - 1;
            Map = new char[MaxY, MaxX];
            for (int i = 0; i < MaxY; i++)
            {
                for (int j = 0; j < MaxX; j++)
                {
                    Map[i, j] = input[i][j];
                    if (Map[i, j] == '^')
                    {
                        Guard = (i, j);
                        _initialStart = (i, j);
                        TraversedCoordinates.Add(Guard);
                    }
                }
            }
        }

        public override T SolveFirstProblem<T>()
        {
            CalculateGuardsTrajectory('^', (-1, 0));

            //for (int i = 0; i < MaxY; i++)
            //{
            //    for (int j = 0; j < MaxX; j++)
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //        if (Map[i, j] == 'X')
            //        {
            //            Console.ForegroundColor = ConsoleColor.Green;
            //        }
            //        if ((i, j) == _initialStart)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Cyan;
            //        }
                    
            //        Console.Write(Map[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            Sum = TraversedCoordinates.Distinct().Count();

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {

            Console.WriteLine("Starting PART 2");
            Sum = 0;

            for (int i = 0; i < MaxY; i++)
            {
                for (int j = 0; j < MaxX; j++)
                {
                    Guard = _initialStart;
                    Part2HitOccurrences = 0;
                    if ((i, j) == _initialStart || Map[i, j] == '#')
                        continue;
                    Map[i, j] = '0';
                    CalculateGuardsTrajectory('^', (-1, 0));
                    if (Part2HitOccurrences == 2)
                        Sum++;
                    Map[i, j] = '.';
                    Part2HitOccurrences = 0;

                }
                Console.WriteLine();
            }

            return (T)Convert.ChangeType(Sum, typeof(T));
        }


        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        void CalculateGuardsTrajectory(char directionalArrow, (int yPos, int xPos) direction)
        {
            while (true)
            {
                (int yPos, int xPos) nextPos = (Guard.yPos + direction.yPos, Guard.xPos + direction.xPos);
                if (IsNextPositionOutOfBounds(Guard, direction))
                    return;
                //else if (Map[nextPos.xPos, nextPos.yPos] == '#')
                //    break;
                else
                {
                    var temp = Map[nextPos.yPos, nextPos.xPos];
                    if (temp == '#')
                    {
                        break;
                    }
                    else
                    {

                        if (temp == '0')
                        {
                            Part2HitOccurrences++;
                            if (Part2HitOccurrences == 2)
                                return;
                        }
                        Guard = nextPos;
                        TraversedCoordinates.Add(nextPos);
                        Map[nextPos.yPos, nextPos.xPos] = 'X';
                    }
                }
            }


            if (directionalArrow == '^')
            {
                Console.WriteLine($"TURNING > AT {Guard}");
                CalculateGuardsTrajectory('>', (0, 1));
            }


            else if (directionalArrow == '>')
            {

                Console.WriteLine($"TURNING v AT {Guard}");
                CalculateGuardsTrajectory('v', (1, 0));
            }

            else if (directionalArrow == 'v')
            {

                Console.WriteLine($"TURNING < AT {Guard}");
                CalculateGuardsTrajectory('<', (0, -1));
            }

            else
            {

                Console.WriteLine($"TURNING ^ AT {Guard}");
                CalculateGuardsTrajectory('^', (-1, 0));
            }
        }

        bool IsNextPositionOutOfBounds((int yPos, int xPos) guardPos, (int yPos, int xPos) direction)
        {
            return guardPos.xPos + direction.xPos == -1 || 
                   guardPos.yPos + direction.yPos == -1 ||
                   guardPos.xPos + direction.xPos == MaxX + 1 || 
                   guardPos.yPos + direction.yPos == MaxY + 1;
        }

        #endregion

    }
}
