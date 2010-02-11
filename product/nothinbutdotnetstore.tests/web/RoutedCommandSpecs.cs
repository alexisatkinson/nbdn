using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using developwithpassion.bdd.mocking.rhino;

namespace nothinbutdotnetstore.tests.web
{
    public class RoutedCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RoutedCommand,
                                            DefaultRoutedCommand>
        {
        }

        [Concern(typeof (RoutedCommand))]
        public class when_determining_if_it_can_handle_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<Predicate<Request>>(x => true);
            };

            because b = () =>
            {
                result = sut.can_handle(request);
            };


            it should_make_the_determination_by_leveraging_its_request_specification = () =>
            {
                result.should_be_true();
            };

            protected static Request request;
            static bool result;
        }

        [Concern(typeof (RoutedCommand))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<Predicate<Request>>(x => false);
                app_command = the_dependency<ApplicationCommand>();
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_delegate_the_processing_to_the_application_specific_command = () =>
            {
                app_command.received(x => x.process(request));
            };

            static Request request;
            static ApplicationCommand app_command;
        }
    }
}