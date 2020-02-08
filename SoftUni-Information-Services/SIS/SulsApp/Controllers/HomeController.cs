namespace SulsApp.Controllers
{
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
