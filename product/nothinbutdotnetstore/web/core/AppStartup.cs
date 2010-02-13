using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.utility.container;

namespace nothinbutdotnetstore.web.core
{
    public class AppStartup
    {
        public void start()
        {
            var dependencies = new Dictionary<Type, ItemResolver>();
            var resolver = new DefaultDependencyResolver(dependencies);

            DependencyContainer.resolver = () => resolver;

            typeof (DefaultFrontController).Assembly.GetTypes()
                .Where(x => x.has_attribute<RegisterAttribute>())
                .each(type_to_register => dependencies.Add(type_to_register, new AutoWiringResolver(type_to_register, resolver, new GreediestConstructor())));
        }
    }
}