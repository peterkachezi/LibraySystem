using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            var publishers = RepositoryPublisher.GetAllPublishers();

            ViewBag.Publishers = publishers;
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PublisherBLL publisherBLL)
        {

            var result = RepositoryPublisher.AddPublisher(publisherBLL);
            if (result)
            {
                TempData["Success"] = "Publisher added successfully!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add Facility. Please try again!";

            return View();
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            var publisher = RepositoryPublisher.GetSinglePublisher(Id);
            return View(publisher);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, PublisherBLL publisherBLL)
        {
            var results = RepositoryPublisher.EditPublisher(id, publisherBLL);
            if (results)
            {
                TempData["Success"] = "Publisher updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update Publisher. Please try again!";
            }
            return View(publisherBLL);
        }























    }
}