using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<FrontController,
                                            DefaultFrontController>
        {
        }

        [Concern(typeof (DefaultFrontController))]
        public class when_handling_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                command = an<Command>();
                command_registry = the_dependency<CommandRegistry>();

                command_registry.Stub(x => x.get_command_that_can_process(request)).Return(command);
            };

            because b = () =>
            {
                sut.handle(request);
            };


            it should_tell_the_factory_to_create_the_command_that_can_handle_the_request = () =>
            {
                command_registry.received(x => x.get_command_that_can_process(request));
            };

            it should_tell_the_command_to_process_the_request = () =>
            {
                command.received(x => x.process(request));
            };


            static Request request;
            static CommandRegistry command_registry;
            static Command command;
        }
    }
}