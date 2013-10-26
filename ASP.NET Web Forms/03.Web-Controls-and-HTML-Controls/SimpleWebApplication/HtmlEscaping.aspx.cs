using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWebApplication
{
    public partial class HtmlEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EscapeContent_Click(object sender, EventArgs e)
        {
            var text = TextContainer.Value;
            var escapedText = Server.HtmlEncode(text);
            ResultLabel.InnerText = text;
            ResultContainer.Value = text;
        }
    }
}