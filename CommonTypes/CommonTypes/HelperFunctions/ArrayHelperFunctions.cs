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
    }
}
