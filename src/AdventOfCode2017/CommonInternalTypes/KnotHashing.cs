
namespace AdventOfCode2017.CommonInternalTypes
{
    internal static class KnotHashing
    {
        public static LinkedList<int> CreateSparseHash(int[] numberArray, LinkedList<int> numbers)
        {

            int numberIterator = 0;
            int skipSize = 0;
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < numberArray.Length; j++)
                {
                    var currentNumberIterator = numberIterator % numbers.Count;
                    var instruction = numberArray[j];
                    if (instruction > numbers.Count)
                        continue;

                    var numberRange = GetNumberRange(currentNumberIterator, instruction, numbers);
                    var reversedRange = numberRange.Reverse().ToArray();
                    ReplaceNumbers(currentNumberIterator, reversedRange, numbers);
                    numberIterator += instruction + skipSize;
                    skipSize++;
                }
            }

            return numbers;
        }


        static int[] GetNumberRange(int numberIterator, int instruction, LinkedList<int> numbers)
        {
            var currentNumberValue = numbers.Skip(numberIterator).First();
            var currentNumberNode = numbers.Find(currentNumberValue);
            var numberRange = new List<int>();
            for (int i = 0; i < instruction; i++)
            {
                numberRange.Add(currentNumberNode.Value);
                currentNumberNode = currentNumberNode.Next ?? numbers.First;
            }

            return numberRange.ToArray();
        }

        static void ReplaceNumbers(int numberIterator, int[] reversedRange, LinkedList<int> numbers)
        {
            var currentNumberValue = numbers.Skip(numberIterator).First();
            var currentNumberNode = numbers.Find(currentNumberValue);

            for (int i = 0; i < reversedRange.Length; i++)
            {
                currentNumberNode.ValueRef = reversedRange[i];
                currentNumberNode = currentNumberNode.Next ?? numbers.First;
            }
        }

        public static int ReduceSparseHash(int[] sparseHash)
        {
            int denseHash = 0;
            for (int i = 0; i < sparseHash.Length; i++)
            {
                denseHash ^= sparseHash[i];
            }
            return denseHash;
        }
    }
}
