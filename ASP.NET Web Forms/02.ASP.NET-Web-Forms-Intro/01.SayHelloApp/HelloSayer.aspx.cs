using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.SayHelloApp
{
    public partial class HelloSayer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sayHelloBtn_Click(object sender, EventArgs e)
        {
            var name = inputName.Text;
            Response.Write("Hello " + name + "<br/>");
        }
    }
}