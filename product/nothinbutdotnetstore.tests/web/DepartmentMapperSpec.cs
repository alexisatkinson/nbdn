using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.web.application
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
                request.Stub(x => x.GetValue<string>(RequestParameters.DepartmentName)).Return(department_name);
            };

            because b = () =>
            {
                result = sut.map_from(request);
            };


            it should_return_correctly_initialized_department = () =>
            {
                result.name.should_be_equal_to(department_name);
            };

            static Request request;
            static Department result;

            static string department_name = "Department Name";
        }
    }
}