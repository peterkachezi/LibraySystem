using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult PieChart()
        {
            StudentsEntities entities = new StudentsEntities();

            return Json(entities.t_Country.ToList(), JsonRequestBehavior.AllowGet);
        }


    }
}