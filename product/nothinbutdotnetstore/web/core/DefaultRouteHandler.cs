using System;
using System.Collections.Generic;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRouteHandler : RouteHandler
    {
        Dictionary<string, IHttpHandler> httpHandlers;
        HttpHandlerFactory http_handler_factory;
        public DefaultRouteHandler(HttpHandlerFactory http_handler_factory)
        {
            this.http_handler_factory = http_handler_factory;
            httpHandlers = new Dictionary<string, IHttpHandler>();
        }

        public IHttpHandler GetHttpHandler(string url)
        {
            IHttpHandler handler_to_return;
            if(!httpHandlers.TryGetValue(url, out handler_to_return))
            {
                handler_to_return = http_handler_factory.CreateHandler(url);
                httpHandlers.Add(url, handler_to_return);
            }
            return handler_to_return;
        }
    }
}