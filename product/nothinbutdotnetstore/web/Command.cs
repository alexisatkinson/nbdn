namespace nothinbutdotnetstore.web
{
    public interface Command 
    {
        void process(Request request);
    }
}