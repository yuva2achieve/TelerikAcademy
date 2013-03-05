using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhone.Common
{
    public class GSM
    {
        public Battery phoneBattery = new Battery();
        public Display phoneDisplay = new Display();
        // Fields
        private readonly string model;
        private readonly string manufacturer;
        private string owner;
        private double? price;// Price in leva
        private readonly List<Call> callHistory = new List<Call>();
        private static readonly GSM iPhone4S = new GSM("Iphone 4S", "Apple", "Steve Jobs", 1500d);

        // Constructors
        public GSM(string model, string manufacturer)
            : this(model,manufacturer,null,null,new Battery(),new Display())
        {
        }
        public GSM(string model, string manufacturer, string owner)
            : this(model, manufacturer, owner, null, new Battery(), new Display())
        {
        }
        public GSM(string model, string manufacturer,string owner, double? price)
            : this(model, manufacturer, owner, price, new Battery(), new Display())
        {
        }
        public GSM(string model, string manufacturer, string owner, double? price, Battery battery)
            : this(model, manufacturer, owner, price, battery, new Display())
        {
        }
        public GSM(string model, string manufacturer, string owner, double? price, Battery battery,Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.owner = owner;
            this.price = price;
            this.phoneBattery = battery;
            this.phoneDisplay = display;
        }
        // Properties
        public string Model
        {
            get { return this.model; }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
        }
        public string Owner
        {
            get { return this.owner; }
            set
            {
                this.owner = value;
            }
        }
        public double? Price
        {
            get { return this.price; }
            set
            {
                if (value > 0 || value == null)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException("Input must be positive number");
                }
            }
        }
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
        }
        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder justBuilder = new StringBuilder();
            justBuilder.AppendLine("Phone information:");
            justBuilder.AppendFormat("Phone model: {0}\n", this.model);
            justBuilder.AppendFormat("Phone manufacturer: {0}\n", this.manufacturer);
            if (this.owner != null)
            {
                justBuilder.AppendFormat("Phone owner: {0}\n", this.owner);
            }
            if (this.price != null)
            {
                justBuilder.AppendFormat("Phone price: {0}lv\n", this.price);
            }
            justBuilder.Append(this.phoneBattery.ToString());
            justBuilder.Append(this.phoneDisplay.ToString());
            return justBuilder.ToString();
        }
        // Methods
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }
        public void RemoveCall(int callPosition)
        {
            this.callHistory.RemoveAt(callPosition);
        }
        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }
        public decimal CalculateCallsPrice(decimal pricePerMinute)
        {
            decimal totalCallsDuration = 0;// Total duration of the calls in seconds
            decimal totalPrice = 0;
            foreach (var call in this.callHistory)
            {
                totalCallsDuration += call.Duration;
            }
            totalCallsDuration /= 60;// Converting seconds to minutes
            totalPrice = totalCallsDuration * pricePerMinute;// Total price in leva
            return totalPrice;
        }
    }
}
