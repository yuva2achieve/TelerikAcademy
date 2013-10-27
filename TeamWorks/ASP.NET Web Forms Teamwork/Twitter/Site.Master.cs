﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twitter.Models;
using System.Linq;

namespace Twitter
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }
        protected void NavigationMenu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            if (ShouldRemoveItem(e.Item.Text))
            {
                e.Item.Parent.ChildItems.Remove(e.Item);
            }
        }

        private bool ShouldRemoveItem(string menuText)
        {
            string username = Page.User.Identity.Name;
            TwitterEntities context = new TwitterEntities();
            var currentUser = context.AspNetUsers.FirstOrDefault(x => x.UserName == username);
            if (menuText == "Logout" && currentUser == null)
            {
                return true;
            }
            if (menuText == "Login" && currentUser != null)
            {
                return true;
            }
            if (menuText == "Register" && currentUser != null)
            {
                return true;
            }
            if (menuText == "My Messages" && currentUser == null)
            {
                return true;
            }
            if (menuText == "Users" && currentUser == null)
            {
                return true;
            }
            if (menuText == "Admin")
            {
                if (currentUser == null)
                {
                    return true;
                }

                var adminRole = context.AspNetRoles.FirstOrDefault(x => x.Name == "Admin");
                {
                    if (!currentUser.AspNetRoles.Contains(adminRole))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }

}