using do_an_cnpm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace do_an_cnpm.Controllers
{
    public class DonThuocController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: DonThuoc
        public ActionResult DonThuoc(string search)
        {
            return View(db.DONTHUOCs.Where(n => n.BENHNHAN.HoTen.Contains(search) || search == null).ToList());
        }

        // GET: DonThuoc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DonThuoc/Create
        public ActionResult TaoDonT()
        {
            return View();
        }

        // POST: DonThuoc/Create
        [HttpPost]
        public ActionResult TaoDonT(DONTHUOC dt)
        {
            try
            {
                // TODO: Add insert logic here
                db.DONTHUOCs.Add(dt); //add xuong
                db.SaveChanges(); //luu su thay doi moi
                return RedirectToAction("DonThuoc");

            }
            catch
            {
                return View();
            }
        }

        // GET: DonThuoc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonThuoc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DonThuoc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonThuoc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
