using CommonTypes.CommonTypes.Classes;
using CommonTypes.CommonTypes.Constants;
using CommonTypes.CommonTypes.HelperFunctions;
using CommonTypes.CommonTypes.Regex;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day11 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Building _building = new();
        List<Isotope> _isotopes = new();
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
        public Result<int> FirstResult
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
        public Result<int> SecondResult
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
            foreach (var floor in floorPlan)
            {
                ProcessFloor(floor);
            }
            _building = new Building() { ElevatorCurrentFloor = 1, TotalNumberOfFloors = floorPlan.Count() };
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult.ResultValue}");
            Console.WriteLine($"Second Solution is: {SecondResult.ResultValue}");
        }

        // RULES:
        // Can only carry up to 2 Generators/Microchips at a time

        //Only valid moves:
        //Moving Microchip upwards to a generator or vice versa
        //Moving Microchip with its generator up to next floor
        //Moving Microchip with another microchip up to next floor
        //Moving Generator with another Generator up to next floor

        //Invalid states:
        //Microchip has no equivalent generator on the same level and another generator for a different element exists.


        public override T SolveFirstProblem<T>()
        {
            var stepCounter = 0;
            var temp = BreadthFirstSearch();
            return (T)Convert.ChangeType(stepCounter, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            return (T)Convert.ChangeType(0, typeof(T));
        }

        int BreadthFirstSearch()
        {
            var queue = new PriorityQueue<(int currentFloor, int stepCount, List<Isotope> isotopes), int>();
            queue.Enqueue((1, 0, _isotopes.ToList()), 1);

            var visitedSequences = new HashSet<(int, int, Isotope[])>();

            while (queue.Count > 0)
            {
                var (currentFloor, stepCount, isotopes) = queue.Dequeue();
                var availableIsotopes = isotopes.Where(x => x.CurrentFloor == currentFloor).ToArray();
                var generatorNames = availableIsotopes.Where(x => x.IsotopeType == IsotopeType.Generator).Select(x => x.Name);

                //Invalid state
                if (availableIsotopes.Any(x => x.IsotopeType == IsotopeType.Microchip && generatorNames.Any() && !generatorNames.Contains(x.Name)))
                    continue;

                if (currentFloor == _building.TotalNumberOfFloors && availableIsotopes.Count() == _isotopes.Count)
                    return stepCount;
                else
                {
                    if (!visitedSequences.Add((currentFloor, stepCount, isotopes.ToArray()))) //If we somehow get into the same state as a previous search
                        continue;

                    var isotopeCombinations = ArrayHelperFunctions.GetAllCombinations(availableIsotopes).Where(x => x.Length <= 2 && x.Length > 0);
                    foreach(var isotopeCombination in isotopeCombinations)
                    {
                        var currentFloorCopy = currentFloor;
                        var stepCountCopy = stepCount + 1;
                        if (currentFloorCopy != 1)
                        {
                            var isotopesCopy = isotopes.ConvertAll(x => new Isotope(x.Name, x.CurrentFloor, x.IsotopeType));
                            foreach (var isotope in isotopeCombination)
                            {
                                isotopesCopy.Where(x => x.Name == isotope.Name && x.IsotopeType == isotope.IsotopeType).Single().CurrentFloor--;
                            }
                            queue.Enqueue((--currentFloorCopy, stepCountCopy, isotopesCopy), -stepCountCopy);
                        }
                        if (currentFloorCopy != _building.TotalNumberOfFloors)
                        {
                            var isotopesCopy = isotopes.ConvertAll(x => new Isotope(x.Name, x.CurrentFloor, x.IsotopeType));
                            foreach (var isotope in isotopeCombination)
                            {
                                isotopesCopy.Where(x => x.Name == isotope.Name && x.IsotopeType == isotope.IsotopeType).Single().CurrentFloor++;
                            }
                            queue.Enqueue((++currentFloorCopy, stepCountCopy, isotopesCopy), -stepCountCopy);
                        }
                    }
                }

            }

            return 0;
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

        void ProcessFloor(string floor)
        {
            int floorNumber = GetFloorNumber(floor);

            foreach (Match generator in _generatorRegex.Matches(floor))
            {
                var name = generator.Value.Split(' ')[0];
                _isotopes.Add(new Isotope(name, floorNumber, IsotopeType.Generator));
            }

            foreach (Match microchip in _microchipRegex.Matches(floor))
            {
                var name = microchip.Value.Split('-')[0];
                _isotopes.Add(new Isotope(name, floorNumber, IsotopeType.Microchip));
            }
        }


        //https://regex101.com/r/FME248/2
        [GeneratedRegex(@"[a-z]*-compatible microchip")]
        private static partial Regex MicrochipRegex();

        //https://regex101.com/r/odUNLr/1
        [GeneratedRegex(@"[a-z]* generator")]
        private static partial Regex GeneratorRegex();

        class Isotope
        {
            public string Name { get; init; }
            public int CurrentFloor { get; set; }
            public IsotopeType IsotopeType { get; init; }
            public Isotope(string name, int currentFloor, IsotopeType isotopeType)
            {
                Name = name;
                CurrentFloor = currentFloor;
                IsotopeType = isotopeType;
            }
        }

        enum IsotopeType
        {
            Generator = 0,
            Microchip = 1,
        }

        class Building
        {
            public int ElevatorCurrentFloor { get; set; }
            public int TotalNumberOfFloors { get; init; }
            public Building()
            {

            }

        }
        #endregion
    }
}