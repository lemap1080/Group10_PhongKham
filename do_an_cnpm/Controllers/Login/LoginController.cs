using do_an_cnpm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace do_an_cnpm.Controllers.Login
{
    public class LoginController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ADMINISTRATOR admin)
        {
            var check = db.ADMINISTRATORs.Where(n => n.TenAD.Equals(admin.TenAD) && n.MatKhau.Equals(admin.MatKhau)).FirstOrDefault();

            if (check == null)
            {
                ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng vui lòng nhập lại!";
                return View();
            }
            else
            {
                Session["TenAD"] = admin.TenAD;
                return RedirectToAction("Welcome", "Welcome");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}