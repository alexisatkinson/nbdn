using System;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {

        IDictionary<string, Request> inital_values;

        public DefaultRequestFactory():this(create_init_requests())
        {
        }

        static IDictionary<string, Request> create_init_requests()
        {
            var values = new Dictionary<string, Request>();
            //values.Add("/views/Blah.store", new DepartmentRequest());
            //values.Add("/views/Blah.department", new SubDepartmentRequest());
            return values;
        }

        public DefaultRequestFactory(IDictionary<string, Request> inital_values)
        {
            this.inital_values = inital_values;
        }

        public Request create_from(HttpContext http_context)
        {
            string key = http_context.Request.Url.LocalPath;
            return inital_values[key];
        }
    }
}