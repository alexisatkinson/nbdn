using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest:Request
    {
        IDictionary<System.Type, object> mappings;

        public DefaultRequest(IDictionary<Type, object> mappings)
        {
            this.mappings = mappings;
        }

        public ItemToMap map<ItemToMap>()
        {
            return (ItemToMap) mappings[typeof (ItemToMap)];
        }
    }
}