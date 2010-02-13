using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tests.utility;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.container;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class DependencyResolverSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<DependencyResolver,
                                            DefaultDependencyResolver>
        {
            context c = () =>
            {
                dependencies = new Dictionary<Type, ItemResolver>();
                provide_a_basic_sut_constructor_argument(dependencies);
            };

            protected static IDictionary<Type, ItemResolver> dependencies;
        }

        [Concern(typeof (DefaultDependencyResolver))]
        public class when_resolving_a_dependency_and_it_has_a_resolver_for_that_dependency : concern
        {
            context c = () =>
            {
                connection = new SqlConnection();
                connection_resolver = an<ItemResolver>();
                dependencies.Add(typeof (IDbConnection), connection_resolver);

                connection_resolver.Stub(x => x.resolve()).Return(connection);
            };


            because b = () =>
            {
                result = sut.an<IDbConnection>();
            };


            it should_return_the_item_resolved_the_type_item_resolver = () =>
            {
                result.should_be_equal_to(connection);
            };

            static SqlConnection connection;
            static IDbConnection result;
            static ItemResolver connection_resolver;
        }

        [Concern(typeof (DefaultDependencyResolver))]
        public class when_attempting_to_resolve_a_dependency_and_there_is_no_item_resolver_for_that_dependency : concern
        {
            because b = () =>
            {
                doing(() => sut.an<IDbConnection>());
            };


            it should_throw_a_resolver_not_registered_exception = () =>
            {
                exception_thrown_by_the_sut.should_be_an_instance_of<ItemResolverNotRegisteredException>()
                    .type_that_could_not_be_resolved.should_be_equal_to(typeof(IDbConnection));
            };

        }

        [Concern(typeof (DefaultDependencyResolver))]
        public class when_resolving_a_dependency_and_the_item_resolver_for_the_dependency_throws_an_exception : concern
        {
            context c = () =>
            {
                resolver = an<ItemResolver>();
                original_exception = new Exception();
                dependencies.Add(typeof(IDbConnection),resolver);
                resolver.Stub(x => x.resolve()).Throw(original_exception);

            };
            because b = () =>
            {
                doing(() => sut.an<IDbConnection>());
            };


            it should_throw_an_item_resolution_exception = () =>
            {
                var resolution_exception = exception_thrown_by_the_sut.should_be_an_instance_of<ItemResolutionException>();
                resolution_exception.type_that_could_not_be_resolved.should_be_equal_to(typeof(IDbConnection));
                resolution_exception.InnerException.should_be_equal_to(original_exception);
            };

            static ItemResolver resolver;
            static Exception original_exception;
        }
    }
}