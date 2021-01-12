using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var authors = RepositoryAuthor.GetAllAuthors ();

            ViewBag.Authors = authors;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorBLL authorBLL)
        {
            var isExist = isAuthorExist(authorBLL.Name);

            if(isExist)
            {
                TempData["Error"] = "Author already exist!";

                return View("Create");

            }
            else
            {
                var result = RepositoryAuthor.AddAuthor(authorBLL);

                if (result)
                {
                    TempData["Success"] = "Category added successfully!";

                    return RedirectToAction("Index");
                }

                TempData["Error"] = "Failed to add Facility. Please try again!";

                return View();
            }
         
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            var author = RepositoryAuthor.GetSingleAuthor(Id);
            return View(author);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, AuthorBLL  authorBLL)
        {
            var results = RepositoryAuthor .EditAuthor(id, authorBLL);
            if (results)
            {
                TempData["Success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }
            return View(authorBLL);
        }

        [NonAction]
        public bool isAuthorExist(string Name)
        {
            var get_Author = RepositoryAuthor.GetAllAuthors().Where(x => x.Name == Name).FirstOrDefault();

            return get_Author != null;
        }

    }

}