using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software.Controllers
{
    public class StreamController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var classes = RepositoryStream.GetAllStreams();

            ViewBag.Classes = classes;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StreamBLL studentClassBLL)
        {
            
            var result = RepositoryStream.AddStream(studentClassBLL);
            if (result)
            {
                TempData["Success"] = "Category added successfully!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add Facility. Please try again!";

            return View();
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            var category = RepositoryStream.GetSingleStream(Id);
            return View(category);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, StreamBLL studentClassBLL)
        {
            var results = RepositoryStream.EditClass(id, studentClassBLL);
            if (results)
            {
                TempData["Success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }
            return View(studentClassBLL);
        }



    }


}