using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface HttpHandlerFactory
    {
        IHttpHandler CreateHandler(string url);
    }
}