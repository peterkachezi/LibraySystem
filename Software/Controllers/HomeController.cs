using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class HomeController : Controller
    {
        StudentsEntities db = new StudentsEntities();
   
        public ActionResult Index()
        {
            ViewBag.Count = RepositoryRegisterBook.GetAllBooks().Count;

            var midnight = DateTime.Today;

            ViewBag.IssuedBooks = RepositoryIssueBook.IssuedBooks().Where(x => x.IssuedDate >= midnight).ToList().Count;

            ViewBag.ReturnedBooks = RepositoryReturnedBook.GetAllReturnedBooks().Where(x => x.ReturnedDate >= midnight).ToList().Count;

            ViewBag.Authors = RepositoryAuthor.GetAllAuthors().Count;

            ViewBag.LostBooks = RepositoryLostBook.GetAllLostBooks().Where(x => x.DateReported >= midnight).ToList().Count;

            ViewBag.Publishers = RepositoryPublisher.GetAllPublishers().Count;

            return View();
        }


    }
}