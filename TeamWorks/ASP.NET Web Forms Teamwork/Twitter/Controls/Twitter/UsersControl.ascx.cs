using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Twitter.Controls.Twitter
{
    public partial class Followers : System.Web.UI.UserControl
    {
        private object dataSource;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewFollowers.DataSource = this.dataSource;
            this.ListViewFollowers.DataBind();
        }

        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                if (dataSource != value)
                    dataSource = value;
            }
        }

        protected void SeeFriend_Command(object sender, CommandEventArgs e)
        {
            string username = e.CommandArgument.ToString();
            Response.Redirect("~/UserProfile?username=" + username);
        }
    }
}