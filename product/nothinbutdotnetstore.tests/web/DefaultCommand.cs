using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class DefaultCommand:Command
    {
        public void process(Request request)
        {
            request.Process();
        }

        public bool can_handle(Request request)
        {
            throw new NotImplementedException();
        }
    }
}