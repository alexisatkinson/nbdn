using System;
using System.Collections.Generic;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        ItemToMap map<ItemToMap>();
        string id { get; }
        IDictionary<string, object> payload { get; }
    }

    public class DefaultRequest : Request
    {
        MapperRegistry mapper_registry;

        public DefaultRequest(MapperRegistry mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public ItemToMap map<ItemToMap>()
        {
            return mapper_registry.get_mapper_for<Request, ItemToMap>().map_from(this);
        }

        public IDictionary<string, object> payload
        {
            get { throw new NotImplementedException(); }
        }

        public string id
        {
            get { return "/views/ViewMainDepartments.store"; }
			}
        public TypeOfValue get_value<TypeOfValue>(string keyName)
        {
            throw new NotImplementedException();
        }

    }
}