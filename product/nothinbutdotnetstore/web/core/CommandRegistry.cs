namespace nothinbutdotnetstore.web.core
{
    public interface CommandRegistry
    {
        RoutedCommand get_command_that_can_process_the_request(Request request);
    }
}