using System.Web;

namespace nothinbutdotnetstore.tests.utility
{
    public class ObjectMother
    {
        public static HttpContext create_http_context()
        {
            return new HttpContext(create_request(), create_response());
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new System.IO.StringWriter());
        }

        static HttpRequest create_request()
        {
            return new HttpRequest("sdfsdf", "http://www.blah.com", string.Empty);
        }
    }
}