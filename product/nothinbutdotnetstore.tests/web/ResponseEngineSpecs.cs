using System;
using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ResponseEngineSpecs
    {
        public class TheItemToDisplay
        {
        }

        public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                            DefaultResponseEngine>
        {
        }

        [Concern(typeof (DefaultResponseEngine))]
        public class when_displaying_an_item : concern
        {
            context c = () =>
            {
                view = an<View>();
                view_registry = the_dependency<ViewRegistry>();
                item = new TheItemToDisplay();
                view_created = an<ViewWithData<TheItemToDisplay>>();

                view.path = "blah";

                view_registry.Stub(x => x.get_view_for<TheItemToDisplay>()).Return(view);
                provide_a_basic_sut_constructor_argument<ViewFactory>((path, type) =>
                {
                    path_to_view = path;
                    view_type = type;
                    return view_created;
                });

                provide_a_basic_sut_constructor_argument<ViewHandler>((handler, preserve) =>
                {
                    view_server_handled = handler;
                });
            };

            because b = () =>
            {
                sut.display(item);
            };


            it should_ask_the_view_registry_for_the_view_that_can_display_the_item = () =>
            {
                view_registry.received(x => x.get_view_for<TheItemToDisplay>());
            };

            it should_create_the_associated_view_and_populate_it_with_it_data = () =>
            {
                view_created.view_model.should_be_equal_to(item);
                path_to_view.should_be_equal_to(view.path);
                view_type.should_be_equal_to(typeof (ViewWithData<TheItemToDisplay>));
            };

            it should_tell_the_server_to_transfer_control_to_the_view = () =>
            {
                view_server_handled.should_be_equal_to(view_created);
            };

            static ViewRegistry view_registry;
            static ViewWithData<TheItemToDisplay> view_created;
            static TheItemToDisplay item;
            static IHttpHandler view_server_handled;
            static string path_to_view;
            static View view;
            static Type view_type;
        }
    }
}