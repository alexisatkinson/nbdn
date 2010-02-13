using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class DepartmentMapperSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Mapper<Request, Department>,
                                            DepartmentMapper>
        {
        }

        [Concern(typeof (DepartmentMapper))]
        public class when_mapping_from_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                original = new Department {name = "blah"};
                payload = new Dictionary<string, object>();
                payload.Add(ReflectionUtility.get_name_of_property<Department>(x => x.name), original.name);
                request.Stub(x => x.payload).Return(payload);
            };

            because b = () =>
            {
                result = sut.map_from(request);
            };


            it should_return_correctly_initialized_department = () =>
            {
                result.name.should_be_equal_to(original.name);
            };

            static Request request;
            static Department result;
            static Dictionary<string, object> payload;
            static Department original;
        }
    }
}