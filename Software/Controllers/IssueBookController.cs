using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class IssueBookController : Controller
    {
        // GET: RegisterBooks
        public ActionResult Index()
        {
            var books = RepositoryRegisterBook.GetAllBooks();

            ViewBag.Books = books;


            return View();
        }

        [HttpGet]
        public ActionResult IssueBook()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult IssueBook(IssueBookBLL issueBookBLL)
        {


            var result = RepositoryIssueBook.ReturnBook(issueBookBLL);
            if (result)
            {
                TempData["Success"] = "Book has been successfully issued!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add book. Please try again!";

            return View("Index");
        }


        [HttpGet]

        public ActionResult GetBook(Guid Id)
        {         
            var book = RepositoryRegisterBook.GetSingleBook(Id);
            return View(book);
        }


        [HttpGet]
        public ActionResult GetStudent(string AdmNo)
        {
            var student = RepositoryIssueBook.GetAllStudent().Where(a => a.AdmNo == AdmNo).FirstOrDefault();

            if (student != null)
            {
                StudentBLL file = new StudentBLL()
                {
                    AdmNo = student.AdmNo,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    MiddleName = student.MiddleName,
                    Id = student.Id
                };

                return new JsonResult() { Data = file, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult Student()
        {
            return View();
        }




    }
}
