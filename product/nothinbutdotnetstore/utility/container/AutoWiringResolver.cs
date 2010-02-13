using System;
using System.Linq;

namespace nothinbutdotnetstore.utility.container
{
    public class AutoWiringResolver : ItemResolver
    {
        Type item_to_resolve;
        ConstructorSelectionStrategy constructor_selection_strategy;
        DependencyResolver dependency_resolver;

        public AutoWiringResolver(Type item_to_resolve, DependencyResolver dependency_resolver, ConstructorSelectionStrategy constructor_selection_strategy)
        {
            this.item_to_resolve = item_to_resolve;
            this.constructor_selection_strategy = constructor_selection_strategy;
            this.dependency_resolver = dependency_resolver;
        }

        public object resolve()
        {
            var constructor = constructor_selection_strategy.get_appropriate_constructor_for(item_to_resolve);
            var parameters =
                constructor.GetParameters().Select(x => x.ParameterType).Select(dependency_to_resolve => dependency_resolver.an(dependency_to_resolve));
            return constructor.Invoke(parameters.ToArray());
        }
    }
}