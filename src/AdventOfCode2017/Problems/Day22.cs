using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Enums;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdventOfCode2017.Problems
{
    public class Day22 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Dictionary<Point, VirusState> _nodes = new();
        Node _currentNode = new();
        int _numberOfBursts = 0;


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
        public Day22(string inputPath, int numberOfBursts) 
        {
            _inputPath = inputPath;
            _numberOfBursts = numberOfBursts;
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
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '.')
                        _nodes.Add(new Point() { X = i, Y = j }, VirusState.Clean);
                    else
                        _nodes.Add(new Point() { X = i, Y = j }, VirusState.Infected);
                }
            }
            //Start node in the center
            _currentNode = new Node() { X = input.Length/2, Y = input[0].Length/2};

        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = 0;
            var currentNodeCopy = new Node() { X = _currentNode.X, Y = _currentNode.Y };
            var nodesCopy = _nodes.ToDictionary();
            for (int i = 0; i < 10000000; i++)
            {
                var key = new Point() { X = currentNodeCopy.X, Y = currentNodeCopy.Y };
                nodesCopy.TryAdd(key, VirusState.Clean);

                var currentState = nodesCopy[key];
                if (currentState == VirusState.Infected)
                {
                    Rotate(ref currentNodeCopy, true);
                    nodesCopy[key] = VirusState.Clean;
                }
                else
                {
                    Rotate(ref currentNodeCopy, false);
                    nodesCopy[key] = VirusState.Infected;
                    result++;
                }

                Move(ref currentNodeCopy);

            }
            return (T)Convert.ChangeType(result, typeof(T));

        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = 0;
            var currentNodeCopy = new Node() { X = _currentNode.X, Y = _currentNode.Y };
            var nodesCopy = _nodes.ToDictionary();
            for (int i = 0; i < 10000000; i++)
            {
                var key = new Point() { X = currentNodeCopy.X, Y = currentNodeCopy.Y };
                _nodes.TryAdd(key, VirusState.Clean);

                var currentState = _nodes[key];
                if (currentState == VirusState.Infected)
                {
                    Rotate(ref currentNodeCopy, true);
                    _nodes[key] = VirusState.Flagged;
                }
                else if (currentState == VirusState.Weakened)
                {
                    _nodes[key] = VirusState.Infected;
                    result++;
                }
                else if ( currentState == VirusState.Clean)
                {
                    Rotate(ref currentNodeCopy, false);
                    _nodes[key] = VirusState.Weakened;
                }
                else
                {
                    Reverse(ref currentNodeCopy);
                    _nodes[key] = VirusState.Clean;
                }

                Move(ref currentNodeCopy);

            }
            return (T)Convert.ChangeType(result, typeof(T));
        }

        void Rotate(ref Node node, bool clockwise)
        {
            if (clockwise)
            {
                if (node.Direction == Direction.West)
                    node.Direction = Direction.North;
                else
                    node.Direction++;
            }
            else
            {

                if (node.Direction == Direction.North)
                    node.Direction = Direction.West;
                else
                    node.Direction--;
            }
        }

        void Move(ref Node node)
        {
            if (node.Direction == Direction.North)
                node.X--;
            else if (node.Direction == Direction.East)
                node.Y++;
            else if (node.Direction == Direction.South)
                node.X++;
            else
                node.Y--;
        }

        void Reverse(ref Node node)
        {
            switch (node.Direction)
            {
                case Direction.North:
                    node.Direction = Direction.South;
                    break;

                case Direction.South:
                    node.Direction = Direction.North;
                    break;

                case Direction.West:
                    node.Direction = Direction.East;
                    break;

                case Direction.East:
                    node.Direction = Direction.West;
                    break;

            }
        }
        enum VirusState
        {
            Clean,
            Weakened,
            Infected,
            Flagged
        }

        #endregion
    }
}
