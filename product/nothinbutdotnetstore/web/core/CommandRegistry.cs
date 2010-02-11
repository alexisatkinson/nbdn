namespace nothinbutdotnetstore.web.core
{
    public interface CommandRegistry
    {
        Command get_command_that_can_process_the_request(Request request);
    }
}