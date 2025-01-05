namespace AdventOfCode2015.Problems
{
    public class Day10 : DayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _trailHeadScore = 0;
        int _topographicRating = 0;
        List<(int row, int col)> _trailHeads = new List<(int row, int col)>();
        Trail _currentTrail = new Trail();
        string[] _map = new string[0];

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
        List<(int row, int col)> TrailHeads
        {
            get => _trailHeads;
            set
            {
                if (_trailHeads != value)
                {
                    _trailHeads = value;
                }
            }
        }
        Trail CurrentTrail
        {
            get => _currentTrail;
            set
            {
                if (_currentTrail != value)
                {
                    _currentTrail = value;
                }
            }
        }

        string[] Map
        {
            get => _map;
            set
            {
                if (_map != value)
                {
                    _map = value;
                }
            }
        }

        int TrailHeadScore
        {
            get => _trailHeadScore;
            set
            {
                if (_trailHeadScore != value)
                {
                    _trailHeadScore = value;
                }
            }
        }
        int TopographicRating
        {
            get => _topographicRating;
            set
            {
                if (_topographicRating != value)
                {
                    _topographicRating = value;
                }
            }
        }

        #endregion

        #region Constructor
        public Day10(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            SolveProblems(); //Made specific function which would do all the bulk work since each part didnt need anything huge changing
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            Map = File.ReadAllLines(InputPath);
            for (var i = 0; i <= Map.Length - 1; i++)
            {
                for (var j = 0; j <= Map[0].Length - 1; j++)
                {
                    if (Map[i][j] == '0')
                    {
                        TrailHeads.Add((i, j));
                    }
                }
            }
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            return (T)Convert.ChangeType(TrailHeadScore, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(TopographicRating, typeof(T));
        }

        private void SolveProblems()
        {
            TrailHeadScore = 0;
            TopographicRating = 0;
            foreach (var trailHead in TrailHeads)
            {
                CurrentTrail = new Trail()
                {
                    CurrentTrailHead = trailHead
                };
                SearchForPeaks(trailHead);
            }

            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
        }

        private void SearchForPeaks((int trailHeadRow, int trailHeadCol) trailHead)
        {
            CheckSurroundingGrid(null, (0, 0), trailHead);
        }

        private bool CheckDirectionIsInMapBounds(int trailHeadRow, int trailHeadCol, int rowDirection, int colDirection)
        {
            return !(trailHeadRow + rowDirection > Map.Length-1 || trailHeadRow + rowDirection < 0 || trailHeadCol + colDirection > Map.Length-1 || trailHeadCol + colDirection < 0);
        }

        private bool IsNextPositionValidPeakAdjustment(int row, int directionRow, int col, int directionCol, int currentPeakLevel)
        {
            int.TryParse(Map[row + directionRow][col + directionCol].ToString(), out var nextValue);
            if (nextValue == currentPeakLevel + 1)
            {
                if (nextValue != 9)
                    return true;
                else
                {
                    if (!CurrentTrail.AllPeaksFound.Contains((row + directionRow, col + directionCol)))
                    {
                        CurrentTrail.AllPeaksFound.Add((row + directionRow,col + directionCol));
                        TrailHeadScore++;
                        TopographicRating++;
                    }
                    else
                    {
                        TopographicRating++;
                    }
                    return false;
                }

            }
            else
                return false;

        }

        private void CheckSurroundingGrid(TrailHeadPath? trailHeadPath, (int rowDirection, int colDirection) direction, (int row, int col) trailHead)
        {
            if (trailHeadPath == null)
            {
                direction = (-1, 0);
                trailHeadPath = new TrailHeadPath()
                {
                    Direction = direction,
                };
            }

            var forkedTrailHeadPaths = new List<TrailHeadPath>()
            {
            };

            int row = trailHead.row;
            int col = trailHead.col;
            var upIsValid = CheckDirectionIsInMapBounds(row, col, - 1, 0) && IsNextPositionValidPeakAdjustment(row, - 1, col, 0, trailHeadPath.CurrentPeakLevel);
            var downIsValid = CheckDirectionIsInMapBounds(row, col, 1, 0) && IsNextPositionValidPeakAdjustment(row, 1, col, 0, trailHeadPath.CurrentPeakLevel);
            var leftIsValid = CheckDirectionIsInMapBounds(row, col, 0, -1) && IsNextPositionValidPeakAdjustment(row, 0, col, -1, trailHeadPath.CurrentPeakLevel);
            var rightIsValid = CheckDirectionIsInMapBounds(row, col, 0, 1) && IsNextPositionValidPeakAdjustment(row, 0, col,  1, trailHeadPath.CurrentPeakLevel);

            if (upIsValid)
            {
                var newTrailHeadPath = new TrailHeadPath()
                {
                    Direction = (-1, 0),
                    CurrentPeakLevel = trailHeadPath.CurrentPeakLevel+1,
                };
                forkedTrailHeadPaths.Add(newTrailHeadPath);
            }
            if (downIsValid)
            {
                var newTrailHeadPath = new TrailHeadPath()
                {
                    Direction = (1, 0),
                    CurrentPeakLevel = trailHeadPath.CurrentPeakLevel + 1,
                };
                forkedTrailHeadPaths.Add(newTrailHeadPath);

            }
            if (leftIsValid)
            {
                var newTrailHeadPath = new TrailHeadPath()
                {
                    Direction = (0, -1),
                    CurrentPeakLevel = trailHeadPath.CurrentPeakLevel + 1,
                };
                forkedTrailHeadPaths.Add(newTrailHeadPath);

            }
            if (rightIsValid)
            {
                var newTrailHeadPath = new TrailHeadPath()
                {
                    Direction = (0, 1),
                    CurrentPeakLevel = trailHeadPath.CurrentPeakLevel + 1,
                };
                forkedTrailHeadPaths.Add(newTrailHeadPath);
            }

            foreach (var path in forkedTrailHeadPaths)
            {
                CheckSurroundingGrid(path, path.Direction, (row + path.Direction.row, col + path.Direction.col));
            }

        }
        #endregion
    }


    public class TrailHeadPath
    {
        (int rowDirection, int colDirection) _direction;
        int _currentPeakLevel;



        public (int row, int col) Direction
        {
            get => _direction;
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                }
            }
        }

        public int CurrentPeakLevel
        {
            get => _currentPeakLevel;
            set
            {
                if (_currentPeakLevel != value)
                {
                    _currentPeakLevel = value;
                }
            }
        }

        public TrailHeadPath()
        {
            CurrentPeakLevel = 0;
        }
    }

    public class Trail
    {

        List<(int row, int col)> _allPeaksFound = new List<(int row, int col)>();

        (int row, int col) _currentTrailHead = (0, 0);

        public List<(int row, int col)> AllPeaksFound
        {
            get => _allPeaksFound;
            set
            {
                if (_allPeaksFound != value)
                {
                    _allPeaksFound = value;
                }
            }
        }

        public (int row, int col) CurrentTrailHead
        {
            get => _currentTrailHead;
            set
            {
                if (_currentTrailHead != value)
                {
                    _currentTrailHead = value;
                }
            }
        }


        public Trail() 
        { 
        }
    }
}
