namespace nothinbutdotnetstore.web.core
{
    public interface RoutedCommand : ApplicationCommand
    {
        bool can_handle(Request request);
    }
}