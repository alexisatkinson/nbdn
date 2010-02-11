using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IList<Command> command_collection;
        readonly Request request;
        string script_name;

        public DefaultCommandRegistry(IList<Command> commandCollection, Request request)
        {
            command_collection = commandCollection;
            this.request = request;
        }

        public Command get_command_that_can_process_the_request()
        {
            script_name = request.script_name;
            return command_collection.First(x => x.script_name == script_name);
        }

        //public Command parse_request_to_get_command(Request request)
        //{
        //    // RequestParser => to decouple command from actually finding the request
        //    // Find the request by script name or something like that
        //    return command_collection[0];
        //}
    }
}