using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommand:RoutedCommand
    {
        IEnumerable<Request> requests;

        public DefaultCommand(IEnumerable<Request> requests)
        {
            this.requests = requests;
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_handle(Request request)
        {
            return requests.Contains(request);
        }
    }
}