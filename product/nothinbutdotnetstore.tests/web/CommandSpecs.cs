using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Command,
                                            DefaultCommand>
        {
        }

        [Concern(typeof (DefaultCommand))]
        public class when_an_instance_of_a_command_exists_with_a_valid_request : concern
        {
            context c = () =>
            {
                var requests = new List<Request>();
                request = an<Request>();
                requests.Add(request);
                provide_a_basic_sut_constructor_argument<IEnumerable<Request>>(requests);
            };

            because b = () =>
            {
                result = sut.can_handle(request);
            };


            it should_return_true_if_it_can_handle_a_request = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static Command command;
            static Request request;
        }

        [Concern(typeof(DefaultCommand))]
        public class when_an_instance_of_a_command_exists_with_a_invalid_request : concern
        {
            context c = () =>
            {
                var requests = new List<Request>();
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<IEnumerable<Request>>(requests);
            };

            because b = () =>
            {
                result = sut.can_handle(request);
            };

            it should_return_false_if_it_can_not_handle_a_request = () =>
            {
                result.should_be_false();
            };

            static bool result;
            static Command command;
            static Request request;
        }
    }
}