using System;
using System.Linq;

namespace _03.DefineException
{
    public class InvalidRangeException<T> : ApplicationException
    {
        // Constructors
        public InvalidRangeException()
            : base()
        {
        }

        public InvalidRangeException(string msg)
            : base(msg)
        {
        }

        public InvalidRangeException(string msg, T min, T max)
            : base(msg)
        {
            this.Min = min;
            this.Max = max;
        }

        // Properties
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
