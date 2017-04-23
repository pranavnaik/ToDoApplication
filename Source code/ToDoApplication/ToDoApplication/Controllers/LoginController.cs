using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoApplication.Dal;
using ToDoApplication.Models;

namespace ToDoApplication.Controllers
{
    public class LoginController : Controller
    {
        private DbDal db = new DbDal();

        // Get Method
        public ActionResult Index()
        {
            return View();
        }

        // Post Method
        [HttpPost]
        public ActionResult Index(User u)
        {
            var check = db.users.Where(m => m.UserName == u.UserName && m.Password == u.Password).FirstOrDefault();//Check if user exists in db
            if(check==null)
            {
                ViewBag.InvalidLogIn = "Invalid username or password..";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie("Cookie", true); //Set cookie for form authentication 
                Session["UserName"] = u.UserName;
                return RedirectToAction("Index", "Tasks", null);

            }
           
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterUser(User u)
        {
            string temp = Request.Form["RePassword"].Trim();
            if(ModelState.IsValid)
            { 
                if(temp==u.Password)
                {
                    db.users.Add(u);
                    db.SaveChanges();
                    TempData["RegistrationSucess"] = "User registered sucessfully..";//tempdata to retain the value
                    return RedirectToAction("Index");
                }

            }
            return View("Register", null);
        }

    }
}
