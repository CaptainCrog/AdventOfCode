namespace CommonTypes.CommonTypes.HelperFunctions
{
    public static class ArrayHelperFunctions
    {
        public static T[] ShiftBackwards<T>(T[] array, int k)
        {
            for (int times = 0; times < k; times++)
            {
                T temp = array[array.Length - 1];
                for (int i = array.Length - 1; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }
                array[0] = temp;
            }

            return array;
        }

        public static T[] ShiftForwards<T>(T[] array, int k)
        {
            int length = array.Length;
            k %= length; // Handle cases where k is larger than array length

            for (int times = 0; times < k; times++)
            {
                T temp = array[0];
                for (int i = 0; i < length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[length - 1] = temp;
            }

            return array;
        }

        public static T[] GetColumn<T>(T[,] array, int column)
        {
            return Enumerable.Range(0, array.GetLength(0))
                             .Select(row => array[row, column])
                             .ToArray();
        }

        public static T[] GetRow<T>(T[,] array, int row)
        {
            return Enumerable.Range(0, array.GetLength(1))
                             .Select(column => array[row, column])
                             .ToArray();
        }

        public static T[] SwapPositions<T>(T[] array, int firstPosition, int secondPosition)
        {
            var store = array[firstPosition];
            array[firstPosition] = array[secondPosition];
            array[secondPosition] = store;
            return array;
        }

        public static T[] SwapValues<T>(T[] array, T firstValue, T secondValue)
            => SwapPositions(array, Array.IndexOf(array, firstValue), Array.IndexOf(array, secondValue));

        public static IEnumerable<T[]> GetAllCombinations<T>(T[] source)
        {
            for (var i = 0; i < (1 << source.Count()); i++)
                yield return source
                   .Where((t, j) => (i & (1 << j)) != 0)
                   .ToArray();
        }

        public static IEnumerable<int[]> GetAllTargetCombinations(int[] numbers, int target)
        {
            List<int[]> result = new List<int[]>();
            FindCombinations(numbers, target, 0, new List<int>(), result);
            return result.ToArray();
        }

        static void FindCombinations(int[] numbers, int target, int startIndex, List<int> currentCombination, List<int[]> result)
        {
            if (target == 0)
            {
                result.Add(currentCombination.ToArray());
                return;
            }

            for (int i = startIndex; i < numbers.Count(); i++)
            {
                if (numbers[i] > target)
                {
                    break;
                }

                if (i > startIndex && numbers[i] == numbers[i - 1])
                {
                    continue;
                }

                currentCombination.Add(numbers[i]);
                FindCombinations(numbers, target - numbers[i], i + 1, currentCombination, result);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }


        public static IEnumerable<IEnumerable<T>> GetAllPermutations<T>(T[] source)
        {
            if (source == null || !source.Any())
            {
                yield return Enumerable.Empty<T>();
            }

            var array = source.ToArray();
            var startingElementIndex = 0;

            foreach (var startingElement in array)
            {
                var index = startingElementIndex;
                var remainingItems = array.Where((e, i) => i != index).ToArray();

                foreach (var permutationOfRemainder in GetAllPermutations<T>(remainingItems))
                {
                    yield return permutationOfRemainder.Prepend(startingElement);
                }

                startingElementIndex++;
            }
        }

        public static ulong GetProduct(int[] source)
        {
            ulong result = 1;

            foreach (var number in source)
            {
                result *= (ulong)number;
            }

            return result;
        }


        public static int[] GetAsciiValues(string[] source)
        {
            return source.SelectMany(x => x.ToCharArray()).Select(x => (int)x).ToArray();
        }

        public static bool In2DArrayBounds<T>(T[,] array, int x, int y)
        {
            if (x < array.GetLowerBound(0) || x > array.GetUpperBound(0) ||
                y < array.GetLowerBound(1) || y > array.GetUpperBound(1))
                return false;
            return true;
        }
    }
}
