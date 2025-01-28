using CommonTypes.CommonTypes.Classes;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day6 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        bool[,] _lightGrid = new bool[1000, 1000];
        int[,] _brightnessGrid = new int[1000, 1000];
        List<LightChange> _lightChanges = new();

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
        public Day6(string inputPath)
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
            var input = File.ReadLines(_inputPath).ToArray();
            foreach (var line in input)
            {
                var numberRegex = new Regex(@"\d+");
                var matches = numberRegex.Matches(line);
                var fromX = int.Parse(matches[0].Value);
                var fromY = int.Parse(matches[1].Value);
                var toX = int.Parse(matches[2].Value);
                var toY = int.Parse(matches[3].Value);
                if (line.Contains("turn"))
                {
                    if (line.Contains("on"))
                    {
                        _lightChanges.Add(new LightChange(LightCommand.ON, fromX, fromY, toX, toY));
                    }
                    else
                    {
                        _lightChanges.Add(new LightChange(LightCommand.OFF, fromX, fromY, toX, toY));
                    }
                }
                else
                {
                    _lightChanges.Add(new LightChange(LightCommand.SWITCH, fromX, fromY, toX, toY));
                }
            }

        }

        public override T SolveFirstProblem<T>()
        {
            foreach (var lightChange in _lightChanges)
            {
                for (int i = lightChange.From.X; i <= lightChange.To.X; i++)
                {
                    for (int j = lightChange.From.Y; j <= lightChange.To.Y; j++)
                    {
                        bool lightState;

                        if (lightChange.LightCommand == LightCommand.ON)
                            lightState = true;
                        else if (lightChange.LightCommand == LightCommand.OFF)
                            lightState = false;
                        else
                            lightState = !_lightGrid[i, j];

                        _lightGrid[i, j] = lightState;
                    }
                }
            }

            var lightsOn = 0;

            for (int i = 0; i < _lightGrid.GetLength(0); i++)
            {
                for (int j = 0; j < _lightGrid.GetLength(1); j++)
                {
                    if (_lightGrid[i, j] == true)
                        lightsOn++;
                }
            }

            return (T)Convert.ChangeType(lightsOn, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            foreach (var lightChange in _lightChanges)
            {
                for (int i = lightChange.From.X; i <= lightChange.To.X; i++)
                {
                    for (int j = lightChange.From.Y; j <= lightChange.To.Y; j++)
                    {
                        int lightBrightness;
                        long currentBrightness = _brightnessGrid[i, j];

                        if (lightChange.LightCommand == LightCommand.ON)
                            lightBrightness = 1;
                        else if (lightChange.LightCommand == LightCommand.OFF)
                        {
                            if (currentBrightness != 0)
                                lightBrightness = -1;
                            else
                                lightBrightness = 0;
                        }
                        else
                            lightBrightness = 2;

                        _brightnessGrid[i, j] = _brightnessGrid[i, j] += lightBrightness;
                    }
                }
            }

            int lightsTotalBrightness = 0;

            for (int i = 0; i < _brightnessGrid.GetLength(0); i++)
            {
                for (int j = 0; j < _brightnessGrid.GetLength(1); j++)
                {
                    lightsTotalBrightness += _brightnessGrid[i, j];
                }
            }


            return (T)Convert.ChangeType(lightsTotalBrightness, typeof(T));
        }


        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion

    }

    internal class LightChange
    {
        LightCommand _lightCommand;
        Node _from;
        Node _to;

        public LightCommand LightCommand
        {
            get => _lightCommand;
            private set
            {
                if (_lightCommand != value)
                {
                    _lightCommand = value;
                }
            }
        }


        public Node From
        {
            get => _from;
            private set
            {
                if (_from != value)
                {
                    _from = value;
                }
            }
        }


        public Node To
        {
            get => _to;
            private set
            {
                if (_to != value)
                {
                    _to = value;
                }
            }
        }

        public LightChange(LightCommand lightCommand, int fromX, int fromY, int toX, int toY)
        {
            LightCommand = lightCommand;
            From = new Node() { X = fromX, Y = fromY };
            To = new Node() { X = toX, Y = toY };
        }
    }

    internal enum LightCommand
    {
        ON = 1,
        OFF = 2,
        SWITCH = 3,
    }
}
