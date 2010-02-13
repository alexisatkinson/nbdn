using System;

namespace nothinbutdotnetstore.web.application
{
    public interface DependencyRegister
    {
        void register_dependency<Contract>(Func<Contract> resolution);
        ResolvedType resolve_dependency<Contract, ResolvedType>();
    }
}