using AutoMorgue.Data;
using AutoMorgue.Models;
using AutoMorgue.Services.Models;
using AutoMorgue.Services.Persisters;
using BlogSystem.Services.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
namespace AutoMorgue.Services.Controllers
{
    public class AdminController : BaseApiController
    {
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserRegisterModel model)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     UserDataPersister.ValidateUsername(model.Username);
                     UserDataPersister.ValidateNickname(model.DisplayName);
                     UserDataPersister.ValidateAuthCode(model.AuthCode);

                     var usernameToLower = model.Username.ToLower();
                     var displayNameToLower = model.DisplayName.ToLower();

                     var users = context.Users;
                     var user = users.FirstOrDefault(usr => usr.Username == usernameToLower || usr.DisplayName.ToLower() == displayNameToLower);

                     var role = context.Roles.FirstOrDefault(r => r.Name == "admin");
                     if (role == null)
                     {
                         role = new Role
                         {
                             Name = "admin"
                         };
                     }

                     if (user != null)
                     {
                         throw new InvalidOperationException("Invalid Username or Password");
                     }

                     var newUser = new User
                     {
                         Username = usernameToLower,
                         DisplayName = model.DisplayName,
                         AuthCode = model.AuthCode,
                         Role = role
                     };

                     var userInDb = context.Users.Add(newUser);
                     context.SaveChanges();

                     userInDb.SessionKey = UserDataPersister.GenerateSessionKey(userInDb.Id);
                     context.SaveChanges();

                     var loggedModel = new UserLoggedModel
                     {
                         DisplayName = userInDb.DisplayName,
                         SessionKey = userInDb.SessionKey
                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                     response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = userInDb.Id }));

                     return response;

                 });

            return responseMsg;
        }

        [HttpDelete]
        [ActionName("deleteUser")]
        public HttpResponseMessage DeleteUser([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey, int userId)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();


                     var users = context.Users;
                     var admin = users.FirstOrDefault(
                           usr => usr.SessionKey == sessionKey);

                     if (admin.Role.Name != "admin")
                     {
                         throw new InvalidOperationException("You don't have permission to delete users.");
                     }

                     var user = context.Users.FirstOrDefault(u=>u.Id == userId);
                   
                     if (user == null)
                     {
                         throw new InvalidOperationException("Invalid Username or Password");
                     }

                     if (user.Role.Name == "admin")
                     {
                         throw new InvalidOperationException("You can't delete admin users.");
                     }

                     context.Users.Remove(user);
                     context.SaveChanges();


                     var response = this.Request.CreateResponse(HttpStatusCode.Created, user.Id);

                     return response;
                 });

            return responseMsg;
        }       
    }
}