using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes.CommonTypes.ExtensionMethods
{
    public static class LinqExtensions
    {
        public static Queue<T> ToQueue<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new Queue<T>(source);
        }
    }
}
