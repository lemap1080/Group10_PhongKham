using do_an_cnpm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace do_an_cnpm.Controllers
{
    public class CaKhamController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: CaKham
        public ActionResult CaKham(string search, int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 10;
            }

            return View(db.CAKHAMs.Where(n => n.BENHNHAN.SDT.Contains(search) || search == null).ToList().ToPagedList((int)page,(int)pageSize));
        }
        [HttpGet]
        public ActionResult LapCaKham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LapCaKham(CAKHAM ck)
        { 
            db.CAKHAMs.Add(ck);
            db.SaveChanges();  
            return RedirectToAction("CaKham"); 
        }
        //
        [HttpGet]
        public ActionResult SuaCK(int id)
        {
            return View(db.CAKHAMs.Where(n => n.MaCaKham == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult SuaCK(CAKHAM ck)
        {
            db.Entry(ck).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CaKham");
        }

        //Xoa
        //hien thi form can xoa
        [HttpGet]
        public ActionResult XoaCK(int id)
        {
            return View(db.CAKHAMs.Where(s => s.MaCaKham == id).FirstOrDefault());
        }
        //luu viec xoa du lieu
        [HttpPost]
        public ActionResult XoaCK(int id, CAKHAM ck)
        {
            try
            {
                ck = db.CAKHAMs.Where(s => s.MaCaKham == id).FirstOrDefault();
                db.CAKHAMs.Remove(ck);
                db.SaveChanges();
                return RedirectToAction("CaKham");
            }
            catch
            {
                ViewBag.Message = "Xoa that bai, hay kiem tra lai!";
                return View();
            }
        }


        public ActionResult ChonBN()
        {
            BENHNHAN bn = new BENHNHAN();
            bn.BNCollection = db.BENHNHANs.ToList<BENHNHAN>();
            return PartialView(bn);
        }
        public ActionResult ChonNgayKham()
        {
            BENHNHAN bn = new BENHNHAN();
            bn.BNCollection = db.BENHNHANs.ToList<BENHNHAN>();
            return PartialView(bn);
        }
        public ActionResult ChonDiaChi()
        {
            BENHNHAN bn = new BENHNHAN();
            bn.BNCollection = db.BENHNHANs.ToList<BENHNHAN>();
            return PartialView(bn);
        }
        public ActionResult ChonGioiTinh()
        {
            BENHNHAN bn = new BENHNHAN();
            bn.BNCollection = db.BENHNHANs.ToList<BENHNHAN>();
            return PartialView(bn);
        }
        public ActionResult ChonLT()
        {
            LETAN lt = new LETAN();
            lt.LTCollection = db.LETANs.ToList<LETAN>();
            return PartialView(lt);
        }
        public ActionResult ChonBS()
        {
            BACSI bs = new BACSI();
            bs.BSCollection = db.BACSIs.ToList<BACSI>();
            return PartialView(bs);
        }
        

    }
}