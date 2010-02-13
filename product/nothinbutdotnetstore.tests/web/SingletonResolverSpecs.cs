using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.container;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class SingletonResolverSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ItemResolver,
                                            SingletonItemResolver>
        {
        }

        [Concern(typeof (SingletonItemResolver))]
        public class when_asked_to_resolve_multiple_times : concern
        {
            context c = () =>
            {
                original_resolver = the_dependency<ItemResolver>();
                original_resolver.Stub(x => x.resolve()).Return(new object());
            };

            after_the_sut_has_been_created ac = () =>
            {
                first_instance = sut.resolve();
            };

            because b = () =>
            {
                second_instance = sut.resolve();
            };


            it should_always_return_the_same_instance = () =>
            {
                second_instance.should_be_equal_to(first_instance);
            };

            static object second_instance;
            static object first_instance;
            static ItemResolver original_resolver;
        }
    }
}