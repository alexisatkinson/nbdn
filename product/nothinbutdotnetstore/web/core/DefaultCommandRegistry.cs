namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        public Command get_command_that_can_process(Request request)
        {
            return new DefaultCommand();
        }
    }
}