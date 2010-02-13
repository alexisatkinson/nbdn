using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ProductMapperSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Mapper<Request, Product>, ProductMapper>
        {
        }

        [Concern(typeof (ProductMapper))]
        public class when_mapping_from_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                original = new Product {name = "blah"};
                payload = new Dictionary<string, object>();
                payload.Add(ReflectionUtility.get_name_of_property<Product>(x => x.name), original.name);
                request.Stub(x => x.payload).Return(payload);
            };

            because b = () =>
            {
                result = sut.map_from(request);
            };


            it should_map_and_populate_correctly = () =>
            {
                result.name.should_be_equal_to(original.name);
            };

            static Request request;
            static Product result;
            static Product original;
            static Dictionary<string, object> payload;
        }
    }

    public class ProductMapper : Mapper<Request, Product>
    {
        public Product map_from(Request input)
        {
            return new Product {name = input.payload[ReflectionUtility.get_name_of_property<Product>(x => x.name)].ToString()};
        }
    }
}