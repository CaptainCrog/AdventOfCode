using CommonTypes.CommonTypes.Classes;

namespace AdventOfCode2015.Problems
{
    public class Day3 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        string _movements = string.Empty;
        Node[] _santaPositions = [];
        Node[] _roboSantaPositions = [];

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
        public Day3(string inputPath)
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
            _movements = File.ReadAllText(_inputPath);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            _santaPositions = new Node[_movements.Length + 1];
            var currentNode = new Node() { X = 0, Y = 0 };
            _santaPositions[0] = currentNode;
            for (int i = 0; i < _movements.Length; i++)
            {
                var movement = _movements[i];
                var nextNode = new Node() { X = currentNode.X, Y = currentNode.Y };
                if (movement == '^')
                {
                    nextNode.X = currentNode.X + 1;
                    _santaPositions[i+1] = nextNode;
                }
                else if (movement == '>')
                {
                    nextNode.Y = currentNode.Y + 1;
                    _santaPositions[i+1] = nextNode;
                }
                else if (movement == 'v')
                {
                    nextNode.X = currentNode.X - 1;
                    _santaPositions[i+1] = nextNode;
                }
                else
                {
                    nextNode.Y = currentNode.Y - 1;
                    _santaPositions[i+1] = nextNode;
                }
                currentNode = nextNode;
            }

            var distinctPositions = _santaPositions.DistinctBy(node => new { node.X, node.Y }).ToList();

            return (T)Convert.ChangeType(distinctPositions.Count, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {

            _santaPositions = new Node[_movements.Length/2 + 1];
            _roboSantaPositions = new Node[_movements.Length / 2 + 1];
            var currentSantaNode = new Node() { X = 0, Y = 0 };
            var currentRoboSantaNode = new Node() { X = 0, Y = 0 };
            _santaPositions[0] = currentSantaNode;
            _roboSantaPositions[0] = currentRoboSantaNode;
            var santaIterator = 1;
            var roboSantaIterator = 1;

            for (int i = 0; i < _movements.Length; i++)
            {
                var movement = _movements[i];
                if (i % 2 == 0)
                {
                    var nextNode = new Node() { X = currentSantaNode.X, Y = currentSantaNode.Y };
                    if (movement == '^')
                    {
                        nextNode.X = currentSantaNode.X + 1;
                        _santaPositions[santaIterator] = nextNode;
                    }
                    else if (movement == '>')
                    {
                        nextNode.Y = currentSantaNode.Y + 1;
                        _santaPositions[santaIterator] = nextNode;
                    }
                    else if (movement == 'v')
                    {
                        nextNode.X = currentSantaNode.X - 1;
                        _santaPositions[santaIterator] = nextNode;
                    }
                    else
                    {
                        nextNode.Y = currentSantaNode.Y - 1;
                        _santaPositions[santaIterator] = nextNode;
                    }
                    currentSantaNode = nextNode;
                    santaIterator++;
                }
                else
                {
                    var nextNode = new Node() { X = currentRoboSantaNode.X, Y = currentRoboSantaNode.Y };
                    if (movement == '^')
                    {
                        nextNode.X = currentRoboSantaNode.X + 1;
                        _roboSantaPositions[roboSantaIterator] = nextNode;
                    }
                    else if (movement == '>')
                    {
                        nextNode.Y = currentRoboSantaNode.Y + 1;
                        _roboSantaPositions[roboSantaIterator] = nextNode;
                    }
                    else if (movement == 'v')
                    {
                        nextNode.X = currentRoboSantaNode.X - 1;
                        _roboSantaPositions[roboSantaIterator] = nextNode;
                    }
                    else
                    {
                        nextNode.Y = currentRoboSantaNode.Y - 1;
                        _roboSantaPositions[roboSantaIterator] = nextNode;
                    }
                    currentRoboSantaNode = nextNode;
                    roboSantaIterator++;
                }
            }
            var allPositions = _santaPositions.Concat(_roboSantaPositions).ToArray();
            var distinctSantaPositions = allPositions.DistinctBy(node => new { node.X, node.Y }).ToList();

            return (T)Convert.ChangeType(distinctSantaPositions.Count(), typeof(T));
        }

        #endregion
    }
}
