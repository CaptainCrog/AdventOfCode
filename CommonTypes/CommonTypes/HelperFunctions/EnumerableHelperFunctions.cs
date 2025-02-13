using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes.CommonTypes.HelperFunctions
{
    public static class EnumerableHelperFunctions
    {
        public static IEnumerable<uint> UIntRange(uint start, uint count)
        {
            for (uint val = start; val <= start + count; val++)
            {
                yield return val;
            }
        }
    }
}
