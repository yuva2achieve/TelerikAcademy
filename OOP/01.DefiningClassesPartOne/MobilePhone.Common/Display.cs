using System;
using System.Linq;
using System.Text;

namespace MobilePhone.Common
{
    public class Display
    {
        // Fields
        private double? size;// Display size in inches
        private ulong? numberOfColors;
        // Constructors
        public Display():this(null,null)
        {
        }
        public Display(double? size):this(size,null)
        {
        }
        public Display(double? size, ulong? numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }
        // Properties
        public double? Size
        {
            get { return this.size; }
            set
            {
                if (value == null || value > 0)
                {
                    this.size = value;
                }
                else
                {
                    throw new ArgumentException("Input must be positive number");
                }
            }
        }
        public ulong? NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value == null || value > 0)
                {
                    this.numberOfColors = value;
                }
                else
                {
                    throw new ArgumentException("Input must be positive number");
                }
            }
        }
        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder justBuilder = new StringBuilder();
            if (this.size != null)
            {
                justBuilder.AppendFormat("Display size: {0} inches\n", this.size);
            }
            if (this.numberOfColors != null)
            {
                justBuilder.AppendFormat("Display colors : {0}\n", this.numberOfColors);
            }
            return justBuilder.ToString();
        }
    }
}
