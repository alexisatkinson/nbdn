using System;
using System.Collections.Generic;
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
     public class ViewProductsSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             ViewProducts>
         {
        
         }

         [Concern(typeof(ViewProducts))]
         public class when_run : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 repository = the_dependency<Repository>();
                 response_engine = the_dependency<ReponseEngine>();

                 department = new Department();
                 products = new List<Product>();

                 request.Stub(x => x.map<Department>()).Return(department);
                 repository.Stub(x => x.get_all_products_in(department)).Return(products);
             };

             because b = () =>
             {
                 sut.process(request);
             };

             it should_tell_the_response_engine_to_display_the_products = () =>
             {
                 response_engine.received(x => x.handle(products));
             };

             static Repository repository;
             static Request request;
             static ReponseEngine response_engine;
             static Department department;
             static IEnumerable<Product> products;
         }
     }
 }
