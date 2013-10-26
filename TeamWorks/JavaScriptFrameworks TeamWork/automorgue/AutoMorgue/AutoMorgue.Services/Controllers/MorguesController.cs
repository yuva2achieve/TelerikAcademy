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
    public class MorguesController : BaseApiController
    {
        [HttpGet]
        [ActionName("locations")]
        public HttpResponseMessage GetLocations()
        {
            var responce = this.ExceptionHandler(() =>
            {
                var context = new AutoMorgueContext();

                var locations = (from location in context.Locations
                                 select location).ToList();

                return this.Request.CreateResponse(HttpStatusCode.OK, locations);
            });

            return responce;
        }

        [HttpPost]
        [ActionName("add")]
        public HttpResponseMessage AddMorgue([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey, MorgueAddModel model)
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
                         throw new InvalidOperationException("You don't have permission to add morgues.");
                     }

                     var nameToLower = model.Name.ToLower();

                     var morgues = context.Morgues;
                     var morgue = morgues.FirstOrDefault(m => m.Name == nameToLower && m.Location.City == model.Location);

                     if (morgue != null)
                     {
                         //TODO: Correct exception message
                         throw new InvalidOperationException("Morgue with ");
                     }

                     Location curLocation;
                     var locations = context.Locations;
                     var location = locations.FirstOrDefault(l => l.City == model.Location);

                     if (location != null)
                     {
                         curLocation = location;
                     }
                     else
                     {
                         curLocation = new Location
                         {
                             City = model.Location
                         };

                         locations.Add(curLocation);
                         context.SaveChanges();
                     }

                     var newMorgue = new Morgue
                     {
                         Name = model.Name,
                         PhoneNumber = model.PhoneNumber,
                         Location = curLocation,
                         WorkTime = model.WorkTime
                     };

                     context.Morgues.Add(newMorgue);
                     context.SaveChanges();

                     var createdModel = new CreatedMorgueModel
                     {
                         Name = newMorgue.Name
                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.Created, createdModel);
                     response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newMorgue.Id }));

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

                     var morgues = context.Morgues.ToList();

                     var models = (from m in morgues
                                   select new ReturnedMorgueModel
                                   {
                                       Id = m.Id,
                                       Location = m.Location.City,
                                       Name = m.Name,
                                       PhoneNumber = m.PhoneNumber,
                                       WorkTime = m.WorkTime,
                                   });


                     var response = this.Request.CreateResponse(HttpStatusCode.OK, models);

                     return response;
                 });

            return responseMsg;
        }

        [HttpGet]

        public HttpResponseMessage GetById(int morgueId)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var morgue = context.Morgues.Where(m => m.Id == morgueId).FirstOrDefault();

                     var morgueModel = new ReturnedMorgueModel
                     {
                         Id = morgue.Id,
                         Location = morgue.Location.City,
                         Name = morgue.Name,
                         PhoneNumber = morgue.PhoneNumber,
                         WorkTime = morgue.WorkTime,
                         Parts = (from p in morgue.AutoParts
                                  select new AutoPartModel
                                  {
                                      Name = p.Name,
                                      Price = p.Price,
                                      Quantity = p.Quantity
                                  })

                     };

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, morgueModel);

                     return response;
                 });

            return responseMsg;
        }

        [HttpGet]
        public HttpResponseMessage GetByLocation(string location)
        {
            var responseMsg = this.ExceptionHandler(
                 () =>
                 {
                     var context = new AutoMorgueContext();

                     var morgues = context.Morgues.Where(m => m.Location.City.ToLower() == location.ToLower()).ToList();

                     var models = (from m in morgues
                                   select new ReturnedMorgueModel
                                   {
                                       Id = m.Id,
                                       Location = m.Location.City,
                                       Name = m.Name,
                                       PhoneNumber = m.PhoneNumber,
                                       WorkTime = m.WorkTime,
                                   });

                     var response = this.Request.CreateResponse(HttpStatusCode.OK, models);

                     return response;
                 });

            return responseMsg;
        }
    }
}
