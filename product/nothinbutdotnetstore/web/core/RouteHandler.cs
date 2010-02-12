using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface RouteHandler
    {
        IHttpHandler GetHttpHandler(string url);
    }
}