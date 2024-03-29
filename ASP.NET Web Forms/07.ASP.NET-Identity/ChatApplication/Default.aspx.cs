﻿using ChatApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Moderator"))
                {
                    Response.Redirect("ModeratorPage.aspx");
                }
                else if (User.IsInRole("Administrator"))
                {
                    Response.Redirect("AdminsPage.aspx");
                }
                else
                {
                    Response.Redirect("UsersPage.aspx");
                }

            }         
        }
    }
}