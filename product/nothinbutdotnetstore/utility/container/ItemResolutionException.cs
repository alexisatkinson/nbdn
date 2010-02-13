using System;

namespace nothinbutdotnetstore.utility.container
{
    public class ItemResolutionException : Exception
    {
        public Type type_that_could_not_be_resolved { get; private set; }

        public ItemResolutionException(Type type_that_could_not_be_resolved, Exception inner_exception):base(string.Empty,inner_exception)
        {
            this.type_that_could_not_be_resolved = type_that_could_not_be_resolved;
        }
    }
}