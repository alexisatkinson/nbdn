using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface DependencyResolver
    {
        void register_dependency<Contract>(Func<object> actionToPerform);
        ReturnType resolve_dependency<Contract,ReturnType>();
    }

    public class DefaultDependencyResolver : DependencyResolver
    {
        Dictionary<Type, Func<object>> dependancy_actions = new Dictionary<Type, Func<object>>();

        public DefaultDependencyResolver( Dictionary<Type, Func<object>> dependancy_actions)
        {
            this.dependancy_actions = dependancy_actions;
        }

        public void register_dependency<Contract>(Func<object> actionToPerform)
        {
            dependancy_actions.Add(typeof(Contract), actionToPerform);
        }

        public ReturnType resolve_dependency<Contract,ReturnType>()
        {
            Func<object> output_accessor;

            if (dependancy_actions.TryGetValue(typeof (Contract), out output_accessor))
            {
                return (ReturnType) output_accessor();
            }else
            {
                throw new Exception("No dependency found!");
            }
        }
    }
}