using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software.Controllers
{
    public class VendorController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var vendors = RepositoryVendor.GetAllVendors();

            ViewBag.Vendors = vendors;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VendorBLL vendorBLL)
        {
            
            var result = RepositoryVendor .AddVendor(vendorBLL);
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
            var vendor = RepositoryVendor.GetSingleVendor(Id);
            return View(vendor);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, VendorBLL vendorBLL)
        {
            var results = RepositoryVendor .EditVendor(id, vendorBLL);
            if (results)
            {
                TempData["Success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }
            return View(vendorBLL);
        }






    }


}