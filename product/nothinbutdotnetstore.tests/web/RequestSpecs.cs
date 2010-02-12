 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestSpecs
     {
         public class TypeToReturn
         {
             
         }
         public abstract class concern : observations_for_a_sut_with_a_contract<Request,
                                             DefaultRequest>
         {
        
         }

         [Concern(typeof(DefaultRequest))]
         public class when_asked_to_map_to_a_specific_type : concern
         {
             context c = () =>
             {

            
             };

             because b = () =>
             {
                 type_to_return = sut.map<TypeToReturn>();
             };

        
             it should_map_the_request_to_a_specific_type = () =>
             {
                 type_to_return.should_be_an_instance_of<TypeToReturn>();
             };

             static TypeToReturn type_to_return;
         }
     }

     public class DefaultRequest : Request
     {
         public ItemToMap map<ItemToMap>()
         {

         }
     }
 }
