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
            var books = RepositoryRegisterBook.GetAllBooks();

            ViewBag.Books = books;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            //get languages and publishers to dropdown
            var languages = RepositoryLanguage.GetAllLanguages();
            ViewBag.Languages = languages;

            var publishers = RepositoryPublisher.GetAllPublishers();
            ViewBag.Publishers = publishers;

            var categories = RepositoryCategory.GetAllCategories();
            ViewBag.Categories = categories;

            // end
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterBookBLL registerBookBLL)
        {
        

            var result = RepositoryRegisterBook.AddBook(registerBookBLL);
            if (result)
            {
                TempData["Success"] = "Book added successfully!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add book. Please try again!";

            return View();
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            //get languages and publishers to dropdown
            var languages = RepositoryLanguage.GetAllLanguages();
            ViewBag.Languages = languages;

            var publishers = RepositoryPublisher.GetAllPublishers();
            ViewBag.Publishers = publishers;


            var categories = RepositoryCategory.GetAllCategories();
            ViewBag.Categories = categories;

            // end



            var book = RepositoryRegisterBook.GetSingleBook(Id);
            return View(book);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, RegisterBookBLL registerBookBLL)
        {
            var results = RepositoryRegisterBook.EditBook(id, registerBookBLL);
            if (results)
            {
                TempData["Success"] = "Book updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update Book. Please try again!";
            }
            return View(registerBookBLL);
        }
    }
}