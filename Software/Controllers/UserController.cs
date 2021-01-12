using BLL;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Software.Controllers
{
    public class UserController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            var users = RepositoryUser.GetAllUsers();

            ViewBag.Users = users;
            return View();

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Creates(UserBLL userBLL)
        {

            var isExist = IsEmailExist(userBLL.EmailID);

            if (isExist)
            {
                TempData["Error"] = "Email already exist!";

                return View("Create");
            }
            else
            {
                userBLL.ActivationCode = Guid.NewGuid();

                var result = RepositoryUser.AddUsers(userBLL);

                //  SendVerificationLinkEmail(userBLL.EmailID, userBLL.ActivationCode.ToString());

                if (result)
                {
                    TempData["Success"] = "User account has been successfully created!" + " has been sent to your email id :" + userBLL.EmailID;

                    return RedirectToAction("Index");
                }

            }

            TempData["Error"] = "Failled to add user. Please try again!";
            return View();

        }
        public ActionResult Create(UserBLL userBLL)
        {


            var isExist = IsEmailExist(userBLL.EmailID);

            if (isExist)
            {
                TempData["Error"] = "Email already exist!";

                return View("Create");
            }
            else
            {
                using (StudentsEntities context = new StudentsEntities())
                {
                    try
                    {

                        char[] letters = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ".ToCharArray();
                        Random r = new Random();
                        string randomString = "";
                        for (int i = 0; i < 10; i++)
                        {
                            randomString += letters[r.Next(0, 35)].ToString();
                        }

                        string RandomPassword = randomString.ToString();

                        string db_RandomPassword = HashPassword.Hash(randomString.ToString());

                        userBLL.ActivationCode = Guid.NewGuid();

                        var t_Users = new t_Users
                        {
                            Id = Guid.NewGuid(),

                            FirstName = userBLL.FirstName.Substring(0, 1).ToUpper() + userBLL.FirstName.Substring(1).ToLower(),

                            LastName = userBLL.LastName.Substring(0, 1).ToUpper() + userBLL.LastName.Substring(1).ToLower(),

                            EmailID = userBLL.EmailID.Substring(0, 1).ToLower() + userBLL.EmailID.Substring(1).ToLower(),

                            Password = db_RandomPassword,

                            ActivationCode = userBLL.ActivationCode,

                            CreateDate = DateTime.Now,

                            IsEmailVerified = false,

                            MobileNumber = userBLL.MobileNumber,
                        };

                        context.t_Users.Add(t_Users);

                        context.SaveChanges();

                        SendVerificationLinkEmail(userBLL.EmailID, userBLL.ActivationCode.ToString(), RandomPassword);

                        TempData["Success"] = "User account has been successfully created!" + " has been sent to your email id :" + userBLL.EmailID;

                        return RedirectToAction("Index");

                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return View();
                    }
                    //  return View();
                }

            }

        }
        [NonAction]
        public void SendVerificationLinkEmail(string EmailID, string activationCode, string RandomPassword)

        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;

            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("peterkachezi@gmail.com", "ebook | Library ");

            var toEmail = new MailAddress(EmailID);

            var fromEmailPassword = "2989525829895258";

            string subject = "Your account is successfully created";

            string body = "Dear ebook Library User" +
                                    "<br/>Your abook account has been successfully created " +
                                    "<br/>Please click the link below to activate your account <br/> " + " " + link + " " +

                                    "<br/>User Name: " + " " + EmailID + " " +
                                   "<br/>Password:" + " " + RandomPassword + " ";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",

                Port = 587,

                EnableSsl = true,

                DeliveryMethod = SmtpDeliveryMethod.Network,

                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)

            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,

                Body = body,

                IsBodyHtml = true

            })
                smtp.Send(message);

        }
        [HttpGet]
        public ActionResult Edit(Guid Id)
        {
            var language = RepositoryLanguage.GetSingleLanguage(Id);

            return View(language);
        }
        [HttpPost]
        public ActionResult Edit(Guid id, UserBLL userBLL)
        {
            var results = RepositoryUser.EditUser(id, userBLL);

            if (results)
            {
                TempData["Success"] = "Language updated successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to update facility. Please try again!";
            }

            return View(userBLL);
        }
        [NonAction]
        public bool IsEmailExist(string EmailID)
        {
            var v = RepositoryUser.GetAllUsers().Where(x => x.EmailID == EmailID).FirstOrDefault();

            return v != null;

        }



        [NonAction]
        public void ResendPassword(string EmailID, string RandomPassword)

        {
            //var verifyUrl = "/User/VerifyToken/" + activationCode;

            var Password = RandomPassword;

            var fromEmail = new MailAddress("peterkachezi@gmail.com", "ebook | Library");

            var toEmail = new MailAddress(EmailID);

            var fromEmailPassword = "2989525829895258";

            string subject = "Password Reset Link";

            string body = "Dear ebook Libray User" +
                           "<br/>We have received your request to reset your password" +
                           "<br/>Please use the following details to login " +
                           "<br/>User Name: " + " " + EmailID + " " +
                          "<br/>Password:" + " " + Password + " ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",

                Port = 587,

                EnableSsl = true,

                DeliveryMethod = SmtpDeliveryMethod.Network,

                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)

            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,

                Body = body,

                IsBodyHtml = true

            })
                smtp.Send(message);

        }

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;

            using (StudentsEntities dc = new StudentsEntities())

            {
                dc.Configuration.ValidateOnSaveEnabled = false;

                var v = dc.t_Users.Where(x => x.ActivationCode == new Guid(id)).FirstOrDefault();

                if (v != null)

                {
                    v.IsEmailVerified = true;

                    dc.SaveChanges();

                    Status = true;
                }
                else
                {
                    ViewBag.Status = "Invalid request!";
                    // return RedirectToAction("Index");
                }
                ViewBag.Status = Status;

                return View();
            }
        }



        [HttpGet]
        public ActionResult ForgotPassword()
        {

            return View("");


        }

        [HttpPost]
        public ActionResult ForgotPassword(UserBLL userBLL, string EmailID)
        {
            var isExist = IsEmailExist(userBLL.EmailID);

            if (isExist)
            {

                using (StudentsEntities dc = new StudentsEntities())

                {
                    dc.Configuration.ValidateOnSaveEnabled = false;

                    //userBLL.PasswordResetToken = Guid.NewGuid();create random password

                    char[] letters = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ".ToCharArray();

                    Random r = new Random();

                    string randomString = "";

                    for (int i = 0; i < 10; i++)
                    {
                        randomString += letters[r.Next(0, 35)].ToString();
                    }

                    string RandomPassword = randomString.ToString();

                    string db_RandomPassword = HashPassword.Hash(randomString.ToString());

                    var v = dc.t_Users.Where(x => x.EmailID == EmailID).FirstOrDefault();

                    if (v != null)

                    {
                        v.Password = db_RandomPassword;

                        dc.SaveChanges();

                    }
                    else
                    {
                        ViewBag.Status = "Invalid request!";
                        // return RedirectToAction("Index");
                    }

                    TempData["Success"] = "Your password  " + " has been sent to your email id :" + userBLL.EmailID;

                    ResendPassword(userBLL.EmailID, RandomPassword.ToString());

                    return View("ForgotPassword");
                }
            }

            else
            {
                TempData["Error"] = "Email not exist!";

                return View("ForgotPassword");
            }

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(UserBLL userBLL)
        {

            using (StudentsEntities db = new StudentsEntities())
            {
                var password = userBLL.Password;

                string LoginHashedPassword = HashPassword.Hash(password.ToString());

                var userDetails = db.t_Users.Where(x => x.EmailID == userBLL.EmailID && x.Password == LoginHashedPassword).FirstOrDefault();

                if (userDetails == null)
                {
                    TempData["Error"] = "Wrong usernam or password,please check your inputs";

                    return RedirectToAction("Login", "User");
                }
                else
                {
                    if (!userDetails.IsEmailVerified)
                    {
                        TempData["Info"] = "Your account has not been activated Please login to  " + userBLL.EmailID + " and click on the activation link sent on registration";
                        return RedirectToAction("Login", "User");
                    }

                    else
                    {
                        Session["Id"] = userDetails.Id;

                        Session["FirstName"] = userDetails.FirstName;

                        return RedirectToAction("Index", "Home");

                    }

                }


            }


        }
        public ActionResult Logout()
        {
            Guid id = (Guid)Session["Id"];
            Session.Abandon();
            return RedirectToAction("Login", "User");

        }
    }
}