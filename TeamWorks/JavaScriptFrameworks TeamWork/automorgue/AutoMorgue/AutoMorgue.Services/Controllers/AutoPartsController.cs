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
    public class AutoPartsController : BaseApiController
    {
        [HttpPost]
        [ActionName("add")]
        public HttpResponseMessage AddAutoPart(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey, AutoPartAddModel model)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();


                     var users = context.Users;
                     var user = users.FirstOrDefault(
                           usr => usr.SessionKey == sessionKey);

                     if (user.Role.Name != "admin")
                     {
                         throw new InvalidOperationException("You don't have permission to add auto parts.");
                     }

                     var morgue = context.Morgues.Where(m => m.Name == model.Morgue).FirstOrDefault();

                     if (morgue == null)
                     {
                         throw new InvalidOperationException();
                     }

                     var cat = context.Categories.FirstOrDefault(c=>c.Name == model.Name);

                     if (cat == null)
                     {
                         cat = new Category
                         {
                             Name = model.Category
                         };
                     }

                     var newAutoPart = new AutoPart
                     {
                         Name = model.Name,
                         Price = model.Price,
                         Quantity = model.Quantity,
                         Morgue = morgue,
                         Category = cat
                     };

                     context.AutoParts.Add(newAutoPart);
                     context.SaveChanges();

                     var createdModel = new CreatedAutoPartModel
                     {
                         Name = newAutoPart.Name
                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.Created, createdModel);
                     response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newAutoPart.Id }));

                     return response;

                 });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("update")]
        public HttpResponseMessage UpdateAutoPart(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey, AutoPartUpdateModel model)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var users = context.Users;
                     var user = users.FirstOrDefault(
                           usr => usr.SessionKey == sessionKey);

                     if (user.Role.Name != "admin")
                     {
                         throw new InvalidOperationException("You don't have permission to edit auto parts.");
                     }

                     var curAutoPart = context.AutoParts.Where(a => a.Id == model.Id).FirstOrDefault();

                     if (curAutoPart.Name != model.Name)
                     {
                         curAutoPart.Name = model.Name;
                     }

                     if (curAutoPart.Price != model.Price)
                     {
                         curAutoPart.Price = model.Price;
                     }

                     if (curAutoPart.Quantity != model.Quantity)
                     {
                         curAutoPart.Quantity = model.Quantity;
                     }

                     context.SaveChanges();

                     var autoPartModel = new ReturnedAutoPartModel
                     {
                         Id = curAutoPart.Id,
                         Name = curAutoPart.Name,
                         MorgueName = curAutoPart.Morgue.Name,
                         Price = curAutoPart.Price,
                         Quantity = curAutoPart.Quantity,
                         Category = curAutoPart.Category.Name
                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, autoPartModel);

                     return response;
                 });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("sale")]
        public HttpResponseMessage SaleAutoPart(AutoPartSaleModel model)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     //TODO: Validate Data
                     //UserDataPersister.ValidateUsername(model.Name);
                     //UserDataPersister.ValidateNickname(model.Location);
                     //UserDataPersister.ValidateAuthCode(model.PhoneNumber);
                     var curAutoPart = context.AutoParts.Where(a => a.Id == model.Id).FirstOrDefault();

                     curAutoPart.Quantity = model.Quantity;

                     context.SaveChanges();

                     var autoPartModel = new ReturnedAutoPartModel
                     {
                         Id = curAutoPart.Id,
                         Name = curAutoPart.Name,
                         MorgueName = curAutoPart.Morgue.Name,
                         Price = curAutoPart.Price,
                         Quantity = curAutoPart.Quantity,
                         Category = curAutoPart.Category.Name
                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, autoPartModel);

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

                   var autoParts = context.AutoParts.Where(a=>a.Quantity > 0);
                     var models = (
                         from a in autoParts
                         select new ReturnedAutoPartModel
                         {
                             Id = a.Id,
                             Name = a.Name,
                             MorgueName = a.Morgue.Name,
                             Price = a.Price,
                             Quantity = a.Quantity,
                             Category = a.Category.Name
                         }).ToList();

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, models);

                     return response;
                 });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetById(int autoPartId)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var autoPart = context.AutoParts.Where(p => p.Id == autoPartId).FirstOrDefault();

                     var model = new ReturnedAutoPartModel
                     {
                         Id = autoPart.Id,
                         Name = autoPart.Name,
                         MorgueName = autoPart.Morgue.Name,
                         Price = autoPart.Price,
                         Quantity = autoPart.Quantity,
                         Category = autoPart.Category.Name
                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, model);

                     return response;
                 });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetByMorgueId(int morgueId)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var autoParts = context.AutoParts.Where(a => a.Morgue.Id == morgueId);

                     var models = (
                         from a in autoParts
                         select new ReturnedAutoPartModel
                     {
                         Id = a.Id,
                         Name = a.Name,
                         MorgueName = a.Morgue.Name,
                         Price = a.Price,
                         Quantity = a.Quantity,
                         Category = a.Category.Name

                     }).ToList();

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, models);

                     return response;
                 });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetByCategory(string categoryName)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var autoParts = context.AutoParts.Where(a => a.Category.Name == categoryName);

                     var models = (
                         from a in autoParts
                         select new ReturnedAutoPartModel
                         {
                             Id = a.Id,
                             Name = a.Name,
                             MorgueName = a.Morgue.Name,
                             Price = a.Price,
                             Quantity = a.Quantity,
                             Category = a.Category.Name
                         }).ToList();

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, models);

                     return response;
                 });

            return responseMsg;
        }
    }
}