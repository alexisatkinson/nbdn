using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RouteHandlerSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ViewRegistry,
                                             DefaultViewRegistry>
         {
        
         }

         [Concern(typeof(DefaultViewRegistry))]
         public class when_asked_for_a_handler_for_a_path_that_doesnt_already_have_a_handler : concern
         {
             context c = () =>
             {
                 url = "blah";
                 handler_factory = the_dependency<HttpHandlerFactory>();
             };

             because b = () =>
             {
                 sut.get_view_for<int>();
             };

        
             it should_create_ask_the_handler_factory_to_create_a_handler = () =>
             {
                 handler_factory.received(x => x.CreateHandler(url));
             };


             static HttpHandlerFactory handler_factory;
             static string url;

         }

         [Concern(typeof(DefaultViewRegistry))]
         public class when_asked_for_a_handler_for_a_path_whereby_we_already_have_a_handler : concern
         {
             context c = () =>
             {
                 url = "blah";
                 handler_factory = the_dependency<HttpHandlerFactory>();
             };

             because b = () =>
             {
                 handler1 = sut.get_view_for<int>();
                 handler2 = sut.get_view_for<int>();
             };

             it should_return_a_handler = () =>
             {
                 handler1.should_be_an_instance_of<IHttpHandler>();
             };

             it should_reuse_an_existing_handler = () =>
             {
                 handler1.should_be_equal_to(handler2);
             };

             static HttpHandlerFactory handler_factory;
             static View handler1;
             static View handler2;
             static string url;

         }

         
     }
 }
