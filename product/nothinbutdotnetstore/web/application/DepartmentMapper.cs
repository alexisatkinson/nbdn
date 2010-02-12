using System;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class DepartmentMapper : Mapper<Request,Department>
    {
        public Department map_from(Request input)
        {
            return new Department { name = input.GetValue<string>(RequestParameters.DepartmentName) };
        }
    }
}