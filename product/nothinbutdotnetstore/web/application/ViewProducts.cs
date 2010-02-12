using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProducts : ApplicationCommand
    {
        Repository repository;
        ResponseEngine response_engine;

        public ViewProducts() : this(new StubRepository(), new StubResponseEngine())
        {
        }

        public ViewProducts(Repository repository, ResponseEngine response_engine)
        {
            this.repository = repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.handle(repository.get_all_products_in(request.map<Department>()));
        }
    }
}