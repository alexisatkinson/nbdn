using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;
using developwithpassion.bdd.core.extensions;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry, DefaultCommandRegistry>
        {
            context c = () =>
            {
                commands = new List<RoutedCommand>();
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<IEnumerable<RoutedCommand>>(commands);
            };

            protected static List<RoutedCommand> commands;
            protected static Request request;
            protected static RoutedCommand result;
        }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            context c = () =>
            {
                routed_command_that_can_handle_the_request = an<RoutedCommand>();

                commands.Add(an<RoutedCommand>());
                commands.Add(routed_command_that_can_handle_the_request);

                routed_command_that_can_handle_the_request.Stub(x => x.can_handle(request)).Return(true);
            };

            because b = () =>
            {
                result = sut.get_command_that_can_process_the_request(request);
            };


            it should_return_the_command_that_can_do_the_processing = () =>
            {
                result.should_be_equal_to(routed_command_that_can_handle_the_request);
            };


            static RoutedCommand routed_command_that_can_handle_the_request;
        }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_trying_to_get_a_command_that_can_process_a_request_and_there_is_no_command_that_can_handle_it : concern
        {
            context c = () =>
            {
                Enumerable.Range(1,100).each(x => commands.Add(an<RoutedCommand>()));
            };

            because b = () =>
            {
                result = sut.get_command_that_can_process_the_request(request);
            };


            it should_return_the_command_that_can_do_the_processing = () =>
            {
                result.should_be_an_instance_of<MissingRoutedCommandForRequest>();
            };


        }
    }
}