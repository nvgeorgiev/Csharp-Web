using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index() 
        {
            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}
