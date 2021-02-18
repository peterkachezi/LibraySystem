using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software.Controllers
{
    public class LocationController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var locations = RepositoryLocation .GetAllLocation();

            ViewBag.Locations = locations;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LocationBLL  locationBLL)
        {
            var isExist = isLocationExist(locationBLL.Name);

            if (isExist)
            {
                TempData["Error"] = "Location already exist!";

                return View("Create");
            }
            else
            {
                var result = RepositoryLocation.AddLocation(locationBLL);

                if (result)
                {
                    TempData["Success"] = "Location added successfully!";

                    return RedirectToAction("Index");
                }

                TempData["Error"] = "Failed to add Location. Please try again!";

                return View();
            }
          
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            var location = RepositoryLocation .GetSingleLocation (Id);

            return View(location);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, LocationBLL  locationBLL)
        {
            var isExist = isLocationExist(locationBLL.Name);
            if (isExist)
            {
                TempData["Info"] = "No record has been affected";
                return RedirectToAction("Index");
            }


            var results = RepositoryLocation .EditLocation (id, locationBLL);

            if (results)
            {
                TempData["Success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }
            return View(locationBLL);
        }

        [NonAction]

        public bool isLocationExist(string Name)
        {
            var get_Location = RepositoryLocation.GetAllLocation().Where(x => x.Name == Name).FirstOrDefault();

           return get_Location != null;
        }



    }


}