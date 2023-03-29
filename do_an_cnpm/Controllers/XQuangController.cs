using do_an_cnpm.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace do_an_cnpm.Controllers
{
    public class XQuangController : Controller
    {
        DBPhongmachEntities db = new DBPhongmachEntities();
        // GET: XQuang
        public ActionResult XQuang(string search, string sortOrder, int? page, int? pageSize)
        {
            ViewBag.MaPCXQSortParm = String.IsNullOrEmpty(sortOrder) ? "mapxq_desc" : "";
            ViewBag.MaBNSortParm = sortOrder == "mabn" ? "mabn_desc" : "mabn";
            var benhnhan = db.PHIEUCHUPXQUANGs.Where(n => n.BENHNHAN.HoTen.Contains(search) || search == null).AsQueryable();
            switch (sortOrder)
            {
                case "mapxq_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaPCXQ);
                    break;
                case "mabn":
                    benhnhan = benhnhan.OrderBy(s => s.MaBN);
                    break;
                case "mabn_desc":
                    benhnhan = benhnhan.OrderByDescending(s => s.MaBN);
                    break;
                default:
                    benhnhan = benhnhan.OrderBy(s => s.MaPCXQ);
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

        [HttpGet]
        public ActionResult LapPhieuXQ()
        {
            PHIEUCHUPXQUANG xq = new PHIEUCHUPXQUANG();
            return View(xq);
        }
        [HttpPost]
        public ActionResult LapPhieuXQ(PHIEUCHUPXQUANG xq)
        {
            try
            {
                if (xq.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(xq.ImageUpload.FileName);
                    string extension = Path.GetExtension(xq.ImageUpload.FileName);
                    fileName = fileName + extension;
                    xq.KetQuaChupXQuang = "~/Content/images/" + fileName;
                    xq.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                db.PHIEUCHUPXQUANGs.Add(xq);
                db.SaveChanges();
                return RedirectToAction("XQuang");
            } 
            catch
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult SuaXQ(int id)
        {
            var edit = db.PHIEUCHUPXQUANGs.Find(id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult SuaXQ(PHIEUCHUPXQUANG xq)
        {
            try
            {
                var sua = db.PHIEUCHUPXQUANGs.Find(xq.MaPCXQ);

                if (xq.ImageUpload != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(xq.ImageUpload.FileName);
                    string extension = Path.GetExtension (xq.ImageUpload.FileName);
                    filename = filename + extension;
                    xq.KetQuaChupXQuang = "~/Content/images/" + filename;
                    xq.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                sua.BENHNHAN.HoTen = xq.BENHNHAN.HoTen;
                sua.BENHNHAN.NgayKham = xq.BENHNHAN.NgayKham;
                sua.Ngay = xq.Ngay;
                sua.BENHNHAN.DiaChi = xq.BENHNHAN.DiaChi;
                sua.BACSI.TenBacSi = xq.BACSI.TenBacSi;
                sua.ChuanDoan = xq.ChuanDoan;
                sua.YeuCauChupXQuang = xq.YeuCauChupXQuang;
                sua.KetQuaChupXQuang = xq.KetQuaChupXQuang;

                db.SaveChanges();
                return RedirectToAction("XQuang");
            } 
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ChiTietXQ(int id)
        {
            return View(db.PHIEUCHUPXQUANGs.Where(s => s.MaPCXQ == id).FirstOrDefault());
        }

        //Xoa
        //hien thi form can xoa
        [HttpGet]
        public ActionResult XoaXQ(int id)
        {
            return View(db.PHIEUCHUPXQUANGs.Where(s => s.MaPCXQ == id).FirstOrDefault());
        }
        //luu viec xoa du lieu
        [HttpPost]
        public ActionResult Xoa(int id, PHIEUCHUPXQUANG xq)
        {
            try
            {
                xq = db.PHIEUCHUPXQUANGs.Where(s => s.MaPCXQ == id).FirstOrDefault();
                db.PHIEUCHUPXQUANGs.Remove(xq);
                db.SaveChanges();
                return RedirectToAction("XQuang");
            }
            catch
            {
                ViewBag.Message = "Xoa that bai, hay kiem tra lai!";
                return View();
            }
        }
    }
}