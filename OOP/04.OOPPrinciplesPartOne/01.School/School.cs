using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School
{
    public class School
    {
        public List<SchoolClass> ListOfClasses { get; set; }

        public School(List<SchoolClass> classesList)
        {
            this.ListOfClasses = new List<SchoolClass>(classesList);
        }
        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            myBuilder.AppendLine("-----School info-----");
            foreach (var schoolClass in this.ListOfClasses)
            {
                myBuilder.Append(schoolClass);
            }
            return myBuilder.ToString();
        }
    }
}
