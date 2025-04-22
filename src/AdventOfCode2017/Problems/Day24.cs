using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using System.Linq;

namespace AdventOfCode2017.Problems
{
    public class Day24 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        List<(int Connection1, int Connection2)> _connections = [];


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
        public Day24(string inputPath)
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
            var input = File.ReadAllLines(_inputPath);
            foreach (var connections in input)
            {
                var parts = connections.Split('/');
                _connections.Add(new (int.Parse(parts[0]), int.Parse(parts[1])));
            }
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var used = new HashSet<int>();
            (int maxStrength, int maxLength) = Build(0, _connections, used, 0, 0, false);

            return (T)Convert.ChangeType(maxStrength, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {

            var used = new HashSet<int>();
            (int maxStrength, int maxLength) = Build(0, _connections, used, 0, 0, true);

            return (T)Convert.ChangeType(maxStrength, typeof(T));
        }

        (int maxStrength, int maxLength) Build(int currentPort, List<(int a, int b)> components, HashSet<int> used, int currentLength, int currentStrength, bool part2)
        {
            int maxStrength = currentStrength;
            int maxLength = currentLength;

            for (int i = 0; i < components.Count; i++)
            {
                if (used.Contains(i))
                    continue;

                var (a, b) = components[i];

                if (a == currentPort || b == currentPort)
                {
                    int nextPort = (a == currentPort) ? b : a;
                    used.Add(i);
                    var (nextStrength, nextLength) = Build(nextPort, components, used, currentLength + 1, currentStrength + a + b, part2);


                    if (part2)
                    {
                        // Longer bridge found -> reset the maxLength and maxStrength
                        if (nextLength > maxLength)
                        {
                            maxLength = nextLength;
                            maxStrength = nextStrength;
                        }
                        // Same length bridge and stronger -> update maxStrength
                        else if (nextLength == maxLength)
                        {
                            maxStrength = Math.Max(maxStrength, nextStrength);
                        }
                    }
                    else
                        maxStrength = Math.Max(maxStrength, nextStrength);

                    used.Remove(i);
                }
            }

            return (maxStrength, maxLength);
        }

        #endregion
    }
}
