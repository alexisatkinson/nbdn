using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.utility.container
{
    public class DefaultDependencyResolver : DependencyResolver
    {
        IDictionary<Type, ItemResolver> dependencies;

        public DefaultDependencyResolver(IDictionary<Type, ItemResolver> dependencies)
        {
            this.dependencies = dependencies;
        }

        public Dependency an<Dependency>()
        {
            return (Dependency) an(typeof (Dependency));
        }

        public object an(Type contract)
        {
            ensure_resolver_is_registered_for(contract);

            try
            {
                return get_resolver_for(contract).resolve();
            }
            catch (Exception e)
            {
                throw new ItemResolutionException(contract,e);
            }
        }

        void ensure_resolver_is_registered_for(Type contract)
        {
            if (dependencies.ContainsKey(contract)) return;

            throw new ItemResolverNotRegisteredException(contract);
        }

        ItemResolver get_resolver_for(Type contract)
        {
            return dependencies[contract];
        }
    }
}