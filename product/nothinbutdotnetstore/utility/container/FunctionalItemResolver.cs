using System;

namespace nothinbutdotnetstore.utility.container
{
    public class FunctionalItemResolver : ItemResolver
    {
        Func<object> factory;

        public FunctionalItemResolver(Func<object> factory)
        {
            this.factory = factory;
        }

        public object resolve()
        {
            return factory();
        }
    }
}