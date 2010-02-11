using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class CommandSpec
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Command,
                                             DefaultCommand>
         {
        
         }

         [Concern(typeof(Command))]
         public class should_be_able_to_process_request : concern
         {
             context c = () =>
             {
                 request = an<Request>();
             };

             because b = () =>
             {
                 sut.process(request);
             };

        
             it processes_the_request = () =>
             {
                 request.receive();
            
            
             };

             protected static Request request;
             protected static Command command;

         }
     }
 }
