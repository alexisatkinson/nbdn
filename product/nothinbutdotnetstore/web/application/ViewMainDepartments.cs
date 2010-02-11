using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationCommand
    {
        Repository repository;
        ReponseEngine reponse_engine;

        public ViewMainDepartments():this(new StubRepository(),new StubResponseEngine())
        {
        }

        public ViewMainDepartments(Repository repository, ReponseEngine reponse_engine)
        {
            this.repository = repository;
            this.reponse_engine = reponse_engine;
        }

        public void process(Request request)
        {
            reponse_engine.handle(repository.get_all_main_departments());
        }
    }
}