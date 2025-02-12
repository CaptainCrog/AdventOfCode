using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2015.Problems
{
    public class Day09 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        List<SantasRoutes> _routes = new();
        List<string> _locationsVisited = new();
        Dictionary<string, int> _combinationsVisited = new();
        List<(List<string>, int)> _allLocationsVisitedCombinations = new();
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
        public Day09(string inputPath)
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

            foreach (var line in input)
            {
                var parts = line.Split(" = ");
                var locations = parts[0].Split(" to ");
                _routes.Add(new SantasRoutes() { Distance = int.Parse(parts[1].Trim()), Location1 = locations[0], Location2 = locations[1] });
            }

            var allStartingLocations = _routes.Select(x => x.Location1).ToList().Concat(_routes.Select(x => x.Location2).ToList()).Distinct().ToList();
            foreach (var startingLocation in allStartingLocations)
            {
                var allOtherLocations = _routes.Select(x => x.Location1).ToList().Concat(_routes.Select(x => x.Location2).ToList()).Distinct().Where(x => x != startingLocation).ToArray();
                var allOtherLocationPermutations = ArrayHelperFunctions.GetAllPermutations<string>(allOtherLocations.ToArray());
                foreach (var combination in allOtherLocationPermutations)
                {
                    var currentLocation = startingLocation;
                    int routeDistance = 0;
                    _locationsVisited = [currentLocation];

                    foreach (var otherLocation in combination)
                    {
                        routeDistance += _routes.Where(x => (x.Location1 == currentLocation || x.Location2 == currentLocation) &&
                                                            (x.Location1 == otherLocation || x.Location2 == otherLocation))
                                                .Select(x => x.Distance).Single();

                        currentLocation = otherLocation;
                        _locationsVisited.Add(currentLocation);
                    }

                    var routeKey = string.Join(" -> ", _locationsVisited);
                    if (!_combinationsVisited.TryGetValue(routeKey, out int totalTraversedDistance))
                    {
                        _combinationsVisited[routeKey] = routeDistance;
                    }
                }
            }
        }

        public T SolveFirstProblem<T>() where T : IConvertible
        {
            var shortestRoute = _combinationsVisited.OrderBy(x => x.Value).ToDictionary().First().Value;
            return (T)Convert.ChangeType(shortestRoute, typeof(T));
        }
        public T SolveSecondProblem<T>() where T : IConvertible
        {
            var longestRoute = _combinationsVisited.OrderByDescending(x => x.Value).ToDictionary().First().Value;
            return (T)Convert.ChangeType(longestRoute, typeof(T));
        }

        public void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }


        #endregion
    }


    internal record SantasRoutes
    {
        public required string Location1 { get; init; }
        public required string Location2 { get; init; }
        public required int Distance { get; init; }
    }
}
