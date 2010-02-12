 using System;
 using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class HttpHandlerFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<HttpHandlerFactory,
                                             DefaultHttpHandlerFactory>
         {
        
         }

         [Concern(typeof(DefaultHttpHandlerFactory))]
         public class when_asked_to_create_a_handler_for_a_valid_url : concern
         {
             context c = () =>
             {
                 url = "blah";

            
             };

             because b = () =>
             {
                 sut.CreateHandler(url);
        
             };

        
             it should_return_a_handler = () =>
             {
                 handler.should_be_an_instance_of<IHttpHandler>();
             };


             static string url;
             static IHttpHandler handler;
         }
     }

     public class DefaultHttpHandlerFactory : HttpHandlerFactory
     {
         public IHttpHandler CreateHandler(string url)
         {

             throw new NotImplementedException();
         }
     }
 }
