using BLL;
using DAO;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Software.Controllers
{
    public class MemberController : Controller
    {
 

        // GET: Category
        public ActionResult Index()
        {
            var members = RepositoryMember.GetAllMembers();

            ViewBag.Members = members;


            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

     

        [HttpPost]
        public ActionResult Create(MemberBLL memberBLL)
        {

            var isExist = IsMemberExist(memberBLL.MobileNumber);

            if (isExist)
            {
                TempData["Error"] = "Member already exist!";

                return View("Create");
            }
            else
            {
                var result = RepositoryMember.AddMember(memberBLL);

            if (result)
            {
                TempData["Success"] = "Member added successfully!";

                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to add Member. Please try again!";

            return View();
            }
            
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            var member = RepositoryMember.GetSingleMember(Id);
            return View(member);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, MemberBLL memberBLL)
        {
            var results = RepositoryMember.EditMember(id, memberBLL);
            if (results)
            {
                TempData["Success"] = "Member updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update Member. Please try again!";
            }
            return View(memberBLL);
        }

        [NonAction]
        public bool IsMemberExist(string MobileNumber)
        {
            var get_member = RepositoryMember.GetAllMembers().Where(x => x.MobileNumber == MobileNumber).FirstOrDefault();

            return get_member != null;

        }


    }


}