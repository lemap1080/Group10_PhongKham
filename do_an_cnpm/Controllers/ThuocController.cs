using do_an_cnpm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace do_an_cnpm.Controllers
{
    public class ThuocController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: Thuoc
        public ActionResult Thuoc(THUOC th, string search, int? page, int? pageSize, string sortOrder)
        {
            ViewBag.MaTSortParm = String.IsNullOrEmpty(sortOrder) ? "mat_desc" : "";
            ViewBag.TenSortParm = sortOrder == "ten" ? "ten_desc" : "ten";
            var benhnhan = db.THUOCs.Where(n => n.TenThuoc.Contains(search) || search == null).AsQueryable();
            switch (sortOrder)
            {
                case "mat_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaThuoc);
                    break;
                case "ten":
                    benhnhan = benhnhan.OrderBy(s => s.TenThuoc);
                    break;
                case "ten_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.TenThuoc);
                    break;
                default:
                    benhnhan = benhnhan.OrderBy(s => s.MaThuoc);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 6;
            }
            return View(benhnhan.ToList().ToPagedList((int)page, (int)pageSize));
        }
        [HttpGet]
        public ActionResult TaoThuoc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoThuoc(THUOC th)
        {
            db.THUOCs.Add(th);
            db.SaveChanges();
            return RedirectToAction("Thuoc");
        }

        //Cap nhat du lieu 
        //hien thi form can cap nhat thong tin
        [HttpGet]
        public ActionResult SuaThuoc(int id)
        {
            return View(db.THUOCs.Where(s => s.MaThuoc == id).FirstOrDefault());
        }
        //luu thong tin cap nhat vao database
        [HttpPost]
        public ActionResult SuaThuoc(THUOC th)
        {
            db.Entry(th).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Thuoc");
        }

        //Xoa
        //hien thi form can xoa
        [HttpGet]
        public ActionResult Xoathuoc(int id)
        {
            return View(db.THUOCs.Where(s => s.MaThuoc == id).FirstOrDefault());
        }
        //luu viec xoa du lieu
        [HttpPost]
        public ActionResult Xoathuoc(int id, THUOC th)
        {
            try
            {
                th = db.THUOCs.Where(s => s.MaThuoc == id).FirstOrDefault();
                db.THUOCs.Remove(th);
                db.SaveChanges();
                return RedirectToAction("Thuoc");
            }
            catch
            {
                ViewBag.Message = "Xoa that bai, hay kiem tra lai!";
                return View();
            }
        }

        public ActionResult ChonTK()
        {
            THUKHO tk = new THUKHO();
            tk.TKCollection = db.THUKHOes.ToList<THUKHO>();
            return PartialView(tk);
        }
    }
}