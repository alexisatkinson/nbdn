using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<RequestFactory, DefaultRequestFactory>
         {
        
         }

         [Concern(typeof(DefaultRequestFactory))]
         public class when_provided_with_an_http_context : concern
         {
             context c = () =>
             {
                 IDictionary<string, Request> inital_values = new Dictionary<string, Request>();
                 context = new HttpContext(new HttpRequest("", "http://test.com/page.page", ""), new HttpResponse(new System.IO.StringWriter()));
               //  dummy_reqest = new DummyReqest();
               //  inital_values.Add(context.Request.Url.LocalPath, dummy_reqest);
                 provide_a_basic_sut_constructor_argument(inital_values);
             };

             because b = () =>
             {
                 result = sut.create_from(context);
             };

        
             it should_return_the_request_associated_with_that_context = () =>
             {
             //   result.should_be_equal_to(dummy_reqest);
             };

             static Request result;
             static HttpContext context;
            // static DummyReqest dummy_reqest;
         }
     }

 }
