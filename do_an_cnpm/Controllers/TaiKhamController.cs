using do_an_cnpm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace do_an_cnpm.Controllers
{
    public class TaiKhamController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: TaiKham
        public ActionResult TaiKham(string search, string sortOrder, int? page, int? pageSize)
        {
            ViewBag.MaPTKSortParm = String.IsNullOrEmpty(sortOrder) ? "maptk_desc" : "";
            ViewBag.MaBNSortParm = sortOrder == "mabn" ? "mabn_desc" : "mabn";
            var benhnhan = db.PHIEUHENTAIKHAMs.Where(n => n.BENHNHAN.HoTen.Contains(search) || search == null).AsQueryable();
            switch (sortOrder)
            {
                case "maptk_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaPHTK);
                    break;
                case "mabn":
                    benhnhan = benhnhan.OrderBy(s => s.MaBN);
                    break;
                case "mabn_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaBN);
                    break;
                default:
                    benhnhan = benhnhan.OrderBy(s => s.MaPHTK);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 7;
            }
            return View(benhnhan.ToList().ToPagedList((int)page, (int)pageSize));
        }

        // GET: TaiKham/Details/5
        public ActionResult ChiTietTK(int id)
        {
            return View(db.PHIEUHENTAIKHAMs.Where(s => s.MaPHTK == id).FirstOrDefault());
        }

        // GET: TaiKham/Create
        public ActionResult LapPhieuTK()
        {
            PHIEUHENTAIKHAM tk = new PHIEUHENTAIKHAM();
            return View(tk);
        }

        // POST: TaiKham/Create
        [HttpPost]
        public ActionResult LapPhieuTK(PHIEUHENTAIKHAM tk)
        {
            try
            {
                // TODO: Add insert logic here
                db.PHIEUHENTAIKHAMs.Add(tk);
                db.SaveChanges();
                return RedirectToAction("TaiKham");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKham/Edit/5
        public ActionResult SuaTK(int id)
        {
            return View(db.PHIEUHENTAIKHAMs.Where(s => s.MaPHTK == id).FirstOrDefault());
        }

        // POST: TaiKham/Edit/5
        [HttpPost]
        public ActionResult SuaTK(int id, PHIEUHENTAIKHAM tk)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(tk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TaiKham");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaiKham/Delete/5
        public ActionResult XoaTK(int id)
        {
            return View(db.PHIEUHENTAIKHAMs.Where(s => s.MaPHTK == id).FirstOrDefault());
        }

        // POST: TaiKham/Delete/5
        [HttpPost]
        public ActionResult XoaTK(int id, PHIEUHENTAIKHAM tk)
        {
            try
            {
                // TODO: Add delete logic here
                tk = db.PHIEUHENTAIKHAMs.Where(s => s.MaPHTK == id).FirstOrDefault();
                db.PHIEUHENTAIKHAMs.Remove(tk);
                db.SaveChanges();
                return RedirectToAction("TaiKham");
            }
            catch
            {
                ViewBag.Message = "Xoa that bai, hay kiem tra lai!";
                return View();
            }
        }
    }
}
