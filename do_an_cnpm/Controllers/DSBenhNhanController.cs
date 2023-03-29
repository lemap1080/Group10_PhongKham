using do_an_cnpm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace do_an_cnpm.Controllers
{
    public class DSBenhNhanController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: DSBenhNhan
        public ActionResult DSBenhNhan(BENHNHAN bn, string search, int? page, int? pageSize, string sortOrder)
        {
            ViewBag.MaBNSortParm = String.IsNullOrEmpty(sortOrder) ? "mabn_desc" : "";
            ViewBag.TenSortParm = sortOrder == "ten" ? "ten_desc" : "ten";
            var benhnhan = db.BENHNHANs.Where(n => n.SDT.StartsWith(search) || search == null).AsQueryable();
            switch (sortOrder)
            {
                case "mabn_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaBN);
                    break;
                case "ten":
                    benhnhan = benhnhan.OrderBy(s => s.HoTen);
                    break;
                case "ten_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.HoTen);
                    break;
                default:
                    benhnhan = benhnhan.OrderBy(s => s.MaBN);
                    break;
            }
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 10;
            }
            return View(benhnhan.ToList().ToPagedList((int)page, (int)pageSize));
        }

        //hien thi form create nhap thong tin
        [HttpGet]
        public ActionResult PDKKhamBenh()
        {
            return View();
        }
        //luu thong tin tren form xuong database
        [HttpPost]
        public ActionResult PDKKhamBenh(BENHNHAN benhnhan)
        {
            db.BENHNHANs.Add(benhnhan); //add xuong
            db.SaveChanges(); //luu su thay doi moi
            return RedirectToAction("DSBenhNhan");
        }

        [HttpGet]
        public ActionResult ChiTiet(int id)
        {
            return View(db.BENHNHANs.Where(s => s.MaBN == id).FirstOrDefault());
        }

        //Cap nhat du lieu 
        //hien thi form can cap nhat thong tin
        [HttpGet]
        public ActionResult Sua(int id)
        {
            return View(db.BENHNHANs.Where(s => s.MaBN == id).FirstOrDefault());
        }
        //luu thong tin cap nhat vao database
        [HttpPost]
        public ActionResult Sua(BENHNHAN benhnhan)
        {
            db.Entry(benhnhan).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DSBenhNhan");
        }

        //Xoa
        //hien thi form can xoa
        [HttpGet]
        public ActionResult Xoa(int id)
        {
            return View(db.BENHNHANs.Where(s => s.MaBN == id).FirstOrDefault());
        }
        //luu viec xoa du lieu
        [HttpPost]
        public ActionResult Xoa(int id, BENHNHAN benhnhan)
        {
            try
            {
                benhnhan = db.BENHNHANs.Where(s => s.MaBN == id).FirstOrDefault();
                db.BENHNHANs.Remove(benhnhan);
                db.SaveChanges();
                return RedirectToAction("DSBenhNhan");
            }
            catch
            {
                ViewBag.Message = "Xoa that bai, hay kiem tra lai!";
                return View();
            }
        }

        public ActionResult ChonKG()
        {
            KHUNGGIO kg = new KHUNGGIO();
            kg.KGCollection = db.KHUNGGIOs.ToList<KHUNGGIO>();
            return PartialView(kg);
        }
    }
}