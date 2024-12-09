using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Problems
{
    public class Day9 : DayBase
    {



        #region Fields
        string _inputPath = @"C:\Users\craigp\Desktop\AdventOfCode2024PuzzleInputDay9.txt";
        int _firstResult = 0;
        int _secondResult = 0;
        int _sum = 0;
        string _diskMap = string.Empty;
        List<string> _diskMapDecoded = new List<string>();
        char[] _antennaFrequencies;
        List<(int row, int col)> _antinodes = new List<(int, int)>();
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

        int FirstResult
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
        int SecondResult
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

        int Sum
        {
            get => _sum;
            set
            {
                if (_sum != value)
                {
                    _sum = value;
                }
            }
        }
        string DiskMap
        {
            get => _diskMap;
            set
            {
                if (_diskMap != value)
                {
                    _diskMap = value;
                }
            }
        }
        List<string> DiskMapDecoded
        {
            get => _diskMapDecoded;
            set
            {
                if (_diskMapDecoded != value)
                {
                    _diskMapDecoded = value;
                }
            }
        }

        char[] AntennaFrequencies
        {
            get => _antennaFrequencies;
            set
            {
                if (_antennaFrequencies != value)
                {
                    _antennaFrequencies = value;
                }
            }
        }

        List<(int row, int col)> Antinodes
        {
            get => _antinodes;
            set
            {
                if (_antinodes != value)
                {
                    _antinodes = value;
                }
            }
        }


        #endregion

        #region Constructor
        public Day9()
        {
            InitialiseProblem();
            FirstResult = SolveFirstProblem<int>();
            SecondResult = SolveSecondProblem<int>();
            OutputSolution();
        }
        #endregion

        #region Methods
        public override void InitialiseProblem()
        {
            DiskMap = File.ReadAllText(_inputPath).Replace("\r", string.Empty).Replace("\n", string.Empty);
            bool isFile = true;
            int id = 0;
            foreach(var numberChar in DiskMap)
            {
                int number = int.Parse(numberChar.ToString());
                if (isFile)
                {
                    for (int i = 0; i <= number - 1; i++)
                    {
                        DiskMapDecoded.Add(id.ToString());
                    }
                    id++;
                }
                else
                {
                    for (int i = 0; i <= number - 1; i++)
                    {
                        DiskMapDecoded.Add(".");
                    }
                }
                isFile = !isFile;
            }
        }

        public override T SolveFirstProblem<T>()
        {
            Sum = 0;
            SortDiskMap();
            Sum = CalculateDiskMap();

            return (T)Convert.ChangeType(Sum, typeof(T));
        }
        public override T SolveSecondProblem<T>()
        {
            Sum = 0;
            return (T)Convert.ChangeType(Sum, typeof(T));
        }

        public override void OutputSolution()
        {
            Console.WriteLine($"First Solution is: {FirstResult}");
            Console.WriteLine($"Second Solution is: {SecondResult}");
        }

        private void SortDiskMap()
        {
            int reversedIndex = DiskMapDecoded.Count() - 1;

            for (int i = 0; i <= DiskMapDecoded.Count() - 1; i++)
            {
                if (DiskMapDecoded[i] == ".")
                {
                    for (int j = reversedIndex; j >= i+1; j--)
                    {
                        if (DiskMapDecoded[j] != ".")
                        {
                            var value = DiskMapDecoded[j];
                            DiskMapDecoded[j] = ".";
                            DiskMapDecoded[i] = value;
                            reversedIndex = j;
                            break;
                        }
                        else
                            continue;
                    }
                }
            }
        }

        private int CalculateDiskMap()
        {
            int sum = 0;
            DiskMapDecoded = DiskMapDecoded.Where(x => x != ".").ToList();
            for (int i = 0; i <= DiskMapDecoded.Count()-1; i++)
            {
                sum += (int.Parse(DiskMapDecoded[i]) * i);
            }
            return sum;
            //1945531743 TOO LOW
        }

        #endregion
    }
}
