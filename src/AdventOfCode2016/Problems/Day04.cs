using CommonTypes.CommonTypes.Interfaces;
using CommonTypes.CommonTypes.Regex;
using System.Text.RegularExpressions;

namespace AdventOfCode2016.Problems
{
    public partial class Day04 : IDayBase
    {
        #region Fields
        string _inputPath = string.Empty;
        int _firstResult = 0;
        int _secondResult = 0;
        Room[] _rooms = [];
        List<Room> _validRooms = new();
        string _searchString = string.Empty;

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
        public Day04(string inputPath, string searchString)
        {
            _inputPath = inputPath;
            _searchString = searchString;
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
            _rooms = new Room[input.Length];

            var encryptedNameRegex = EncryptedNameRegex();
            var numberRegex = CommonRegexHelpers.PositiveNumberRegex();
            var checkSumRegex = ChecksumRegex();
            for (int i = 0; i < input.Length; i++)
            {
                var roomInput = input[i];

                var room = new Room() 
                { 
                    EncryptedName = string.Join(string.Empty, encryptedNameRegex.Matches(roomInput).SelectMany(x => x.Value)), 
                    SectorId = int.Parse(numberRegex.Match(roomInput).Value), 
                    Checksum = checkSumRegex.Match(roomInput).Value 
                };

                _rooms[i] = room;
            }
        }

        public  void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        public  T SolveFirstProblem<T>() where T : IConvertible
        {
            var result = 0;

            var letterRegex = CommonRegexHelpers.AnyLowercaseLetters();
            var checkSumRegex = ChecksumRegex();
            foreach (var room in _rooms)
            {
                var roomChars = letterRegex.Matches(room.EncryptedName).Select(x => x.Value.First()).Distinct().ToArray();
                var charCount = new (char character, int count)[roomChars.Length];
                for (int i = 0; i < roomChars.Length; i++)
                {
                    charCount[i] = (roomChars[i], room.EncryptedName.Count(x => x == roomChars[i]));
                }

                var checksum =  string.Join(string.Empty, charCount.OrderByDescending(x => x.count).ThenBy(x => x.character).Take(5).Select(x => x.character).ToArray());

                if (room.Checksum.Contains(checksum))
                    _validRooms.Add(room);
            }

            result = _validRooms.Sum(x => x.SectorId);
            return (T)Convert.ChangeType(result, typeof(T));
        }
        public  T SolveSecondProblem<T>() where T : IConvertible
        {
            var result = 0;

            foreach (var validRoom in _validRooms)
            {
                var shift = validRoom.SectorId % 26;
                var words = validRoom.EncryptedName.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var newString = string.Empty;
                foreach (var word in words)
                {
                    foreach (var character in word)
                    {
                        int iterator = shift;
                        char currentChar = character;
                        while(iterator > 0)
                        {
                            if (currentChar == 'z')
                            {
                                currentChar = 'a';
                                iterator--;
                            }
                            else
                            {
                                currentChar++;
                                iterator--;
                            }
                        }
                        newString += currentChar;
                    }
                    newString += ' ';
                }

                if (newString.Contains(_searchString))
                    result = validRoom.SectorId;


            }
            return (T)Convert.ChangeType(result, typeof(T));
        }

        #endregion

        //https://regex101.com/r/7r57tX/1
        [GeneratedRegex(@"\[\w*\]")]
        private static partial Regex ChecksumRegex();

        //https://regex101.com/r/0A3iIL/1
        [GeneratedRegex(@"[a-z]+-")]
        private static partial Regex EncryptedNameRegex();

        record Room
        {
            public required string EncryptedName { get; init; }
            public required int SectorId { get; init; }
            public required string Checksum { get; init; }
        }
    }
}
