using System;
using System.Collections.Generic;
using System.Globalization;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationCommand
    {
        Repository repository;
        ReponseEngine response_engine;

        public ViewSubDepartments():this(new StubRepository(),new StubResponseEngine())
        {
        }

        public ViewSubDepartments(Repository repository, ReponseEngine response_engine)
        {
            this.repository = repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            int id;
            int.TryParse(request.item("department_id").ToString(), out id);
            Department main_department = repository.get_main_department(id);
            IEnumerable<SubDepartment> all_sub_departments_for = repository.get_all_sub_departments_for(main_department);
            response_engine.handle((all_sub_departments_for));

        }
    }
}