using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2015.Problems
{
    public class Day04 : IDayBase
    {
        #region Fields

        string _inputPath = string.Empty;
        string[] _wordSearch = new string[0];
        int _firstResult = 0;
        int _secondResult = 0;
        string _secretKey = string.Empty;

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
        public Day04(string inputPath)
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
            _secretKey = File.ReadAllText(InputPath);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(ProcessMD5Hash("00000"), typeof(T));
        }

        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            return (T)Convert.ChangeType(ProcessMD5Hash("000000"), typeof(T));
        }


        int ProcessMD5Hash(string leadingZeroes)
        {
            int iterator = 0;
            while (true)
            {
                var newKey = _secretKey + iterator.ToString();
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(newKey);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    var hexString = Convert.ToHexString(hashBytes);

                    if (hexString.StartsWith(leadingZeroes))
                        break;
                    else
                        iterator++;
                }
            }

            return iterator;
        }
        #endregion


    }
}