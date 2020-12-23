using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class StudentController : Controller
    {
        // GET: RegisterBooks
        public ActionResult Index()
        {
            var students = RepositoryStudent .GetAllStudent();

            ViewBag.Students = students;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            //get languages and publishers to dropdown
            var streams = RepositoryStream.GetAllStreams();
            ViewBag.Streams = streams;

      

            // end
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentBLL studentBLL)
        {
        

            var result = RepositoryStudent.AddStudent(studentBLL);
            if (result)
            {
                TempData["Success"] = "Atudent added successfully!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add book. Please try again!";

            return View();
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            //get languages and publishers to dropdown
            var streams = RepositoryStream.GetAllStreams();
            ViewBag.Streams = streams;
                        // end



            var book = RepositoryStudent.GetSingleStudent(Id);
            return View(book);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, StudentBLL studentBLL)
        {
            var results = RepositoryStudent.EditStudent(id, studentBLL);
            if (results)
            {
                TempData["Success"] = "Book updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update Book. Please try again!";
            }
            return View(studentBLL);
        }
    }
}