using System;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.container;

namespace nothinbutdotnetstore.tests.web
{
    public class FunctionalItemResolverSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ItemResolver,
                                            FunctionalItemResolver>
        {
        }

        [Concern(typeof (FunctionalItemResolver))]
        public class when_resolving_an_item : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                provide_a_basic_sut_constructor_argument<Func<object>>(() => sql_connection);
            };

            because b = () =>
            {
                result = sut.resolve();
            };


            it should_return_the_result_of_its_delegate_invocation = () =>
            {
                result.should_be_equal_to(sql_connection);
            };

            static object result;
            static SqlConnection sql_connection;
        }
    }
}