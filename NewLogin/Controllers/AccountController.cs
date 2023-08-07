using NewLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLogin.Controllers
{
    public class AccountController : Controller
    {
        DbContext db = new DbContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string email)
        {
            var row = db.GetUser().Where(model => model.Emailid == email).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            // Perform authentication logic here
            var data = db.GetUser().Where(model => model.Emailid == lvm.Emailid && model.Password == lvm.Password).FirstOrDefault();
            if (data != null)
            {
                return RedirectToAction("UpdateTask", "Task");
            }
            else
            {
                ViewBag.Showmsg = "Invalid email id or password";

            }
            
            return View(lvm);
        }
    }
}