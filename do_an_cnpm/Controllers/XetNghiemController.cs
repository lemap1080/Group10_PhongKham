using do_an_cnpm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace do_an_cnpm.Controllers
{
    public class XetNghiemController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: XetNghiem
        public ActionResult XetNghiem(string search, int? page, int? pageSize)
        {
            if(page == null)
            {
                page = 1;
            }
            if(pageSize == null)
            {
                pageSize = 7;
            }
            return View(db.PHIEUXETNGHIEMs.Where(n => n.BENHNHAN.HoTen.Contains(search) || search == null).ToList().ToPagedList((int)page, (int)pageSize));
        }

        [HttpGet]
        public ActionResult Lapphieuxn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lapphieuxn(PHIEUXETNGHIEM xn)
        {
            db.PHIEUXETNGHIEMs.Add(xn);
            db.SaveChanges();
            return RedirectToAction("XetNghiem");
        }
        [HttpGet]
        public ActionResult Suaphieuxn(int id)
        {
            return View(db.PHIEUXETNGHIEMs.Where(s => s.MaPXN == id).FirstOrDefault());
        }
        //luu thong tin cap nhat vao database
        [HttpPost]
        public ActionResult Suaphieuxn(PHIEUXETNGHIEM xn)
        {
            db.Entry(xn).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("XetNghiem");
        }
        [HttpGet]
        public ActionResult ChiTiet(int id)
        {
            return View(db.PHIEUXETNGHIEMs.Where(s => s.MaPXN == id).FirstOrDefault());
        }

        //Xoa
        //hien thi form can xoa
        [HttpGet]
        public ActionResult XoaXN(int id)
        {
            return View(db.PHIEUXETNGHIEMs.Where(s => s.MaPXN == id).FirstOrDefault());
        }
        //luu viec xoa du lieu
        [HttpPost]
        public ActionResult Xoa(int id, PHIEUXETNGHIEM xn)
        {
            try
            {
                xn = db.PHIEUXETNGHIEMs.Where(s => s.MaPXN == id).FirstOrDefault();
                db.PHIEUXETNGHIEMs.Remove(xn);
                db.SaveChanges();
                return RedirectToAction("XetNghiem");
            }
            catch
            {
                ViewBag.Message = "Xoa that bai, hay kiem tra lai!";
                return View();
            }
        }
    }
}