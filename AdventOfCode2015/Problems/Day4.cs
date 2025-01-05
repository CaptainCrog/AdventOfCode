namespace AdventOfCode2015.Problems
{
    public class Day4 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        string[] _wordSearch = new string[0];
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        int _maxX = 0;
        int _maxY = 0;

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

        string[] WordSearch
        {
            get => _wordSearch;
            set
            {
                if (_wordSearch != value)
                {
                    _wordSearch = value;
                }
            }
        }

        int Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }
        int MaxX
        {
            get => _maxX;
            set
            {
                if (_maxX != value)
                {
                    _maxX = value;
                }
            }
        }
        int MaxY
        {
            get => _maxY;
            set
            {
                if (_maxY != value)
                {
                    _maxY = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Day4(string inputPath)
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
            WordSearch = File.ReadAllLines(InputPath);
            MaxX = WordSearch[0].Length - 1;
            MaxY = WordSearch.Length - 1;
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            //Start off finding all X chars so we can expand outwards to find all XMAS instances
            var allXCoordinates = new List<(int yPosition, int xPosition)>();

            for (int i = 0; i <= MaxY; i++)
            {
                for (int j = 0; j <= MaxX; j++)
                {
                    if (WordSearch[i][j] == 'X')
                        allXCoordinates.Add((i, j));
                }
            }

            ProcessCoordinatesPart1(allXCoordinates);

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            Sum = 0;
            var allACoordinates = new List<(int yPosition, int xPosition)>();
            for (int i = 0; i <= MaxY; i++)
            {
                for (int j = 0; j <= MaxX; j++)
                {
                    if (WordSearch[i][j] == 'A')
                        allACoordinates.Add((i, j));
                }
            }

            ProcessCoordinatesPart2(allACoordinates);

            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        #region Part 1 Functions
        void ProcessCoordinatesPart1(List<(int yPosition, int xPosition)> allCharCoordinates)
        {
            foreach (var charCoordinate in allCharCoordinates)
            {
                CheckSurroundingChars(charCoordinate, null);
            }
        }

        void CheckSurroundingChars((int yPosition, int xPosition) currentCoordinate, (int yPosition, int xPosition)? currrentDirection = null)
        {
            // Create a list of allowed neighbours to check
            List<(int yPosition, int xPosition)> allowedDirections = new()
            {

            };
            if (!currrentDirection.HasValue)
            {
                allowedDirections = new()
                {
                    (-1, 1), ( 0, 1), ( 1, 1),
                    (-1, 0),          ( 1, 0),
                    (-1,-1), ( 0,-1), ( 1,-1),
                };
            }
            else
            {
                allowedDirections.Add(currrentDirection.Value);
            }

            var nextLetter = GetNextLetterForSequence(currentCoordinate);
            foreach (var allowedDirection in allowedDirections)
            {
                (int yPosition, int xPosition) direction = (currentCoordinate.yPosition + allowedDirection.yPosition, currentCoordinate.xPosition + allowedDirection.xPosition);
                try
                {
                    if (WordSearch[direction.yPosition][direction.xPosition] == nextLetter)
                    {
                        if (nextLetter != 'S')
                        {
                            CheckSurroundingChars(direction, allowedDirection);
                        }
                        else
                        {
                            Sum++;
                        }
                    }
                    else
                        continue;
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }


        char GetNextLetterForSequence((int yPosition, int xPosition) currentCoordinate)
        {
            var currentChar = WordSearch[currentCoordinate.yPosition][currentCoordinate.xPosition];
            if (currentChar == 'X')
                return 'M';
            else if (currentChar == 'M')
                return 'A';
            else if (currentChar == 'A')
                return 'S';
            else //Fallback in case of failure
                return '0';
        }
        #endregion

        #region Part 2 Functions


        void ProcessCoordinatesPart2(List<(int yPosition, int xPosition)> allCharCoordinates)
        {
            foreach (var charCoordinate in allCharCoordinates)
            {
                CheckSurroundingMAS(charCoordinate, null);
            }
        }

        void CheckSurroundingMAS((int yPosition, int xPosition) currentCoordinate, (int yPosition, int xPosition)? currrentDirection = null)
        {
            // Create a list of allowed neighbours to check
            List<List<(int yPosition, int xPosition)>> allowedPairedCoordinates = new()
            {
                    new List<(int yPosition, int xPosition)>{(-1, 1), ( 1,-1) },    // TR with BL
                    new List<(int yPosition, int xPosition)>{(-1, -1), ( 1, 1) },   // TL with BR
            };

            var firstDiagonal = CheckPairCreatesMAS(currentCoordinate, allowedPairedCoordinates.First());
            var secondDiagonal = CheckPairCreatesMAS(currentCoordinate, allowedPairedCoordinates.Last());
            if (firstDiagonal && secondDiagonal)
                Sum++;
        }

        bool CheckPairCreatesMAS((int yPosition, int xPosition) currentCoordinate, List<(int yPosition, int xPosition)> allowedPair)
        {
            (int yPosition, int xPosition) firstPair = (currentCoordinate.yPosition + allowedPair.First().yPosition, currentCoordinate.xPosition + allowedPair.First().xPosition);
            (int yPosition, int xPosition) secondPair = (currentCoordinate.yPosition + allowedPair.Last().yPosition, currentCoordinate.xPosition + allowedPair.Last().xPosition);
            if (firstPair.xPosition < 0 || firstPair.yPosition < 0 || secondPair.xPosition < 0 || secondPair.yPosition < 0 || firstPair.xPosition > MaxX || firstPair.yPosition > MaxY || secondPair.xPosition > MaxX || secondPair.yPosition > MaxY)
            {
                return false;
            }
            else if ((WordSearch[firstPair.yPosition][firstPair.xPosition] == 'M' && WordSearch[secondPair.yPosition][secondPair.xPosition] == 'S') ||
                (WordSearch[secondPair.yPosition][secondPair.xPosition] == 'M' && WordSearch[firstPair.yPosition][firstPair.xPosition] == 'S'))
            {
                return true;
            }
            else
                return false;
        }

        #endregion

        #endregion


    }
}