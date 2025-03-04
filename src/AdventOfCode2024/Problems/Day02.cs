using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2024.Problems
{
    public class Day02 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        List<string> _reports = new List<string>();
        List<int> _reportValues = new List<int>();
        int _firstResult = 0;
        int _secondResult = 0;
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

        List<string> Reports
        {
            get => _reports;
            set
            {
                if (_reports != value)
                {
                    _reports = value;
                }
            }
        }

        List<int> ReportValues
        {
            get => _reportValues;
            set
            {
                if (_reportValues != value)
                {
                    _reportValues = value;
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
        public Day02(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            Reports = File.ReadLines(_inputPath).ToList();
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            int sumOfValidReports = 0;
            foreach (var report in Reports)
            {
                ReportValues = report.Split(" ").Select(int.Parse).ToList();
                bool isAscending = ReportValues.First() < ReportValues.Last();

                var isValid = ProcessReport(ReportValues.ToArray(), isAscending);
                if (isValid)
                    sumOfValidReports++;

            }

            return (T)Convert.ChangeType(sumOfValidReports, typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            int sumOfValidReports = 0;
            foreach (var report in Reports)
            {
                ReportValues = report.Split(" ").Select(int.Parse).ToList();
                bool isAscending = ReportValues.First() < ReportValues.Last();

                var isValid = ProcessReport(ReportValues.ToArray(), isAscending);
                if (!isValid)
                    isValid = CanReportBeDampened(isAscending);

                if (isValid)
                    sumOfValidReports++;

            }
            return (T)Convert.ChangeType(sumOfValidReports, typeof(T));
        }

        public bool CanReportBeDampened(bool isAscending)
        {
            var reportValuesCopy = ReportValues.ToArray();
            var dampenedReport = new List<int>();

            for (int i = 0; i <= reportValuesCopy.Count() - 1; i++)
            {
                dampenedReport = reportValuesCopy.Select((value, index) => new { value, index })
                                                    .Where(x => x.index != i)
                                                    .Select(xx => xx.value)
                                                    .ToList();
                if (ProcessReport(dampenedReport.ToArray(), isAscending))
                    return true;

            }
            return false;
        }

        private bool ProcessReport(int[] reportValues, bool isAscending)
        {
            for (int i = 0; i <= reportValues.Count() - 1; i++)
            {
                var currentValue = reportValues[i];
                if (i != reportValues.Count() - 1)
                {
                    var nextValue = reportValues[i + 1];
                    if (currentValue == nextValue)
                        return false;

                    else if (isAscending)
                    {
                        if (nextValue - currentValue > 3)
                            return false;
                        else if (nextValue - currentValue < 0)
                            return false;
                    }
                    else if (!isAscending)
                    {
                        if (currentValue - nextValue > 3)
                            return false;
                        else if (currentValue - nextValue < 0)
                            return false;
                    }
                }
            }
            return true;
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }
        #endregion
    }
}
