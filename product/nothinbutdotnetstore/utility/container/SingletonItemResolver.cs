namespace nothinbutdotnetstore.utility.container
{
    public class SingletonItemResolver : ItemResolver
    {
        ItemResolver original_resolver;
        object cached_value;

        public SingletonItemResolver(ItemResolver original_resolver)
        {
            this.original_resolver = original_resolver;
        }

        public object resolve()
        {
            return cached_value ?? (cached_value = original_resolver.resolve());
        }
    }
}