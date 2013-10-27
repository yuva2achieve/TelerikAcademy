using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;

namespace Twitter.Account
{
    public partial class UploadPicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadPicture_ServerClick(object sender, EventArgs e)
        {
            var username = User.Identity.Name;
            if ((avatarPicture.PostedFile != null) && (avatarPicture.PostedFile.ContentLength > 0))
            {
                TwitterEntities context = new TwitterEntities();
                var user = context.AspNetUsers.FirstOrDefault(x => x.UserName == username);
                var userId = user.Id;
                string fn = userId + System.IO.Path.GetExtension(avatarPicture.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Data") + "\\" + fn;
    
                try
                {
                    avatarPicture.PostedFile.SaveAs(SaveLocation);
                    Response.Write("The file has been uploaded.");
                    user.ProfilePicture = fn;
                    context.SaveChanges();
                    Response.Write(fn);
                    Response.Redirect("Manage");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}