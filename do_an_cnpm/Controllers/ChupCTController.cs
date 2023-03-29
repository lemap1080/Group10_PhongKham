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
    public class ChupCTController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: ChupCT
        public ActionResult ChupCT(string search, int? page, int? pageSize, string sortOrder)
        {
            ViewBag.MaPCTSortParm = String.IsNullOrEmpty(sortOrder) ? "mapct_desc" : "";
            ViewBag.MaBNSortParm = sortOrder == "mabn" ? "mabn_desc" : "mabn";
            var benhnhan = db.PHIEUCHUPCTs.Where(n => n.BENHNHAN.HoTen.Contains(search) || search == null).AsQueryable();
            switch (sortOrder)
            {
                case "mapct_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaPCCT);
                    break;
                case "mabn":
                    benhnhan = benhnhan.OrderBy(s => s.MaBN);
                    break;
                case "mabn_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaBN);
                    break;
                default:
                    benhnhan = benhnhan.OrderBy(s => s.MaPCCT);
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
            return View(benhnhan.ToList().ToPagedList((int) page, (int) pageSize));
        }

        // GET: ChupCT/Details/5
        public ActionResult ChiTietCT(int id)
        {
            return View(db.PHIEUCHUPCTs.Where(s => s.MaPCCT == id).FirstOrDefault());
        }

        // GET: ChupCT/Create
        public ActionResult LapPhieuCT()
        {
            PHIEUCHUPCT ct = new PHIEUCHUPCT();
            return View(ct);
        }

        // POST: ChupCT/Create
        [HttpPost]
        public ActionResult LapPhieuCT(PHIEUCHUPCT ct)
        {
            try
            {
                // TODO: Add insert logic here
                if (ct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ct.ImageUpload.FileName);
                    string extension = Path.GetExtension(ct.ImageUpload.FileName);
                    fileName = fileName + extension;
                    ct.KetQuaChupCT = "~/Content/images/" + fileName;
                    ct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                db.PHIEUCHUPCTs.Add(ct);
                db.SaveChanges();
                return RedirectToAction("ChupCT");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChupCT/Edit/5
        public ActionResult SuaCT(int id)
        {
            var edit = db.PHIEUCHUPCTs.Find(id);
            return View(edit);
        }

        // POST: ChupCT/Edit/5
        [HttpPost]
        public ActionResult SuaCT(PHIEUCHUPCT ct)
        {
            try
            {
                var sua = db.PHIEUCHUPCTs.Find(ct.MaPCCT);

                if (ct.ImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(ct.ImageUpload.FileName);
                    string extension = Path.GetExtension(ct.ImageUpload.FileName);
                    filename = filename + extension;
                    ct.KetQuaChupCT = "~/Content/images/" + filename;
                    ct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                sua.BENHNHAN.HoTen = ct.BENHNHAN.HoTen;
                sua.BENHNHAN.NgayKham = ct.BENHNHAN.NgayKham;
                sua.Ngay = ct.Ngay;
                sua.BENHNHAN.DiaChi = ct.BENHNHAN.DiaChi;
                sua.BACSI.TenBacSi = ct.BACSI.TenBacSi;
                sua.ChuanDoan = ct.ChuanDoan;
                sua.YeuCauChupCT = ct.YeuCauChupCT;
                sua.KetQuaChupCT = ct.KetQuaChupCT;

                db.SaveChanges();
                return RedirectToAction("XQuang");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChupCT/Delete/5
        public ActionResult XoaCT(int id)
        {
            return View(db.PHIEUCHUPCTs.Where(s => s.MaPCCT == id).FirstOrDefault());
        }

        // POST: ChupCT/Delete/5
        [HttpPost]
        public ActionResult XoaCT(int id, PHIEUCHUPCT ct)
        {
            try
            {
                ct = db.PHIEUCHUPCTs.Where(s => s.MaPCCT == id).FirstOrDefault();
                db.PHIEUCHUPCTs.Remove(ct);
                db.SaveChanges();
                return RedirectToAction("ChupCT");
            }
            catch
            {
                ViewBag.Message = "Xoa that bai, hay kiem tra lai!";
                return View();
            }
        }
    }
}
