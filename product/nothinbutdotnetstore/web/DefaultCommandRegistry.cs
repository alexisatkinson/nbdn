using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        public Command get_command_that_can_process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}