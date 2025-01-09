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
    }
}
