using BLL;
using DAO;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Security.Claims;

namespace Software.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categories = RepositoryCategory.GetAllCategories();

            ViewBag.Categories = categories;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryBLL bookCategoryBLL)
        {



            var result = RepositoryCategory.AddCategory(bookCategoryBLL);
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
            var category = RepositoryCategory.GetSingleCategory(Id);
            return View(category);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, CategoryBLL categoryBLL)
        {
            var results = RepositoryCategory.EditCategory(id, categoryBLL);
            if (results)
            {
                TempData["Success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }
            return View(categoryBLL);
        }






    }


}