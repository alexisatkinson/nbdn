namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine
    {
        void handle<Item>(Item item);
    }
}