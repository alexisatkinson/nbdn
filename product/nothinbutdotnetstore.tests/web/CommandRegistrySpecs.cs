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
                commands = new List<Command>();
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<IEnumerable<Command>>(commands);
            };

            protected static List<Command> commands;
            protected static Request request;
            protected static Command result;
        }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            context c = () =>
            {
                command_that_can_handle_the_request = an<Command>();

                commands.Add(an<Command>());
                commands.Add(command_that_can_handle_the_request);

                command_that_can_handle_the_request.Stub(x => x.can_handle(request)).Return(true);
            };

            because b = () =>
            {
                result = sut.get_command_that_can_process_the_request(request);
            };


            it should_return_the_command_that_can_do_the_processing = () =>
            {
                result.should_be_equal_to(command_that_can_handle_the_request);
            };


            static Command command_that_can_handle_the_request;
        }

        [Concern(typeof (DefaultCommandRegistry))]
        public class when_trying_to_get_a_command_that_can_process_a_request_and_there_is_no_command_that_can_handle_it : concern
        {
            context c = () =>
            {
                Enumerable.Range(1,100).each(x => commands.Add(an<Command>()));
            };

            because b = () =>
            {
                result = sut.get_command_that_can_process_the_request(request);
            };


            it should_return_the_command_that_can_do_the_processing = () =>
            {
                result.should_be_an_instance_of<MissingCommandForRequest>();
            };


        }
    }
}