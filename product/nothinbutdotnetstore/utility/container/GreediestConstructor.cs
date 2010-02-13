using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.utility.container
{
    public class GreediestConstructor : ConstructorSelectionStrategy
    {
        public ConstructorInfo get_appropriate_constructor_for(Type type)
        {
            return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
        }
    }
}