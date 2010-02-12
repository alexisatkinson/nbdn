using System;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        ItemToMap map<ItemToMap>(Func<Request, ItemToMap> mapper);
        ItemToMap map<ItemToMap>() where ItemToMap : new();
    }

    public class DefaultRequest : Request
    {
        public ItemToMap map<ItemToMap>(Func<Request, ItemToMap> mapper)
        {
            return mapper(this);
        }

        public ItemToMap map<ItemToMap>() where ItemToMap : new()
        {
            return new ItemToMap();
        }
    }
}