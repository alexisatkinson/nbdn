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
     public class ViewSubDepartmentSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand, ViewSubDepartments>
         {
        
         }

         [Concern(typeof(ViewSubDepartments))]
         public class when_run : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 repository = the_dependency<Repository>();
                 response_engine = the_dependency<ResponseEngine>();

                 sub_departments = new List<Department>();

                 department = an<Department>();

                 request.Stub(x => x.map<Department>()).Return(department);
                 repository.Stub(x => x.get_all_sub_departments_for(department)).Return(sub_departments);
             };

             because b = () =>
             {
                 sut.process(request);
             };

             it should_tell_the_response_engine_to_display_the_sub_departments = () =>
             {
                 response_engine.received(x => x.display(sub_departments));
             };

             static Repository repository;
             static Request request;
             static ResponseEngine response_engine;
             static IEnumerable<Department> sub_departments;
             static Department department;
         }
     }
 }
