using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SayHelloAndShowAssemblyLocation
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentAssemblyLocation = Assembly.GetExecutingAssembly().Location;
            Response.Write("Hello from code behind <br/>");
            Response.Write("Current assembly location is: " + currentAssemblyLocation + "<br/>");
        }
    }
}