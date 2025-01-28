using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes.CommonTypes.Classes
{
    public class Result<T> where T : IConvertible
    {
        private T _resultValue;

        public T ResultValue
        {
            get
            {
                return _resultValue;
            }
            set
            {
                _resultValue = value;
            }
        }

        public static implicit operator T(Result<T> value)
        {
            return value.ResultValue;
        }

        public static implicit operator Result<T>(T value)
        {
            return new Result<T> { ResultValue = value };
        }
    }
}
