using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class LoaderController : Controller
    {
        // GET: Loader
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }
    }
}