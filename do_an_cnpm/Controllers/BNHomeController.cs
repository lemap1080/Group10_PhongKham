using do_an_cnpm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace do_an_cnpm.Controllers
{
    public class BNHomeController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: BNHome
        public ActionResult BNHome()
        {
            return View();
        }
        public ActionResult ThongTin()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DKKham(bool issucces = false)
        {
            ViewBag.issucces = issucces;
            return View();
        }
        [HttpPost]
        public ActionResult DKKham(BENHNHAN bn)
        {
            db.BENHNHANs.Add(bn); //add xuong
            db.SaveChanges(); //luu su thay doi moi
            return RedirectToAction("DKKham", new {issucces = true});
        }
    }
}