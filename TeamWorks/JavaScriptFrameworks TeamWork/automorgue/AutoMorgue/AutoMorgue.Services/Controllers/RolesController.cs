using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMorgue.Data;
using AutoMorgue.Models;
using AutoMorgue.Services.Models;

namespace AutoMorgue.Services.Controllers
{
    public class RolesController : BaseApiController
    {
        [HttpPost]
        [ActionName("createRole")]
        public HttpResponseMessage CreateRole(CreateRoleModel model)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var roles = context.Roles;
                     var role = roles.FirstOrDefault(r => r.Name == model.Name);

                     if (role == null)
                     {
                         role = new Role
                         {
                             Name = model.Name
                         };
                     }
                     else
                     {
                         throw new Exception();
                     }

                     context.Roles.Add(role);
                     context.SaveChanges();

                     var response = this.Request.CreateResponse(HttpStatusCode.Created, role);

                     return response;

                 });

            return responseMsg;
        }      

        [HttpPut]
        [ActionName("changeRole")]
        public HttpResponseMessage ChangeRole(int userId, string role)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var users = context.Users;
                     var user = users.FirstOrDefault(usr => usr.Id == userId);

                     if (user == null)
                     {
                         throw new InvalidOperationException("Invalid Username or Password");
                     }

                     var selectedRole = context.Roles.FirstOrDefault(r => r.Name == role);
                     if (selectedRole == null)
                     {
                         selectedRole = new Role
                         {
                             Name = role
                         };
                         context.Roles.Add(selectedRole);
                         context.SaveChanges();
                     }

                     user.Role = selectedRole;

                     var response = this.Request.CreateResponse(HttpStatusCode.OK);

                     return response;

                 });

            return responseMsg;
        }      
    }
}