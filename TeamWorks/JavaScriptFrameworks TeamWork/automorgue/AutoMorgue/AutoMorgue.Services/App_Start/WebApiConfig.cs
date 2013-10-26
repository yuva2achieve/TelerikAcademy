﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AutoMorgue.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
               name: "AdminApi",
               routeTemplate: "api/admin/{action}",
               defaults: new
               {
                   controller = "admin"
               }
           );

            config.Routes.MapHttpRoute(
               name: "AutoPartsApi",
               routeTemplate: "api/autoparts/{action}",
               defaults: new
               {
                   controller = "AutoParts"
               }
           );

            config.Routes.MapHttpRoute(
               name: "MorgueApi",
               routeTemplate: "api/morgues/{action}",
               defaults: new
               {
                   controller = "morgues"
               }
           );

            config.Routes.MapHttpRoute(
               name: "UserApi",
               routeTemplate: "api/users/{action}",
               defaults: new
               {
                   controller = "users"
               }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
