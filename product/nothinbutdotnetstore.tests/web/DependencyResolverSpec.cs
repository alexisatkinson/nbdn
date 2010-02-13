 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class DependencyResolverSpec
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<DependencyResolver,
                                             DefaultDependencyResolver>
         {
        
         }

         [Concern(typeof(DefaultDependencyResolver))]
         public class when_resolving_a_dependency : concern
         {
             context c = () =>
             {
                 test_dependencies = when_resolving_a_dependency
             };

             after_the_sut_has_been_created ac = () =>
             {
                 sut.register_dependency<TestDependency>(() => new TestResolution());
             };

             because b = () =>
             {
                 Console.WriteLine("Before return: " + result);
                 result = sut.resolve_dependency<TestDependency, TestResolution>();
                 Console.WriteLine("Return: " + result);
             };

        
             it should_resolve_to_registered_dependency_resolution = () =>
             {
                 result.should_be_an_instance_of<TestResolution>();               
             };

             static Dictionary<Type, Func<object>> test_dependencies;
             static TestResolution result;
         }

         public interface TestDependency
         {
             
         } 

         public class TestResolution
         {
             
         }
     }
 }
