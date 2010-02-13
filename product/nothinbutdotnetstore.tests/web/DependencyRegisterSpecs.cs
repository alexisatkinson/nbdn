 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.tests.web
 {   
     public class DependencyRegisterSpecs
     {
         interface 
         {
             
         }
         public abstract class concern : observations_for_a_sut_with_a_contract<DependencyRegister,
                                             DefaultDependencyRegister>
         {
        
         }

         [Concern(typeof(DefaultDependencyRegister))]
         public class when_adding_a_dependency_to_the_register : concern
         {
             context c = () =>
             {
                 dependency_store = an<IDictionary<>()

            
             };

             because b = () =>
             {
                 sut.register_dependency()
        
             };

        
             it should_return_a_dependency_of_the_requested_type = () =>
             {
                 
            
            
             };
         }
     }
 }
