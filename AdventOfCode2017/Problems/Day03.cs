﻿using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2017.Problems
{
    public class Day03 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _puzzleNumber = 0;
        int _currentLevel = 0;
        (Node position, int value)[] _answerCorners = [];
        Dictionary<int, int> _squares = new();
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
        public Day03(string inputPath) 
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
            _puzzleNumber = int.Parse(File.ReadAllText(_inputPath));
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var iterator = 1;
            _currentLevel = 0;
            var result = 0;

            while (true)
            {
                var iteratorSquare = (int)Math.Pow(iterator, 2);
                _squares.Add(iterator, iteratorSquare);
                if (iteratorSquare >= _puzzleNumber)
                    break;
                else
                {
                    iterator += 2;
                    _currentLevel++;
                }
            }

            if (_squares.Count() != 1)
            {
                var currentNumber = _squares[iterator];
                var spiralSpace = currentNumber - _squares[iterator - 2];
                var spiralSideSpace = spiralSpace / 4;
                //populate just the corners and then from here we can work out which side the answer lies between
                _answerCorners =
                [
                    (new Node() { X = _currentLevel, Y = _currentLevel }, currentNumber),
                    (new Node() { X = _currentLevel, Y = -_currentLevel }, currentNumber - spiralSideSpace),
                    (new Node() { X = -_currentLevel, Y = -_currentLevel }, currentNumber - spiralSideSpace * 2),
                    (new Node() { X = -_currentLevel, Y = _currentLevel }, currentNumber - spiralSideSpace * 3),
                ];



                var answerPosition = new Node();
                // If a corner is the answer then we dont need to check further
                if (_answerCorners.Any(x => x.value == _puzzleNumber))
                    answerPosition = _answerCorners.Where(x => x.value == _puzzleNumber).Select(x => x.position).First();
                else
                {
                    var sidePosition = _answerCorners.Where(x => x.value > _puzzleNumber).Count();
                    var side = _answerCorners[sidePosition - 1];
                    var isNegative = sidePosition <= 2;
                    var isVertical = sidePosition % 2 == 0;

                    for (int i = 1; i <= Math.Sqrt(currentNumber) - 2; i++)
                    {
                        var nextNumber = side.value - i;
                        if (nextNumber == _puzzleNumber)
                        {
                            answerPosition = ProcessPosition(side.position, isNegative, isVertical, i);
                            break;
                        }
                    }
                }

                result = Math.Abs(answerPosition.X) + Math.Abs(answerPosition.Y);
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        Node ProcessPosition(Node corner, bool isNegative, bool isVertical, int iterator)
        {
            var answerPosition = new Node() { X = corner.X, Y = corner.Y};
            if (isNegative && isVertical)
            {
                answerPosition.X = corner.X - iterator;
            }
            else if (isNegative && !isVertical)
            {
                answerPosition.Y = corner.Y - iterator;
            }
            else if (!isNegative && isVertical)
            {
                answerPosition.X = corner.X + iterator;
            }
            else
            {
                answerPosition.Y = corner.Y + iterator;
            }

            return answerPosition;
        }

        #endregion
    }
}
