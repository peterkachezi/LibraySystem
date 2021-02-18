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
        public ActionResult Option()
        {

            return View();
        }

        [HttpGet]
        public ActionResult IssueStudent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IssueBook(Guid id, IssueBookBLL issueBookBLL)
        {
            var result = RepositoryIssueBook.IssueBook(issueBookBLL);

            var get_book = RepositoryIssueBook.GetAllBooks().Where(a => a.Id == id).FirstOrDefault();

            RegisterBookBLL file = new RegisterBookBLL()
            {
                Id = get_book.Id,

                Copies = get_book.Copies,
            };

            int CurrentCopies = int.Parse(file.Copies);

            int IssuedCopies = int.Parse(issueBookBLL.IssuedCopies);

            var RemainingCopies = CurrentCopies - IssuedCopies;

            var update_stock = RepositoryIssueBook.UpdateStock(id, issueBookBLL);


            if (result)
            {
                TempData["Success"] = "Book has been successfully issued!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add book. Please try again!";

            return View("Index");
        }


        [HttpGet]

        public ActionResult GetIssueDetails(Guid Id)
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
        public ActionResult GetBorrower(string MembershipNo)
        {
            var student = RepositoryIssueBook.GetAllStudent().Where(a => a.AdmNo == MembershipNo).FirstOrDefault();

            if (student != null)
            {
                StudentBLL file = new StudentBLL()
                {
                    AdmNo = student.AdmNo,

                    Name = student.FirstName + " " + student.LastName,

                    Id = student.Id
                };

                return new JsonResult() { Data = file, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            else
            {
                var member = RepositoryMember.GetAllMembers().Where(a => a.MembershipNo == MembershipNo).FirstOrDefault();

                if (member != null)
                {
                    MemberBLL file = new MemberBLL()
                    {
                        MembershipNo = member.MembershipNo,

                        Name = member.Name,

                        Id = member.Id
                    };

                    return new JsonResult() { Data = file, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

                return new JsonResult() { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


            }





        }
    }
}
