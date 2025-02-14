using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day21 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        string _secondResult = string.Empty;
        string[] _instructions = [];
        string _scrambledResult = string.Empty;
        Regex _numberRegex = CommonRegexHelpers.NumberRegex();
        Regex _charRegex = InstructionLetters();


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
        public string FirstResult
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
        public Day21(string inputPath, string scrambledPassword)
        {
            _inputPath = inputPath;
            _scrambledResult = scrambledPassword;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public void InitialiseProblem()
        {
            _instructions = File.ReadAllLines(_inputPath);
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = ProcessPassword(_scrambledResult, false);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public T SolveSecondProblem<T>() where T : IConvertible
        {
            _instructions = _instructions.Reverse().ToArray();
            var result = ProcessPassword("fbgdceah", true);
            return (T)Convert.ChangeType(result, typeof(T));

        }
        //bahcdefg wrong
        //hefbgacd wrong

        string ProcessPassword(string scrambledResult, bool reverse)
        {
            var firstNum = 0;
            var secondNum = 0;
            var firstChar = '!';
            var secondChar = '!';
            foreach (var instruction in _instructions)
            {
                if (instruction.Contains("swap"))
                {
                    if (instruction.Contains("position"))
                    {
                        var numbers = _numberRegex.Matches(instruction);
                        if (reverse)
                        {
                            firstNum = int.Parse(numbers[1].Value);
                            secondNum = int.Parse(numbers[0].Value);
                        }
                        else
                        {
                            firstNum = int.Parse(numbers[0].Value);
                            secondNum = int.Parse(numbers[1].Value);
                        }
                        scrambledResult = SwapPositions(scrambledResult.ToCharArray(), firstNum, secondNum);
                    }
                    else
                    {
                        var letters = _charRegex.Matches(instruction);

                        if (reverse)
                        {
                            firstChar = letters[1].Value.Trim().First();
                            secondChar = letters[0].Value.Trim().First();
                        }
                        else
                        {
                            firstChar = letters[0].Value.Trim().First();
                            secondChar = letters[1].Value.Trim().First();
                        }
                        scrambledResult = SwapLetters(scrambledResult, firstChar, secondChar);
                    }
                }

                if (instruction.Contains("rotate"))
                {
                    if (instruction.Contains("position"))
                    {
                        var letter = _charRegex.Match(instruction);
                        scrambledResult = RotateFromLetterIndex(scrambledResult, letter.Value.Trim().First(), reverse);
                    }
                    else
                    {
                        var number = _numberRegex.Match(instruction);
                        var rotateRight = instruction.Contains("right");
                        if (reverse)
                            rotateRight = !rotateRight;
                        scrambledResult = Rotate(scrambledResult.ToCharArray(), rotateRight, int.Parse(number.Value));
                    }
                }

                if (instruction.Contains("reverse"))
                {
                    var numbers = _numberRegex.Matches(instruction);

                    scrambledResult = ReversePositions(scrambledResult, int.Parse(numbers[0].Value), int.Parse(numbers[1].Value));
                }

                if (instruction.Contains("move"))
                {
                    var numbers = _numberRegex.Matches(instruction);
                    if (reverse)
                    {
                        firstNum = int.Parse(numbers[1].Value);
                        secondNum = int.Parse(numbers[0].Value);
                    }
                    else
                    {
                        firstNum = int.Parse(numbers[0].Value);
                        secondNum = int.Parse(numbers[1].Value);
                    }
                    scrambledResult = Move(scrambledResult, firstNum, secondNum, reverse);
                }
            }

            return scrambledResult;
        }

        string SwapPositions(char[] scrambledPassword, int firstPosition, int secondPosition)
        {
            var temp = scrambledPassword[firstPosition];
            scrambledPassword[firstPosition] = scrambledPassword[secondPosition];
            scrambledPassword[secondPosition] = temp;

            return string.Join("", scrambledPassword);
        }

        string SwapLetters(string scrambledPassword, char firstLetter, char secondLetter)
        {
            return SwapPositions(scrambledPassword.ToCharArray(), scrambledPassword.IndexOf(firstLetter), scrambledPassword.IndexOf(secondLetter));
        }

        string Rotate(char[] scrambledPassword, bool rotateRight, int steps)
        {
            if (rotateRight)
                scrambledPassword = ArrayHelperFunctions.ShiftBackwards(scrambledPassword, steps);
            else
                scrambledPassword = ArrayHelperFunctions.ShiftForwards(scrambledPassword, steps);

            return string.Join("", scrambledPassword);
        }

        string RotateFromLetterIndex(string scrambledPassword, char letter, bool reverse)
        {
            var steps = scrambledPassword.IndexOf(letter) + 1;
            if (scrambledPassword.IndexOf(letter) >= 4)
                steps++;

            return Rotate(scrambledPassword.ToCharArray(), !reverse, steps);
        }

        string ReversePositions(string scrambledPassword, int firstPosition, int lastPosition)
        {
            while (firstPosition < lastPosition)
            {
                scrambledPassword = SwapPositions(scrambledPassword.ToCharArray(), firstPosition, lastPosition);
                firstPosition++;
                lastPosition--;
            }
            return scrambledPassword;
        }

        string Move(string scrambledPassword, int fromPosition, int toPosition, bool reverse)
        {
            bool rotateRight = toPosition - fromPosition > 0;
            //if (reverse)
            //    rotateRight = !rotateRight;

            int iterator = fromPosition;
            while (iterator != toPosition)
            {
                scrambledPassword = SwapPositions(scrambledPassword.ToCharArray(), iterator, rotateRight ? iterator + 1 : iterator - 1);
                if (rotateRight)
                    iterator++;
                else
                    iterator--;
            }
            return scrambledPassword;
        }


        [GeneratedRegex(@"\b[a-z]\b")]
        private static partial Regex InstructionLetters();

        #endregion

    }
}