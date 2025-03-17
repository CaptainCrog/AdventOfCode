using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using System.Diagnostics;

namespace AdventOfCode2017.Problems
{
    public class Day17 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        string _secondResult = string.Empty;
        int _stepsToTake = 0;
        List<int> _spinLock = new() { 0 };
        int _currentPosition = 0;



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
        public string SecondResult
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
        public Day17(string inputPath) 
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods

        public void InitialiseProblem()
        {
            _stepsToTake = int.Parse(File.ReadAllText(_inputPath));
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            for (int i = 1; i < 2018; i++)
            {
                ProcessSpinlock(i);
            }

            var result = _currentPosition + 1 >= _spinLock.Count - 1 ? _spinLock[(_currentPosition + 1) % _spinLock.Count] : _spinLock[_currentPosition + 1];

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            for (int i = 2018; i <= 50000000; i++)
            {
                ProcessSpinlock(i);
            }

            var result = Array.IndexOf(_spinLock.ToArray(), 0);
            return (T)Convert.ChangeType("", typeof(T));
        }
        //Each element processed has a difference of 381 from the previous
        void ProcessSpinlock(int indexValue)
        {
            _currentPosition += _stepsToTake;
            if (_currentPosition >= _spinLock.Count)
                _currentPosition %= _spinLock.Count;


            if (_currentPosition == _spinLock.Count - 1)
                _spinLock.Add(indexValue);
            else
                _spinLock.Insert(_currentPosition + 1, indexValue);
            _currentPosition++;
        }

        #endregion
    }
}
