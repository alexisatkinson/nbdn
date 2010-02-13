using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.container;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class ContainerSpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {
        }

        [Concern(typeof (DependencyContainer))]
        public class when_asked_to_resolve : concern
        {
            context c = () =>
            {
                actual_resolver = an<DependencyResolver>();
                resolver = () => actual_resolver;
                change(() => DependencyContainer.resolver).to(resolver);
            };

            because b = () =>
            {
                result = DependencyContainer.resolve;
            };


            it should_provide_access_to_the_underlying_container_framework = () =>
            {
                result.should_be_equal_to(actual_resolver);
            };

            static DependencyResolver result;
            static Func<DependencyResolver> resolver;
            static DependencyResolver actual_resolver;
        }
    }
}