using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2024.Problems
{
    public class Day25 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        List<int[]> _locks = new();
        List<int[]> _keys = new();

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
        #endregion

        #region Constructor
        public Day25(string inputPath)
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
            var inputGrids = File.ReadAllText(_inputPath).Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (var grid in inputGrids)
            {
                ProcessGrid(grid);
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            foreach (var fivePinLock in _locks)
            {
                foreach (var key in _keys)
                {
                    var isValid = true;
                    for (int i = 0; i < fivePinLock.Length; i++)
                    {
                        if (fivePinLock[i] + key[i] > 5)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        Sum++;
                    }
                }
            }

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = 0;
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        void ProcessGrid(string stringGridRaw) 
        {
            var stringGrid = stringGridRaw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (stringGrid[0].Contains('#')) //LOCK
            {
                //var grid = new char[stringGrid.GetLength(0), stringGrid.GetLength(1)];
                var positions = new int[5];

                // foreach column, go through all rows till we hit a '.'
                for (int i = 0; i < positions.Length; i++)
                {
                    for (int j = 0; j < stringGrid.GetLength(0); j++)
                    {
                        if (stringGrid[j][i] == '.')
                        {
                            positions[i] = j-1;
                            break;
                        }
                    }
                }

                _locks.Add(positions);
            }
            else //KEY
            {
                //var grid = new char[stringGrid.GetLength(0), stringGrid.GetLength(1)];
                var positions = new int[5];

                // foreach column, go through all rows backwards till we hit a '.'
                for (int i = 0; i < positions.Length; i++)
                {
                    int iterator = 0;
                    for (int j = stringGrid.GetLength(0)-1; j >= 0; j--)
                    {
                        if (stringGrid[j][i] == '.')
                        {
                            positions[i] = iterator-1;
                            break;
                        }
                        iterator++;
                    }
                }

                _keys.Add(positions);
            }
        }
        #endregion
    }
}
