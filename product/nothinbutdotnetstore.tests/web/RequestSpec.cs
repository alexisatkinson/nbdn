using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using Rhino.Mocks;

namespace nothinbutdotnetstore.web.core
{
    public class RequestSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Request, DefaultRequest>
        {
        }

        [Concern(typeof(DefaultRequest))]
        public class when_map_is_called : concern
        {
            context c = () =>
            {
                request = an<Request>();
                testInstance = an<MappingTest>();
            };

            because b = () =>
            {
                testInstance = new MappingTest();
                mapper = (x => testInstance);
                result = sut.map<MappingTest>(mapper);

            };

            it should_should_return_instance_of_mapped_object = () =>
            {
                result.should_be_an_instance_of<MappingTest>();
            };

            it should_return_object_mapped_by_mapper = () =>
            {
                result.should_be_equal_to(testInstance);
            };

            static Request request;
            static MappingTest result;
            static MappingTest testInstance;
            static Func<Request, MappingTest> mapper;
            
        }
    }

    public class MappingTest
    {

    }
}