using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.tests.utility
{
    public class ReflectionUtilitySpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {
        }

        [Concern(typeof (ReflectionUtility))]
        public class when_getting_the_name_of_a_property_from_the_expression_that_points_to_that_property : concern
        {
            context c = () =>
            {
            };

            because b = () =>
            {
                result = ReflectionUtility.get_name_of_property<Person>(x => x.name);
            };


            it should_get_the_correct_name_of_the_property_on_the_target_type = () =>
            {
                result.should_be_equal_to("name");
            };

            static string result;
        }

        class Person
        {
            public string name { get; set; }
        }
    }
}