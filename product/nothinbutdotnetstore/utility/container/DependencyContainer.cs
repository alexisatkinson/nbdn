using System;

namespace nothinbutdotnetstore.utility.container
{
    public class DependencyContainer
    {
        public static Func<DependencyResolver> resolver = () =>
        {
            throw new NotImplementedException();
        };

        public static DependencyResolver resolve
        {
            get { return resolver(); }
        }
    }
}