namespace CommonTypes.CommonTypes.HelperFunctions
{
    public static class BinaryHelperFunctions
    {
        public static int[] Convert(int number, int bitCount)
        {
            var binary = new int[bitCount];
            for (int i = 0; i < bitCount; i++)
            {
                binary[i] = number >> i & 1;
            }
            return binary;
        }


        public static int[] PerformBinaryAddition(int[] firstNumber, int[] secondNumber)
        {
            int length = Math.Max(firstNumber.Length, secondNumber.Length);
            int[] result = new int[length + 1]; // One extra bit for overflow
            int carry = 0;

            for (int i = 0; i < length; i++)
            {
                int bitFirstNumber = i < firstNumber.Length ? firstNumber[i] : 0;
                int bitSecondNumber = i < secondNumber.Length ? secondNumber[i] : 0;

                result[i] = bitFirstNumber ^ bitSecondNumber ^ carry; // XOR for the sum
                carry = bitFirstNumber & bitSecondNumber | carry & (bitFirstNumber ^ bitSecondNumber);
            }

            result[length] = carry;
            return result;
        }
    }
}
