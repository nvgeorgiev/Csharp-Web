using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {

        }

        public HttpResponse Register()
        {
            return this.View();
        }
    }
}
