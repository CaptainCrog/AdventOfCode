using CommonTypes.CommonTypes.Classes;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day11 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        BuildingState _initialState;
        Regex _generatorRegex = GeneratorRegex();
        Regex _microchipRegex = MicrochipRegex();

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
        public Day11(string inputPath)
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
            var floorPlan = File.ReadAllLines(_inputPath);
            var items = new List<(string ElementName, bool IsMicrochip, int Floor)>();
            foreach (var floor in floorPlan)
            {
                items.AddRange(ProcessFloor(floor));
            }
            _initialState = new BuildingState(1, items, 0);
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }


        public override T SolveFirstProblem<T>()
        {
            var stepCounter = BreadthFirstSearch();
            return (T)Convert.ChangeType(stepCounter, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            //Each full pair requires 12 steps from floor 1 -> 4
            //2 new pairs of Chips + generators are added meaning we add 2*12 = 24
            //We can solve the original problem and then add 24 to this result
            var result = FirstResult + 24;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        int BreadthFirstSearch()
        {
            var queue = new Queue<BuildingState>();
            var visited = new HashSet<BuildingState>();

            queue.Enqueue(_initialState);
            visited.Add(_initialState);

            while (queue.Count > 0)
            {
                var state = queue.Dequeue();
                if (state.IsGoal()) 
                    return state.Steps;

                foreach (var next in GetNextStates(state))
                {
                    if (!visited.Contains(next))
                    {
                        queue.Enqueue(next);
                        visited.Add(next);
                    }
                }
            }
            return -1; // No solution found
        }

        int GetFloorNumber(string floor)
        {
            if (floor.Contains("first floor"))
                return 1;
            else if (floor.Contains("second floor"))
                return 2;
            else if (floor.Contains("third floor"))
                return 3;
            return 4;
        }

        List<(string ElementName, bool IsMicrochip, int Floor)> ProcessFloor(string floor)
        {
            var items = new List<(string ElementName, bool IsMicrochip, int Floor)>();
            int floorNumber = GetFloorNumber(floor);

            foreach (Match generator in _generatorRegex.Matches(floor))
            {
                var name = generator.Value.Split(' ')[0];
                items.Add((name, false, floorNumber));
            }

            foreach (Match microchip in _microchipRegex.Matches(floor))
            {
                var name = microchip.Value.Split('-')[0];
                items.Add((name, true, floorNumber));
            }

            return items;
        }

        List<BuildingState> GetNextStates(BuildingState state)
        {
            var nextStates = new List<BuildingState>();
            var currentFloorItems = state.Items.Where(i => i.Item3 == state.Elevator).ToList();
            var moves = new List<List<(string, bool, int)>>();

            // Generate possible moves (one or two items)
            for (int i = 0; i < currentFloorItems.Count; i++)
            {
                moves.Add(new List<(string, bool, int)> { currentFloorItems[i] });
                for (int j = i + 1; j < currentFloorItems.Count; j++)
                    moves.Add(new List<(string, bool, int)> { currentFloorItems[i], currentFloorItems[j] });
            }

            foreach (var move in moves)
            {
                foreach (var direction in new[] { -1, 1 }) // Move up or down
                {
                    int newFloor = state.Elevator + direction;
                    if (newFloor < 1 || newFloor > 4)
                        continue; // Out of bounds

                    var newItems = state.Items.Select(i => move.Contains(i) ? (i.Item1, i.Item2, newFloor) : i).ToList();
                    var newState = new BuildingState(newFloor, newItems, state.Steps + 1);

                    if (newState.IsValid())
                        nextStates.Add(newState);
                }
            }
            return nextStates;
        }

        //https://regex101.com/r/FME248/2
        [GeneratedRegex(@"[a-z]*-compatible microchip")]
        private static partial Regex MicrochipRegex();

        //https://regex101.com/r/odUNLr/1
        [GeneratedRegex(@"[a-z]* generator")]
        private static partial Regex GeneratorRegex();

        class BuildingState
        {
            public int Elevator { get; set; }
            public List<(string ElementName, bool IsMicrochip, int Floor)> Items { get; set; }
            public int Steps { get; set; }

            public BuildingState(int elevator, List<(string ElementName, bool IsMicrochip, int Floor)> items, int steps)
            {
                Elevator = elevator;
                Items = items.OrderBy(i => i.ElementName).ThenBy(i => i.IsMicrochip).ThenBy(i => i.Floor).ToList();
                Steps = steps;
            }

            public bool IsValid()
            {
                var grouped = Items.GroupBy(i => i.Item3);
                foreach (var group in grouped)
                {
                    var chips = group.Where(i => i.Item2).Select(i => i.Item1).ToHashSet();
                    var generators = group.Where(i => !i.Item2).Select(i => i.Item1).ToHashSet();

                    // A chip is fried if it's with an unmatched generator
                    if (chips.Any(c => !generators.Contains(c) && generators.Count > 0))
                        return false;
                }
                return true;
            }

            public bool IsGoal() => Items.All(i => i.Floor == 4); // Everything on 4th floor

            public override bool Equals(object obj)
            {
                return obj is BuildingState other &&
                       Elevator == other.Elevator &&
                       Items.SequenceEqual(other.Items);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Elevator, string.Join(",", Items));
            }
        }
        #endregion
    }
}