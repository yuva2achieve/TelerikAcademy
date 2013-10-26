using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using AutoMorgue.Services.MessageHandlers;

namespace AutoMorgue.Services.App_Start
{
    public class HandlerConfig
    {
        public static void RegisterHandlers(Collection<DelegatingHandler> handlers)
        {
            handlers.Add(new CorsMessageHandler());
        }
    }
}