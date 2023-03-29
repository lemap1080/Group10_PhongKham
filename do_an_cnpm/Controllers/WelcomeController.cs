using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace do_an_cnpm.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Welcome()
        {
            return View();
        }
    }
}