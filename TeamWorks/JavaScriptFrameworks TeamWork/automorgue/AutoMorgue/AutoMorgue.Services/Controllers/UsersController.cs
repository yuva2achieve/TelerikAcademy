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
    public class UsersController : BaseApiController
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

                     var role = context.Roles.FirstOrDefault(r => r.Name == "user");
                     if (role == null)
                     {
                         role = new Role
                         {
                             Name = "user"
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

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserLoginModel model)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     UserDataPersister.ValidateUsername(model.Username);
                     UserDataPersister.ValidateAuthCode(model.AuthCode);

                     var usernameToLower = model.Username.ToLower();

                     var users = context.Users;
                     var user = users.FirstOrDefault(
                           usr => usr.Username == usernameToLower && usr.AuthCode == model.AuthCode);

                     if (user == null)
                     {
                         throw new InvalidOperationException("Invalid Username or Password");
                     }

                     user.SessionKey = UserDataPersister.GenerateSessionKey(user.Id);
                     context.SaveChanges();

                     var loggedModel = new UserLoggedModel
                     {
                         DisplayName = user.DisplayName,
                         SessionKey = user.SessionKey
                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                     response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));

                     return response;
                 });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var users = context.Users;
                     var user = users.FirstOrDefault(
                           usr => usr.SessionKey == sessionKey);

                     if (user == null)
                     {
                         throw new InvalidOperationException("Invalid Username or Password");
                     }

                     user.SessionKey = null;
                     context.SaveChanges();

                    var probUser = new UserLoginModel(){
                                           AuthCode = "10a81501e9a609a425db71c9a59be60dabbeea86",
                                           Username ="pesho"
                                           };
                     var response = this.Request.CreateResponse(HttpStatusCode.OK,
                         probUser);

                     return response;
                 });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage All()
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var users = context.Users;

                     var models =
                     (from u in users
                     select new UserModel
                     {
                         Id = u.Id,
                         User = u.DisplayName,
                         Role = u.Role.Name
                     });

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, models);

                     return response;
                 });

            return responseMsg;
        }
    }
}