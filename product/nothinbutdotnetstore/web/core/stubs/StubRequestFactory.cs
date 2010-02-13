using System.Web;
using nothinbutdotnetstore.domain.stubs;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new DefaultRequest(new StubMapperRegisrty());
        }
    }
}