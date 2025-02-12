using CommonTypes.CommonTypes.Interfaces;

namespace AdventOfCode2016.Problems
{
    public partial class Day05 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        string _firstResult = string.Empty;
        string _secondResult = string.Empty;
        string _doorId = string.Empty;
        int _md5Iterator = 0;

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
        public string FirstResult
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
        public string SecondResult
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
        public Day05(string inputPath)
        {
            _inputPath = inputPath;
            InitialiseProblem();
            FirstResult = SolveFirstProblem<string>();
            SecondResult = SolveSecondProblem<string>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public  void InitialiseProblem()
        {
            _doorId = File.ReadAllText(_inputPath);
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = string.Empty;
            var iterator = 0; 
            _md5Iterator = 0;

            while (iterator < 8 ) 
            {
                var passwordChar = ProcessMD5Hash("00000");
                result += passwordChar[5];
                iterator++;
            }

            return (T)Convert.ChangeType(result.ToLower(), typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            Dictionary<int, char> password = new();
            var iterator = 0; 
            _md5Iterator = 0;

            while (iterator < 8)
            {
                var passwordChar = ProcessMD5Hash("00000");
                var isValid = int.TryParse(passwordChar[5].ToString(), out int position);
                if (isValid && position < 8 && password.TryAdd(int.Parse(passwordChar[5].ToString()), passwordChar[6]))
                { 
                    iterator++;
                }
            }

            var orderedPasswordChars = password.OrderBy(x => x.Key).Select(x => x.Value).ToList();
            var result = string.Join(string.Empty, orderedPasswordChars);

            return (T)Convert.ChangeType(result.ToLower(), typeof(T));
        }


        string ProcessMD5Hash(string leadingZeroes)
        {
            var hexString = string.Empty;
            while (true)
            {
                var newKey = _doorId + _md5Iterator.ToString();
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(newKey);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    hexString = Convert.ToHexString(hashBytes);

                    _md5Iterator++;
                    if (hexString.StartsWith(leadingZeroes))
                        break;
                }
            }

            return hexString;
        }

        #endregion
    }
}
