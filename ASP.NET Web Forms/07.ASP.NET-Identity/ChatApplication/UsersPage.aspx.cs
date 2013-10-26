using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApplication
{
    public partial class UsersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable ListViewMessages_GetData()
        {
            var db = new ApplicationDbContext();
            return db.Messages.Include("Author").AsQueryable();
        }

        protected void makePostBtn_Click(Object sender, EventArgs e)
        {
            var db = new ApplicationDbContext();
            string msgText = usersPostText.Text;
            var author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var message = new Message()
            {
                Text = msgText,
                Author = author
            };

            db.Messages.Add(message);
            db.SaveChanges();
            this.ListViewMessages.DataBind();
            usersPostText.Text = string.Empty;
        }
    }
}