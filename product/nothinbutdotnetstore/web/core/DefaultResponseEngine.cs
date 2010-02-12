using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultResponseEngine : ResponseEngine
    {
        public static readonly string VIEW_DATA = "ViewData";

        private RouteHandler route_handler;

        public DefaultResponseEngine(RouteHandler route_handler)
        {
            this.route_handler = route_handler;
             
        }
        public void handle<Item>(Item item)
        {
            //TODO how can you test this?
            HttpContext.Current.Items.Add(VIEW_DATA, item);
            IHttpHandler http_handler = route_handler.GetHttpHandler(HttpContext.Current.Request.Url.LocalPath);
            http_handler.ProcessRequest(HttpContext.Current);
        }
    }
}