using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Request,
                                             DefaultRequest>
         {
        
         }

         [Concern(typeof(DefaultRequest))]
         public class when_map_function_is_invoked : concern
         {
             context c = () =>
             {
                 dummy = an <DummyClass>();
                 mappings = new Dictionary<Type, object>();
                 mappings.Add(typeof(DummyClass), dummy);
                 provide_a_basic_sut_constructor_argument<IDictionary<Type, Object>>(mappings);
             };

             because b = () =>
             {
                 result = sut.map<DummyClass>();
             };


             it returns_an_instance_of_the_requested_type = () =>
             {
                 result.should_be_an_instance_of<DummyClass>();

             };

             static DummyClass result;
             static DummyClass dummy;
             static Dictionary<Type, Object> mappings;
         }
     }

     public class DummyClass
     {

     }
 }
