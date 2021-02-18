using BLL;
using DAO;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Security.Claims;
using System.Linq;

namespace Software.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var employees = RepositoryEmployee.GetAllEmployees();

            ViewBag.Employees = employees;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeBLL  employeeBLL)
        {
            //var isExist = isCategoryExist(employeeBLL.MobileNumber);

            //if (isExist)
            //{
            //    TempData["Error"] = "Category already exist!";

            //    return View("Create");
            //}
            //else
            //{
                var result = RepositoryEmployee.AddEmployee(employeeBLL);
                if (result)
                {
                    TempData["Success"] = "Category added successfully!";

                //return RedirectToAction("Employee/Index");
                return new JsonResult() { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }

            TempData["Error"] = "Failed to add category. Please try again!";
            return new JsonResult() { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


          //  return View();
            //}

       
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


        [NonAction]
        public bool isCategoryExist(string FirstName)
        {
            var get_category = RepositoryEmployee.GetAllEmployees().Where(x => x.FirstName == FirstName).FirstOrDefault();

            return get_category != null;
        }




    }


}