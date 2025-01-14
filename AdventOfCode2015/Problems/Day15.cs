using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2015.Problems
{
    public class Day15 : DayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        HashSet<long> _ingredientScore = new();
        HashSet<(long score, long calories)> _calorieScore = new();
        List<Ingredient> _ingredientTypes = new();
        List<(int i1, int i2, int i3, int i4)> _combinations = new();

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
        public Day15(string inputPath)
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
            var input = File.ReadAllLines(InputPath);
            var numberRegex = CommonRegexHelpers.NumberRegex();
            foreach (var line in input) 
            {
                var matches = numberRegex.Matches(line);
                _ingredientTypes.Add(new Ingredient()
                {
                    Capacity = int.Parse(matches[0].Value),
                    Durability = int.Parse(matches[1].Value),
                    Flavor = int.Parse(matches[2].Value),
                    Texture = int.Parse(matches[3].Value),
                    Calories = int.Parse(matches[4].Value)
                });
            }

            _combinations = new List<(int i1, int i2, int i3, int i4)>();

            for (int i = 0; i < Enumerable.Range(0, 101).ToArray().Length; i++)
            {
                for (int j = 0; j < Enumerable.Range(0, 101).ToArray().Length; j++)
                {
                    for (int k = 0; k < Enumerable.Range(0, 101).ToArray().Length; k++)
                    {
                        for (int l = 0; l < Enumerable.Range(0, 101).ToArray().Length; l++)
                        {
                            if (i + j + k + l == 100)
                            {
                                _combinations.Add((i, j, k, l));
                            }
                        }
                    }
                }
            }


            foreach (var combination in _combinations)
            {
                var capacity = CalculateIngredientProperty(IngredientProperty.Capacity, combination);
                var durability = CalculateIngredientProperty(IngredientProperty.Durability, combination);
                var flavor = CalculateIngredientProperty(IngredientProperty.Flavor, combination);
                var texture = CalculateIngredientProperty(IngredientProperty.Texture, combination);
                var calories = CalculateIngredientProperty(IngredientProperty.Calories, combination);

                long total = capacity * durability * flavor * texture;
                _ingredientScore.Add(total);
                if (calories == 500)
                    _calorieScore.Add((total, calories));
            }

        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public override T SolveFirstProblem<T>()
        {
            var result = _ingredientScore.OrderDescending().ToHashSet().First();

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public override T SolveSecondProblem<T>()
        {
            var result = _calorieScore.Where(x => x.calories == 500).OrderByDescending(x => x.score).First().score;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        int CalculateIngredientProperty(IngredientProperty property, (int i1, int i2, int i3, int i4) combination)
        {
            List<int> propertyValues = new();
            if (property == IngredientProperty.Capacity)
                propertyValues = _ingredientTypes.Select(x => x.Capacity).ToList();
            else if (property == IngredientProperty.Durability)
                propertyValues = _ingredientTypes.Select(x => x.Durability).ToList();
            else if (property == IngredientProperty.Flavor)
                propertyValues = _ingredientTypes.Select(x => x.Flavor).ToList();
            else if (property == IngredientProperty.Texture)
                propertyValues = _ingredientTypes.Select(x => x.Texture).ToList();
            else
                propertyValues = _ingredientTypes.Select(x => x.Calories).ToList();

            var total = (propertyValues[0] * combination.i1) + (propertyValues[1] * combination.i2) + (propertyValues[2] * combination.i3) + (propertyValues[3] * combination.i4);
            if (total < 0)
                total = 0;

            return total;
        }

        #endregion

        internal record Ingredient
        {
            public required int Capacity { get; init; }
            public required int Durability { get; init; }
            public required int Flavor { get; init; }
            public required int Texture { get; init; }
            public required int Calories { get; init; }
        }

        internal enum IngredientProperty
        {
            Capacity = 0,
            Durability = 1,
            Flavor = 2,
            Texture = 3,
            Calories = 4,
        }
    }
}
