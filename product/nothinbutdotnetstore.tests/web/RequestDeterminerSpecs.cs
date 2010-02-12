using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestDeterminerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RequestDeterminer,
                                            DefaultRequestDeterminer>
        {
        }

        [Concern(typeof (DefaultRequestDeterminer))]
        public class when_the_request_is_valid_for_the_command_type : concern
        {
            context c = () =>
            {

                var mappings = new Dictionary<string, Type>();
                
                request = an<Request>();

                mappings.Add("/DummyType.store", typeof(DummyType));
                request.Stub(x => x.id).Return("/DummyType.store");

                provide_a_basic_sut_constructor_argument(request);
                provide_a_basic_sut_constructor_argument<IDictionary<string, Type>>(mappings);
            };

            because b = () =>
            {
                result = sut.Result<DummyType>();
            };


            it should_evalutate_to_true = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static Request request;

            public class DummyType
            {
            }
     
        }


    }
}