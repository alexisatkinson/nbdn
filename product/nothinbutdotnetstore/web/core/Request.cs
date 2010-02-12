using System;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        ItemToMap map<ItemToMap>();
        string id { get; }
        TypeOfValue GetValue<TypeOfValue>(string keyName);
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

        public string id
        {
            get { return "/views/ViewMainDepartments.store"; }
			}
        public TypeOfValue GetValue<TypeOfValue>(string keyName)
        {
            throw new NotImplementedException();
        }

    }

    public class RequestParameters
    {
        public const string DepartmentName = "DepartmentName";
        public const string ProductName = "ProductName";
    }
}