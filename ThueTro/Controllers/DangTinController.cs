using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThueTro.Models;

namespace ThueTro.Controllers
{
    [Authorize]
    public class DangTinController : Controller
    {
        public readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: DangTin
        public ActionResult Index()
        {
            return View();
        }

        // GET: DangTin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DangTin/Create
        public ActionResult Create()
        {
            ViewBag.IDQuann = new SelectList(db.DiaDiems, "IDQuan", "TenQuan");
            return View();
        }

        // POST: DangTin/Create
        [HttpPost]
        public ActionResult Create(NhaTro nhatro, HttpPostedFileBase anh, HttpPostedFileBase anh2, HttpPostedFileBase anh3)
        {
            ViewBag.IDQuann = new SelectList(db.DiaDiems, "IDQuan", "TenQuan");
            if (anh == null || anh2 == null || anh3 == null)
            {
                ViewBag.Thongbao = "Bạn chưa chọn ảnh";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {

                    var fileName = Path.GetFileName(anh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Imagess/TuanDan/QPhuNhuan/"), fileName);

                    var fileName2 = Path.GetFileName(anh2.FileName);
                    var path2 = Path.Combine(Server.MapPath("~/Imagess/TuanDan/QPhuNhuan/"), fileName2);

                    var fileName3 = Path.GetFileName(anh3.FileName);
                    var path3 = Path.Combine(Server.MapPath("~/Imagess/TuanDan/QPhuNhuan/"), fileName3);
                    if (System.IO.File.Exists(path) || System.IO.File.Exists(path2) || System.IO.File.Exists(path3))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        anh.SaveAs(path);
                        anh2.SaveAs(path2);
                        anh3.SaveAs(path3);
                    }
                    nhatro.image = fileName;
                    nhatro.image2 = fileName2;
                    nhatro.image3 = fileName3;
                    db.NhaTros.Add(nhatro);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(nhatro);
            }
        }

        // GET: DangTin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DangTin/Edit/5
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

    }
}
