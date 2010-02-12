using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Request, DefaultRequest>
        {
        }

        [Concern(typeof (DefaultRequest))]
        public class when_mapping_an_item : concern
        {
            context c = () =>
            {
                mapper = an<Mapper<Request, FakeMappedItem>>();
                mapper_registry = the_dependency<MapperRegistry>();
                mapped_instance = new FakeMappedItem();

                mapper_registry.Stub(x => x.get_mapper_for<Request, FakeMappedItem>()).Return(mapper);
                mapper.Stub(x => x.map_from(Arg<Request>.Is.NotNull)).Return(mapped_instance);
            };

            because b = () =>
            {
                result = sut.map<FakeMappedItem>();
            };

            it should_return_object_mapped_by_mapper = () =>
            {
                result.should_be_equal_to(mapped_instance);
            };

            static FakeMappedItem result;
            static FakeMappedItem mapped_instance;
            static Mapper<Request, FakeMappedItem> mapper;
            static MapperRegistry mapper_registry;
        }

        public class FakeMappedItem
        {
        }
    }
}