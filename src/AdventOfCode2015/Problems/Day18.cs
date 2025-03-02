using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2015.Problems
{
    public class Day18 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        int _numberOfSteps = 0;
        bool[,] _lightPositions = new bool[0, 0];

        #endregion

        #region Properties
        protected  string InputPath
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
        public Day18(string inputPath, int numberOfSteps)
        {
            _inputPath = inputPath;
            _numberOfSteps = numberOfSteps;


            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            var input = File.ReadAllLines(_inputPath);
            _lightPositions = new bool[input.Length, input.First().Length];
            for (int i = 0; i < _lightPositions.GetLength(0); i++)
            {
                for (int j = 0; j < _lightPositions.GetLength(1); j++)
                {
                    var isLightOn = input[i][j] == '#';
                    _lightPositions[i, j] = isLightOn;
                }
            }
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            int iterator = 0;
            var lightPositionsCopy = _lightPositions;
            while (iterator < _numberOfSteps)
            {
                var nextState = new bool[lightPositionsCopy.GetLength(0), lightPositionsCopy.GetLength(1)];
                for (int i = 0; i < lightPositionsCopy.GetLength(0); i++)
                {
                    for (int j = 0; j < lightPositionsCopy.GetLength(1); j++)
                    {
                        var lightsNextValue = ProcessLight(i, j, lightPositionsCopy);
                        nextState[i, j] = lightsNextValue;
                    }
                }

                lightPositionsCopy = nextState;
                iterator++;
            }

            var result = 0;
            for (int i = 0; i < lightPositionsCopy.GetLength(0); i++)
            {
                for (int j = 0; j < lightPositionsCopy.GetLength(1); j++)
                {
                    if (lightPositionsCopy[i, j])
                        result++;
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            int iterator = 0;
            var lightPositionsCopy = _lightPositions;
            //Although my input already stipulates the corners are on, this will ensure it is on for any other input
            lightPositionsCopy = SetCorners(lightPositionsCopy);
            while (iterator < _numberOfSteps)
            {
                var nextState = new bool[lightPositionsCopy.GetLength(0), lightPositionsCopy.GetLength(1)];
                for (int i = 0; i < _lightPositions.GetLength(0); i++)
                {
                    for (int j = 0; j < lightPositionsCopy.GetLength(1); j++)
                    {
                        var lightsNextValue = ProcessLight(i, j, lightPositionsCopy);
                        nextState[i, j] = lightsNextValue;
                    }
                }

                lightPositionsCopy = nextState;
                lightPositionsCopy = SetCorners(lightPositionsCopy);
                iterator++;
            }

            var result = 0;
            for (int i = 0; i < lightPositionsCopy.GetLength(0); i++)
            {
                for (int j = 0; j < lightPositionsCopy.GetLength(1); j++)
                {
                    if (lightPositionsCopy[i, j])
                        result++;
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        bool ProcessLight(int row, int col, bool[,] currentLightGrid)
        {
            var positionsToCheck = new List<(int row, int col)>()
            {
                (row - 1, col -1), (row - 1, col), (row - 1, col + 1),
                (row, col -1),                     (row, col + 1),
                (row + 1, col -1), (row + 1, col), (row + 1, col + 1),
            };

            positionsToCheck = positionsToCheck.Where(x => x.row != -1 && x.row != _lightPositions.GetLength(0)).ToList(); // filter out positions where the row goes out of bounds
            positionsToCheck = positionsToCheck.Where(x => x.col != -1 && x.col != _lightPositions.GetLength(1)).ToList(); // filter out positions where the col goes out of bounds

            var numberOfNeighboursOn = 0;
            foreach (var position in positionsToCheck)
            {
                if (currentLightGrid[position.row, position.col])
                    numberOfNeighboursOn++;
            }
            if (currentLightGrid[row, col] && numberOfNeighboursOn <= 3 && numberOfNeighboursOn >= 2)
            {
                return true;
            }
            else if (!currentLightGrid[row, col] && numberOfNeighboursOn == 3)
            {
                return true;
            }
            else
                return false;
        }

        bool[,] SetCorners(bool[,] currentLightGrid)
        {
            currentLightGrid[0, 0] = true;
            currentLightGrid[0, currentLightGrid.GetLength(1) - 1] = true;
            currentLightGrid[currentLightGrid.GetLength(0) - 1, 0] = true;
            currentLightGrid[currentLightGrid.GetLength(0) - 1, currentLightGrid.GetLength(1) - 1] = true;

            return currentLightGrid;
        }
        #endregion
    }
}
