using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2024.Problems
{
    public class Day01 : IDayBase
    {
        string _inputPath = string.Empty;
        int _firstResult;
        int _secondResult;
        int[] _firstList = Array.Empty<int>();
        int[] _secondList = Array.Empty<int>();

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

        public int[] FirstList
        {

            get => _firstList;
            set
            {
                if (_firstList != value)
                {
                    _firstList = value;
                }
            }
        }
        public int[] SecondList
        {

            get => _secondList;
            set
            {
                if (_secondList != value)
                {
                    _secondList = value;
                }
            }
        }
        public  void InitialiseProblem()
        {
            var lines = File.ReadLines(_inputPath).ToList();
            FirstList = new int[lines.Count()];
            SecondList = new int[lines.Count()];
            foreach (var line in lines)
            {
                var index = lines.IndexOf(line);
                var lineNumbers = line.Split(' ').ToList();
                FirstList[index] = int.Parse(lineNumbers.First());
                SecondList[index] = int.Parse(lineNumbers.Last());
            }
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var orderedFirstList = FirstList.OrderBy(x => x);
            var orderedSecondList = SecondList.OrderBy(x => x);

            var finalList = orderedFirstList.Zip(orderedSecondList, (fl, sl) => Math.Abs(fl - sl)).ToList();

            return (T)Convert.ChangeType(finalList.Sum(), typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var finalList = new List<int>();
            foreach (var number in FirstList)
            {
                var numberInstances = SecondList.Where(sln => sln == number).Count();
                var similarityScore = number * numberInstances;
                finalList.Add(similarityScore);
            }
            return (T)Convert.ChangeType(finalList.Sum(), typeof(T));
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public Day01(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }

    }
}
