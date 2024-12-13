using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public partial class Day13 : DayBase
    {
        #region Fields
        //string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\TestInputs\AdventOfCode2024Day13TestInput.txt";
        string _inputPath = @"C:\Users\Craig\Desktop\AdventOfCodePuzzleInputs\2024\PuzzleInputs\AdventOfCode2024Day13PuzzleInput.txt";
        long _firstResult = 0;
        ulong _secondResult = 0;
        string[] _gardenPlot = [];
        char[] _distinctPlotValues = [];
        List<ClawMachine> _clawMachines = [];
        MatchCollection _clawMachineMatches;
        int _buttonAToken = 3;
        int _buttonBToken = 1;

        Dictionary<string, List<(int row, int col)>> _plotSummary = new Dictionary<string, List<(int row, int col)>>();

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


        long FirstResult
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
        ulong SecondResult
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

        List<ClawMachine> ClawMachines
        {
            get => _clawMachines;
            set
            {
                if (_clawMachines != value)
                {
                    _clawMachines = value;
                }
            }
        }

        MatchCollection ClawMachineMatches
        {
            get => _clawMachineMatches;
            set
            {
                if (_clawMachineMatches != value)
                {
                    _clawMachineMatches = value;
                }
            }

        }

        #endregion

        #region Constructor
        public Day13()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<long>();
            SecondResult = SolveSecondProblem<ulong>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            var input = File.ReadAllText(InputPath);
            var inputRegex = InputRegex();
            ClawMachineMatches = inputRegex.Matches(input);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            long sum = 0;

            var buttonRegex = ButtonRegex();
            var prizeRegex = PrizeRegex();
            ClawMachines = new List<ClawMachine>();

            foreach (var match in ClawMachineMatches)
            {
                var clawMachineDetails = match.ToString().Trim().Split("\r\n");
                var buttonA = buttonRegex.Matches(clawMachineDetails[0]);
                var buttonB = buttonRegex.Matches(clawMachineDetails[1]);
                var prize = prizeRegex.Matches(clawMachineDetails[2]);

                ClawMachines.Add(new ClawMachine()
                {
                    ButtonA = new Button(long.Parse(buttonA[1].Value[2..]), long.Parse(buttonA[2].Value[2..])),
                    ButtonB = new Button(long.Parse(buttonB[1].Value[2..]), long.Parse(buttonB[2].Value[2..])),
                    Prize = (long.Parse(prize[1].Value[2..]), long.Parse(prize[2].Value[2..]))
                });
            }

            foreach (var clawMachine in ClawMachines)
            {
                (int aPresses, int bPresses) presses = BreadthFirstSearch(clawMachine);
                if (presses != (-1, -1))
                    sum += (presses.aPresses * _buttonAToken + presses.bPresses * _buttonBToken);
            }


            return (T)Convert.ChangeType(sum, typeof(T));
            //29711
        }

        public override T SolveSecondProblem<T>()
        {
            long sum = 0;

            var buttonRegex = ButtonRegex();
            var prizeRegex = PrizeRegex();
            ClawMachines = new List<ClawMachine>();

            foreach (var match in ClawMachineMatches)
            {
                var clawMachineDetails = match.ToString().Trim().Split("\r\n");
                var buttonA = buttonRegex.Matches(clawMachineDetails[0]);
                var buttonB = buttonRegex.Matches(clawMachineDetails[1]);
                var prize = prizeRegex.Matches(clawMachineDetails[2]);

                ClawMachines.Add(new ClawMachine()
                {
                    ButtonA = new Button(long.Parse(buttonA[1].Value[2..]), long.Parse(buttonA[2].Value[2..])),
                    ButtonB = new Button(long.Parse(buttonB[1].Value[2..]), long.Parse(buttonB[2].Value[2..])),
                    Prize = (10000000000000 + long.Parse(prize[1].Value[2..]), 10000000000000 + long.Parse(prize[2].Value[2..]))
                });
            }

            foreach (var clawMachine in ClawMachines)
            {
                (int aPresses, int bPresses) presses = BreadthFirstSearch(clawMachine);
                if (presses != (-1, -1))
                    sum += (presses.aPresses * _buttonAToken + presses.bPresses * _buttonBToken);
            }

            return (T)Convert.ChangeType(0, typeof(T));
        }

        (int buttonAPressedCount, int buttonBPressedCount) BreadthFirstSearch(ClawMachine clawMachine)
        {
            var queue = new Queue<(long x, long y, int buttonAPressedCount, int buttonBPressedCount)>(new[] {(0L,0L,0,0)});
            var visitedSequences = new HashSet<(long x, long y)>();

            while (queue.Count() != 0)
            {
                var (x, y, buttonAPressedCount, buttonBPressedCount) = queue.Dequeue();

                if ((x, y) == (clawMachine.Prize.xValue, clawMachine.Prize.yValue))
                    return (buttonAPressedCount, buttonBPressedCount);

                if (!visitedSequences.Add((x, y)) || x > clawMachine.Prize.xValue || y > clawMachine.Prize.yValue)
                    continue;

                queue.Enqueue((x + clawMachine.ButtonA.XMovement, y + clawMachine.ButtonA.YMovement, buttonAPressedCount + 1, buttonBPressedCount));
                queue.Enqueue((x + clawMachine.ButtonB.XMovement, y + clawMachine.ButtonB.YMovement, buttonAPressedCount, buttonBPressedCount + 1));
            }

            return (-1, -1);
        }

        #endregion


        [GeneratedRegex(@"(?:(?:Button A:.*?\nButton B:.*?\nPrize:.*?)(?:\n|$))")]
        private static partial Regex InputRegex();
        [GeneratedRegex(@"(Button [AB])|X\+\d+|Y\+\d+")]
        private static partial Regex ButtonRegex();
        [GeneratedRegex(@"(Prize)|X\=\d+|Y\=\d+")]
        private static partial Regex PrizeRegex();
    }

    public class ClawMachine
    {
        Button _buttonA;
        Button _buttonB;
        (long xValue, long yValue) _prize;


        public Button ButtonA
        {
            get => _buttonA;
            set
            {
                if (_buttonA != value)
                {
                    _buttonA = value;
                }
            }
        }
        public Button ButtonB
        {
            get => _buttonB;
            set
            {
                if (_buttonB != value)
                {
                    _buttonB = value;
                }
            }
        }

        public (long xValue, long yValue) Prize
        {
            get => _prize;
            set
            {
                if (_prize != value)
                {
                    _prize = value;
                }
            }
        }
    }

    public class Button
    {
        long _xMovement;
        long _yMovement;

        public long XMovement
        {
            get => _xMovement;
            set
            {
                if (_xMovement != value)
                {
                    _xMovement = value;
                }
            }
        }
        public long YMovement
        {
            get => _yMovement;
            set
            {
                if (_yMovement != value)
                {
                    _yMovement = value;
                }
            }
        }

        public Button(long xMovement, long yMovement)
        {
            XMovement = xMovement;
            YMovement = yMovement;
        }
    }
}
