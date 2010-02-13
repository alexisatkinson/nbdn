using System;

namespace nothinbutdotnetstore.utility.container
{
    public interface DependencyResolver
    {
        Contract an<Contract>();
        object an(Type contract);
    }
}