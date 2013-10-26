﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoMorgue.Services.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T ExceptionHandler<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);

                throw new HttpResponseException(errResponse);
            }
        }
    }
}
