using System;
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
        public class when_observation_name : concern
        {
            context c = () =>
            {
                request = an<Request>();
                request.Stub(x => x.GetValue<string>(RequestParameters.ProductName)).Return(product_name);
            };

            because b = () =>
            {
                result = sut.map_from(request);
            };


            it first_observation = () =>
            {
                result.name.should_be_equal_to(product_name);
            };

            static Request request;
            static Product result;
            static string product_name = "Product Name";
        }
    }

    public class ProductMapper : Mapper<Request, Product>
    {
        public Product map_from(Request input)
        {
            return new Product {name = input.GetValue<string>(RequestParameters.ProductName)};
        }
    }
}