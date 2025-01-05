using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes.CommonTypes.HelperFunctions.BinaryHelperFunctions
{
    public static class ConvertToBinaryArray
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
    }
}
