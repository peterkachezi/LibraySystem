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
        // [Authorize]
        public ActionResult Index()
        {
            ViewBag.Count = RepositoryRegisterBook.GetAllBooks().Count;

            ViewBag.IssuedBooks = RepositoryIssueBook.IssuedBooks().Count;

            ViewBag.IssuedBooks = RepositoryIssueBook.IssuedBooks().Count;



            return View();
        }

    }
}