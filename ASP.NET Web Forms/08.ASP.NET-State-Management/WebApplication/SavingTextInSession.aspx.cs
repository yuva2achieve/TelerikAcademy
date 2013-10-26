using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class SavingTextInSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var messages = Session["Messages"];
            if (messages == null)
            {
                Session["Messages"] = new List<string>();
            }
        }

        public string GetMessages()
        {
            StringBuilder sb = new StringBuilder();
            List<string> messages = (List<string>)Session["Messages"];
            foreach (var message in messages)
            {
                sb.AppendLine(message);
            }

            return sb.ToString();
        }

        protected void SubmitMessageBtn_Click(object sender, EventArgs e)
        {
            var message = MessageText.Text;
            List<string> messages = (List<string>)Session["Messages"];
            messages.Add(message);
        }
    }
}