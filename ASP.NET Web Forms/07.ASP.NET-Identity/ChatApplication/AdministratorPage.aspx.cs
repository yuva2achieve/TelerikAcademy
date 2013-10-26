using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApplication
{
    public partial class AdministratorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("Administrator"))
                {
                    if (User.IsInRole("Moderator"))
                    {
                        Response.Redirect("ModeratorPage.aspx");
                    }
                    else
                    {
                        Response.Redirect("UsersPage.aspx");
                    }
                }

            }  
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

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewMessages_UpdateItem(int id)
        {
            var db = new ApplicationDbContext();
            ChatApplication.Models.Message item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            item = db.Messages.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                db.SaveChanges();

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewMessages_DeleteItem(int id)
        {
            var db = new ApplicationDbContext();
            ChatApplication.Models.Message item = db.Messages.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            db.Messages.Remove(item);
            db.SaveChanges();
        }
    }
}