using System;

namespace nothinbutdotnetstore.utility.container
{
    public class ItemResolverNotRegisteredException :Exception
    {
        public Type type_that_could_not_be_resolved { get; private set; }

        public ItemResolverNotRegisteredException(Type type_that_could_not_be_resolved)
        {
            this.type_that_could_not_be_resolved = type_that_could_not_be_resolved;
        }
    }
}