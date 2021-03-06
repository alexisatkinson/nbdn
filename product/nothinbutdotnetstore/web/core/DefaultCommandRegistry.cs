using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RoutedCommand> commands;

        public DefaultCommandRegistry():this(create_basic_set())
        {
        }

        static IEnumerable<RoutedCommand> create_basic_set()
        {
            // predicate x => new DefaultRequestDeterminer(x).Result<ViewMainDepartments>()
            // type ViewMainDepartments

            // predicate x => x => new DefaultRequestDeterminer(x).Result<ViewSubDepartments>()
            // type ViewSubDepartments

            // predicate x => new DefaultRequestDeterminer(x).Result<ViewProducts>(), new ViewProducts()));
            // type ViewProducts

            yield return new ViewMainDepartments()


            yield return (new DefaultRoutedCommand(x => new DefaultRequestDeterminer(x).Result<ViewMainDepartments>(), new ViewMainDepartments()));
            yield return (new DefaultRoutedCommand(x => new DefaultRequestDeterminer(x).Result<ViewSubDepartments>(), new ViewSubDepartments()));
            yield return (new DefaultRoutedCommand(x => new DefaultRequestDeterminer(x).Result<ViewProducts>(), new ViewProducts()));
        }

        static IEnumerable<RoutedCommand> generate_commands()
        {
            throw new NotImplementedException();
        }

        public DefaultCommandRegistry(IEnumerable<RoutedCommand> commands)
        {
            this.commands = commands;
        }


        public RoutedCommand get_command_that_can_process_the_request(Request request)
        {
            return commands.FirstOrDefault(x => x.can_handle(request)) ?? new MissingRoutedCommandForRequest();
        }
    }
}