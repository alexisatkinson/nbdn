using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RoutedCommand> commands;


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