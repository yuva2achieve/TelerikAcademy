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
    public class OrdersController : BaseApiController
    {
        [HttpPost]
        [ActionName("makeOrder")]
        public HttpResponseMessage MakeOrder(MakeOrderModel model)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var users = context.Users;
                     var user = users.FirstOrDefault(usr => usr.Id == model.UserId);

                     var autoParts = context.AutoParts;
                     var autoPart = autoParts.FirstOrDefault(a => a.Id == model.AutoPartId && a.Quantity >= model.Quantity);

                     if (user == null || autoPart == null)
                     {
                         throw new InvalidOperationException("Invalid Username or Password");
                     }

                     var newOrder = new Order
                     {
                         AutoPart = autoPart,
                         User = user,
                         OrderDate = DateTime.Now
                     };

                     autoPart.Quantity -= model.Quantity;
                     context.Orders.Add(newOrder);
                     context.SaveChanges();

                     var response = this.Request.CreateResponse(HttpStatusCode.Created, newOrder.Id);
                     response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newOrder.Id }));

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

                     var orders = context.Orders;

                     var models =
                    (from o in orders
                     select new OrderModel
                     {
                         Id = o.Id,
                         User = o.User.DisplayName,
                         AutoPart = o.AutoPart.Name,
                         OrderDate = o.OrderDate
                     }).ToList();

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, models);

                     return response;
                 });

            return responseMsg;
        }
    }
}