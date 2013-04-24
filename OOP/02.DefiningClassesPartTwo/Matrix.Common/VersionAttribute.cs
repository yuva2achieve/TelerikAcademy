using System;
using System.Linq;

namespace Matrix.Common
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class VersionAttribute: System.Attribute
    {
        private readonly double version;

        public VersionAttribute(double version)
        {
            this.version = version;
        }

        public override string ToString()
        {
            return "Version: " + this.version.ToString();
        }
    }
}
