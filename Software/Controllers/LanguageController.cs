using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            var languages = RepositoryLanguage.GetAllLanguages();

            ViewBag.Languages = languages;
            return View();

        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LanguageBLL languageBLL,string LanguageName)
        {

            {
                var NewLanguageName = LanguageName.Substring(0, 1).ToUpper() + LanguageName.Substring(1).ToLower();

                var language = RepositoryLanguage.GetAllLanguages().Where(x => x.LanguageName == NewLanguageName).FirstOrDefault();

                if (language != null)//exist
                {

                    TempData["Error"] = "Language already exist!";

                    return RedirectToAction("Create");

                }
                else if (language == null) //doesnt exist

                {
                    var result = RepositoryLanguage.AddLanguage(languageBLL);

                    if (result)
                    {
                        TempData["Success"] = "Language added successfully!";

                        return RedirectToAction("Index");
                    }

                    TempData["Error"] = "Failed to add Language. Please try again!";

                }
                return View();
            }
        }


        [HttpGet]

        public ActionResult Edit(Guid Id)
        {
            var language = RepositoryLanguage.GetSingleLanguage(Id);

            return View(language);
        }



        [HttpPost]
        public ActionResult Edit(Guid id, LanguageBLL languageBLL)
        {
            var results = RepositoryLanguage.EditLanguage(id, languageBLL);

            if (results)
            {
                TempData["Success"] = "Language updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }

            return View(languageBLL);
        }


     




    }
}