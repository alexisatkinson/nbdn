using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.tests.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RawHandlerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<IHttpHandler,
                                            RawHandler>
        {
        }

        [Concern(typeof (RawHandler))]
        public class when_processing_an_http_context : concern
        {
            context c = () =>
            {
                front_controller = the_dependency<FrontController>();
                request_factory = the_dependency<RequestFactory>();
                http_context = ObjectMother.create_http_context();
                request = an<Request>();

                request_factory.Stub(x => x.create_from(http_context)).Return(request);

            };

            because b = () =>
            {
                sut.ProcessRequest(http_context);
            };


            it should_tell_the_front_controller_to_handle_the_request_create_by_the_request_factory = () =>
            {
                front_controller.received(x => x.handle(request));
            };

            static FrontController front_controller;
            static Request request;
            static HttpContext http_context;
            static RequestFactory request_factory;
        }
        [Concern(typeof (RawHandler))]
        public class when_asked_if_it_is_reusable : concern
        {
            context c = () =>
            {

            };

            because b = () =>
            {
                result = sut.IsReusable;
            };


            it should_be = () =>
            {
                result.should_be_true();
            };

            static bool result;
        }
    }
}