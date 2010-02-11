using System.Collections.Generic;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProducts : ApplicationCommand
    {
        Repository repository;
        ReponseEngine response_engine;

        public ViewProducts():this(new StubRepository(),new StubResponseEngine())
        {
        }

        public ViewProducts(Repository repository, ReponseEngine response_engine)
        {
            this.repository = repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {


        }
    }
}