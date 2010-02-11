namespace nothinbutdotnetstore.web.core
{
    public interface ReponseEngine
    {
        void handle<Item>(Item item);
    }
}