using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.container;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class AutoWiringResolverSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ItemResolver,
                                            AutoWiringResolver>
        {
        }

        [Concern(typeof (AutoWiringResolver))]
        public class when_resolving_a_item_with_dependencies : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                command = new SqlCommand();
                some_other_class = new SomeOtherClass();
                dependency_resolver = the_dependency<DependencyResolver>();
                constructor_selection_strategy = the_dependency<ConstructorSelectionStrategy>();


                dependency_resolver.Stub(x => x.an(typeof(IDbConnection))).Return(sql_connection);
                dependency_resolver.Stub(x => x.an(typeof(IDbCommand))).Return(command);
                dependency_resolver.Stub(x => x.an(typeof(SomeOtherClass))).Return(some_other_class);

                provide_a_basic_sut_constructor_argument(typeof(OurItemWithDependencies));

                constructor_selection_strategy.Stub(x => x.get_appropriate_constructor_for(typeof (OurItemWithDependencies)))
                    .Return(typeof (OurItemWithDependencies).GetConstructors()[0]);
            };

            because b = () =>
            {
                result = sut.resolve();
            };


            it should_return_the_item_with_all_of_the_dependencies_satisfied_by_the_container_itself = () =>
            {
                var our_item_with_dependencies = result.should_be_an_instance_of<OurItemWithDependencies>();
                our_item_with_dependencies.connection.should_be_equal_to(sql_connection);
                our_item_with_dependencies.command.should_be_equal_to(command);
                our_item_with_dependencies.some_other_class.should_be_equal_to(some_other_class);
            };

            static object result;
            static SqlConnection sql_connection;
            static SqlCommand command;
            static SomeOtherClass some_other_class;
            static DependencyResolver dependency_resolver;
            static ConstructorSelectionStrategy constructor_selection_strategy;
        }


        public class SomeOtherClass
        {
        }

        public class OurItemWithDependencies
        {
            public IDbConnection connection { get; private set; }

            public IDbCommand command { get; private set; }

            public SomeOtherClass some_other_class { get; private set; }

            public OurItemWithDependencies(IDbConnection connection, IDbCommand command, SomeOtherClass some_other_class)
            {
                this.connection = connection;
                this.command = command;
                this.some_other_class = some_other_class;
            }
        }
    }
}