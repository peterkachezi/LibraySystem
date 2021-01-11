using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software.Controllers
{
    public class LostBookController : Controller
    {

        // GET: Category
        public ActionResult Index()
        {

            var lostBooks = RepositoryLostBook.GetAllLostBooks();

            ViewBag.LostBooks = lostBooks;

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LostBookBLL lostBookBLL)
        {
        
            var result = RepositoryLostBook.LostBook(lostBookBLL);
            if (result)
            {
                TempData["Success"] = "Category added successfully!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add Facility. Please try again!";

            return View();
        }


        [HttpGet]

        public ActionResult View(Guid Id)
        {
            var category = RepositoryIssueBook.GetSingleIssuedBook(Id);
            return View(category);
        }



        [HttpPost]
        public ActionResult View(Guid id, IssueBookBLL issueBookBLL)
        {
            var results = RepositoryIssueBook.CancelIssuedBook(id, issueBookBLL);
            if (results)
            {
                TempData["Success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }
            return View(issueBookBLL);
        }




        [HttpGet]
        public ActionResult GetBook(string BookNo)
        {
            var student = RepositoryIssueBook.IssuedBooks().Where(a => a.BookNo == BookNo).FirstOrDefault();

            if (student != null)
            {
                IssueBookBLL file = new IssueBookBLL()
                {
                    BookNo = student.BookNo,
                    IssuedCopies = student.IssuedCopies,
                    Title = student.Title,
                    ISBN_No = student.ISBN_No,
                    BorrowerName = student.BorrowerName,
                    BorrowerId = student.BorrowerId,
                    BookId = student.BookId,

                };

                return new JsonResult() { Data = file, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            return new JsonResult() { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public ActionResult ReturnBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReturnBook(ReturnBookBLL returnBookBLL)
        {

            var result = RepositoryReturnBook.ReturnBook(returnBookBLL);
            if (result)
            {
                TempData["Success"] = "Category added successfully!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add Facility. Please try again!";

            return View();
        }

        public ActionResult ReturnedBook()
        {

            var returnedBooks = RepositoryReturnBook.GetAllReturnedBooks();

            ViewBag.ReturnedBooks = returnedBooks;

            return View();
        }

    }


}