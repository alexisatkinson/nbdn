 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class CommandRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry, DefaultCommandRegistry>
         {
        
         }

         [Concern(typeof(DefaultCommandRegistry))]
         public class when_getting_a_command_that_can_process_a_request_and_it_has_the_command : concern
         {
             context c = () =>
             {
                 commandCollection = new List<Command>();
                 command_being_returned = an<Command>();

                 commandCollection.Add(command_being_returned);
             };

             because b = () =>
             {
                 sut.get_command_that_can_process_the_request();
             };

        
             it should_return_the_command_that_can_do_the_processing = () =>
                {
                   sut.get_command_that_can_process_the_request().should_be_equal_to(command_being_returned);
                };


             static Command command_being_returned;
             static List<Command> commandCollection;
         }
     }
 }
