 using System;
 using System.Web;
 using System.Web.Compilation;
 using System.Web.UI;
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
         public class ItemToHandle
         {
             
         }
         public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                             DefaultResponseEngine>
         {
        
         }

         [Concern(typeof(DefaultResponseEngine))]
         public class when_handling_a_response_item : concern
         {
             context c = () =>
             {
                 url = an<string>();
                 itemToHandle = an<ItemToHandle>();
                 route_handler = the_dependency<RouteHandler>();
                 http_handler = an<IHttpHandler>();
//                 http_context = an<HttpContext>();
                 route_handler.Stub(x => x.GetHttpHandler(url)).Return(http_handler);
             };

             because b = () =>
             {
                 sut.handle(itemToHandle);
             };
             
        
             it should_ask_the_route_handler_for_an_http_handler = () =>
             {
                 route_handler.received(x => x.GetHttpHandler(url));
             };

             it should_store_the_item_to_handle_in_the_request_context = () =>
             {
                 //TODO HOW TO TEST?
                 
             };

             it should_ask_the_http_handler_to_process = () =>
             {
                 //TODO WORK OUT WHAT TO DO AS YOU CAN'T MOCK HTTP CONTEXT
//                 http_handler.received(x => x.ProcessRequest(http_context));


             };

             static RouteHandler route_handler;
             static ItemToHandle itemToHandle;
             static IHttpHandler http_handler;
             static string url;
//             static HttpContext http_context;
         }
     }
 }
