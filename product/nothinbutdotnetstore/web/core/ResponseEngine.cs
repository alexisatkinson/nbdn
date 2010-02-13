namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine
    {
        void display<Item>(Item item);
    }
}