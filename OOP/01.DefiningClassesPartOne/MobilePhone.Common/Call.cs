using System;
using System.Linq;
using System.Text;

namespace MobilePhone.Common
{
    public class Call
    {
        // Fields
        private DateTime dateAndTime;
        private string dialedNumber;
        private int duration;// Call duration in seconds
        // Constructors
        public Call(DateTime dateAndTime, string dialedNumber, int duration)
        {
            this.dateAndTime = dateAndTime;
            this.dialedNumber = dialedNumber;
            this.duration = duration;
        }
        // Properties
        public DateTime DateAndTime
        {
            get { return this.dateAndTime; }
            set
            {
                if (value != null)
                {
                    this.dateAndTime = value;
                }
                else
                {
                    throw new ArgumentException("Invalid date and time");
                }
            }
        }
        public string DialedNumber
        {
            get { return this.dialedNumber; }
            set
            {
                if (value != null)
                {
                    this.dialedNumber = value;
                }
                else
                {
                    throw new ArgumentException("You must enter number");
                }
            }
        }
        public int Duration
        {
            get { return this.duration; }
            set
            {
                if (value > 0)
                {
                    this.duration = value;
                }
                else
                {
                    throw new ArgumentException("Duration must be bigger than 0");
                }
            }
        }
        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder justBuilder = new StringBuilder();
            justBuilder.AppendLine("Call info: ");
            justBuilder.AppendFormat("Date and time: {0}\n", this.dateAndTime);
            justBuilder.AppendFormat("Dialed number: {0}\n", this.dialedNumber);
            justBuilder.AppendFormat("Call duration: {0} seconds\n", this.duration);
            return justBuilder.ToString();
        }
    }
}
