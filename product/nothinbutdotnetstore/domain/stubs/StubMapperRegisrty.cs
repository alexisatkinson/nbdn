using System;
using nothinbutdotnetstore.utility;

namespace nothinbutdotnetstore.domain.stubs
{
    public class StubMapperRegisrty:MapperRegistry
    {
        public Mapper<Input, Output> get_mapper_for<Input, Output>()
        {
            throw new NotImplementedException();
        }
    }
}