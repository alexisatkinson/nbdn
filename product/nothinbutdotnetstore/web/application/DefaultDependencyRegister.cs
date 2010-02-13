using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.application
{
    public class DefaultDependencyRegister : DependencyRegister
    {
        public void register_dependency<Contract>(Func<Contract> resolution)
        {
            throw new NotImplementedException();
        }

        public ResolvedType resolve_dependency<Contract, ResolvedType>()
        {
            throw new NotImplementedException();
        }
    }
}
