﻿using System.Web;
using nothinbutdotnetstore.web.core.stubs;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        FrontController front_controller;
        RequestFactory request_factory;

<<<<<<< HEAD
        public RawHandler() : this(new DefaultFrontController(), new StubRequestFactory())
        {

            
        }
=======
        //public RawHandler() : this(new DefaultFrontController( new), new StubRequestFactory())
        //{

        //}

>>>>>>> 8ab83c9e261c9acf30f99191ec43e63b9a4e6d6c

        public RawHandler(FrontController front_controller, RequestFactory request_factory)
        {
            
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.handle(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}