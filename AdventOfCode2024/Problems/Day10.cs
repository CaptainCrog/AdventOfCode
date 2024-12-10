using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day10 : DayBase
    {
        #region Fields

        string _inputPath = @"PASTE PATH HERE";
        string[] _wordSearch = new string[0];
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;

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

        string[] WordSearch
        {
            get => _wordSearch;
            set
            {
                if (_wordSearch != value)
                {
                    _wordSearch = value;
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
        public Day10()
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
            WordSearch = File.ReadAllLines(InputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = 0;

            return (T)Convert.ChangeType(Sum, typeof(T));
        }


        #endregion
    }
}
