using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day19 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _numberOfElves = 0;

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
        public Day19(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _numberOfElves = int.Parse(File.ReadAllText(_inputPath));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {

            int largestExponent = (int)Math.Log2(_numberOfElves);
            int powerOf2 = (int)Math.Pow(2, largestExponent);
            var result = 2 * (_numberOfElves - powerOf2) + 1;

            return (T)Convert.ChangeType(result, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            //int survivor = 0; // g(1, k) = 0
            //var reducedElves = _numberOfElves;
            //for (int i = 2; i <= _numberOfElves; i++)
            //{
            //    var k = reducedElves / 2;
            //    survivor = (survivor + k) % i;
            //    reducedElves--;
            //}
            //var result = survivor + 1; // Convert from 0-based to 1-based index


            LinkedList<int> prisoners = new LinkedList<int>();
            for (int i = 1; i <= _numberOfElves; i++)
            {
                prisoners.AddLast(i); // Populate the list with prisoner numbers
            }

            LinkedListNode<int> current = prisoners.First;

            while (prisoners.Count > 1)
            {
                // Find the opposite person
                int steps = prisoners.Count / 2;
                //ADD IF MODULUS CHECK
                LinkedListNode<int> opposite = current;
                for (int i = 0; i < steps; i++)
                {
                    opposite = (opposite.Next != null) ? opposite.Next : prisoners.First;
                }

                // Remove the opposite prisoner
                LinkedListNode<int> next = (opposite.Next != null) ? opposite.Next : prisoners.First;
                prisoners.Remove(opposite);

                // Move to the next survivor
                current = next;
            }

            var result = prisoners.First.Value; // Return the last remaining prisoner


            return (T)Convert.ChangeType(result, typeof(T));
            //915059 too Low

        }

        #endregion

    }
}