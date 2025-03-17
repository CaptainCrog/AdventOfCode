using AdventOfCode2017.CommonInternalTypes;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2017.Problems
{
    public class Day15 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        long _generatorA = 0;
        long _generatorB = 0;
        int _generatorAFactor = 16807;
        int _generatorBFactor = 48271;
        Queue<long> _generatorAValues = new();
        Queue<long> _generatorBValues = new();


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
        public Day15(string inputPath) 
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
            var numberRegex = CommonRegexHelpers.NumberRegex();
            var startingValues = File.ReadAllLines(_inputPath);
            for (int i = 0; i < startingValues.Length; i++) 
            {
                var match = int.Parse(numberRegex.Match(startingValues[i]).Value);
                if (i % 2 == 0)
                    _generatorA = match;
                else
                    _generatorB = match;
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            long generatorACopy = _generatorA;
            long generatorBCopy = _generatorB;
            for (int i = 0; i < 40000000; i++)
            {
                ProcessGenerators(ref generatorACopy, ref generatorBCopy, false);
            }

            var result = JudgeValues(false);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            long generatorACopy = _generatorA;
            long generatorBCopy = _generatorB;
            for (int i = 0; i < 40000000; i++)
            {
                ProcessGenerators(ref generatorACopy, ref generatorBCopy, true);
            }
            var result = JudgeValues(true);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        void ProcessGenerators(ref long generatorA, ref long generatorB, bool part2)
        {
            generatorA = (generatorA * _generatorAFactor) % 2147483647;
            generatorB = (generatorB * _generatorBFactor) % 2147483647;

            if (part2)
            {
                if (generatorA % 4 == 0)
                    _generatorAValues.Enqueue(generatorA);
                if (generatorB % 8 == 0)
                    _generatorBValues.Enqueue(generatorB);
            }
            else
            {
                _generatorAValues.Enqueue(generatorA);
                _generatorBValues.Enqueue(generatorB);
            }
        }

        int JudgeValues(bool part2)
        {
            var limit = int.MaxValue;
            if (part2)
                limit = 5000000;

            var numberOfPairs = 0;
            var iterator = 0;
            while (_generatorAValues.Count > 0 && _generatorBValues.Count > 0 && iterator != limit)
            {
                if (JudgePair(_generatorAValues.Dequeue(), _generatorBValues.Dequeue()))
                    numberOfPairs++;
                iterator++;
            }
            return numberOfPairs;
        }

        bool JudgePair(long generatorAValue, long generatorBValue)
        {
            var binaryA = Convert.ToString(generatorAValue, 2).PadLeft(16, '0');
            var binaryB = Convert.ToString(generatorBValue, 2).PadLeft(16, '0');
            binaryA = binaryA.Substring(binaryA.Length - 16);
            binaryB = binaryB.Substring(binaryB.Length - 16);
            if (binaryA.Equals(binaryB))
                return true;
            return false;
        }
        #endregion
    }
}
