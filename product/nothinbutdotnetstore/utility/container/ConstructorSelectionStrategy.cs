using System;
using System.Reflection;

namespace nothinbutdotnetstore.utility.container
{
    public interface ConstructorSelectionStrategy
    {
        ConstructorInfo get_appropriate_constructor_for(Type type);
    }
}