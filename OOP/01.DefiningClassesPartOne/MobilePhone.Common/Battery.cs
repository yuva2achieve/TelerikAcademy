using System;
using System.Linq;
using System.Text;

namespace MobilePhone.Common
{
    public enum BatteryType
    {
        LiPoly, LiIon, NiCd, NiMH
    }
    public class Battery
    {
        // Fields
        private readonly string model;
        private double? hoursIdle;
        private double? hoursTalking;
        private BatteryType? batteryType;
        // Constructors
        public Battery()
            : this(null, null, null,null)
        {
        }
        public Battery(string model)
            : this(model,null,null,null)
        {
        }
        public Battery(string model, double? hoursIdle)
            : this(model, hoursIdle, null,null)
        {
        }
        public Battery(string model, double? hoursIdle, double? hoursTalking, BatteryType? batteryType)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalking = hoursTalking;
            this.batteryType = batteryType;
        }
        // Properties
        public string Model
        {
            get { return this.model; }
        }
        public double? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value > 0 || value == null)
                {
                    this.hoursIdle = value;
                }
                else
                {
                    throw new ArgumentException("Input must be positive number");
                }
            }
        }
        public double? HoursTalking
        {
            get { return this.hoursTalking; }
            set
            {
                if (value > 0 || value == null)
                {
                    this.hoursTalking = value;
                }
                else
                {
                    throw new ArgumentException("Input must be positive number");
                }
            }
        }
        public BatteryType? BatteryType
        {
            get { return this.batteryType; }
            set
            {
                this.batteryType = value;
            }
        }
        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder justBuilder = new StringBuilder();
            if (this.model != null)
            {
                justBuilder.AppendFormat("Battery model: {0}\n", this.model);
            }
            if (this.hoursIdle != null)
            {
                justBuilder.AppendFormat("Battery hours idle : {0}\n", this.hoursIdle);
            }
            if (this.hoursTalking != null)
            {
                justBuilder.AppendFormat("Battery hours talking : {0}\n", this.hoursTalking);
            }
            if (this.batteryType != null)
            {
                justBuilder.AppendFormat("Battery type : {0}\n", this.batteryType);
            }
            return justBuilder.ToString();
        }
    }
}
