using HoTelManger_MVCFM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoTelManger_MVCFM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            name = Request["username"];
            password = Request["password"];

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                return Content("<script>alert('账号和密码不能为空');</script>");
            }
            else
            {
                bool result = UserServer.UserConform(name, password);
                if (result)
                {
                    return RedirectToAction("Home", "Home");
                }
                return Content("<script>alert('账号和密码不能为空');</script>");
            }

           
        }
         
    }
}