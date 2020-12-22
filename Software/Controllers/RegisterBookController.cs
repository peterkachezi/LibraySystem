using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class RegisterBookController : Controller
    {
        // GET: RegisterBooks
        public ActionResult Index()
        {
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
            var book = RepositoryRegisterBook.GetSingleBook(Id);
            return View(book);
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