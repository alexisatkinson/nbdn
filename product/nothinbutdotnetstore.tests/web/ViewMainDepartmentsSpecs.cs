using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                            ViewMainDepartments>
        {
        }

        [Concern(typeof (ViewMainDepartments))]
        public class when_run : concern
        {
            context c = () =>
            {
                request = an<Request>();
                repository = the_dependency<Repository>();
                response_engine = the_dependency<ReponseEngine>();

                departments = new List<Department>();

                repository.Stub(x => x.get_all_main_departments()).Return(departments);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_get_the_list_of_main_departments = () =>
            {
            };

            it should_tell_the_response_engine_to_display_the_departments = () =>
            {
                response_engine.received(x => x.handle(departments));
            };

            static Repository repository;
            static Request request;
            static ReponseEngine response_engine;
            static IEnumerable<Department> departments;
        }
    }
}