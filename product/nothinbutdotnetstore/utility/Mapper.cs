namespace nothinbutdotnetstore.utility
{
    public interface Mapper<Input, Output>
    {
        Output map_from(Input input);
    }
}