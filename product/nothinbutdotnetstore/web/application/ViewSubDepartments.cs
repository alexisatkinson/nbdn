using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartments : ApplicationCommand
    {
        Repository repository;
        ResponseEngine response_engine;

        public ViewSubDepartments() : this(new StubRepository(), new StubResponseEngine())
        {
        }

        public ViewSubDepartments(Repository repository, ResponseEngine response_engine)
        {
            this.repository = repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(repository.get_all_sub_departments_for(request.map<Department>()));
        }
    }
}