using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes.CommonTypes.HelperFunctions.BinaryHelperFunctions
{
    public static class PerformBinaryAddition
    {
        public static int[] RunAddition(int[] firstNumber, int[] secondNumber)
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
