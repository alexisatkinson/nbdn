using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class DepartmentMapper : Mapper<Request, Department>
    {
        public Department map_from(Request input)
        {
            return new Department {name = input.get_value<string>(ReflectionUtility.get_name_of_property<Department>(x => x.name))};
        }
    }
}