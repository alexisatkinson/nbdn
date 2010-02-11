using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<Command> commands;

        public DefaultCommandRegistry(IEnumerable<Command> commands)
        {
            this.commands = commands;
        }


        public Command get_command_that_can_process_the_request(Request request)
        {
            return commands.FirstOrDefault(x => x.can_handle(request)) ?? new MissingCommandForRequest();
        }
    }
}