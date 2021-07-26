using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThueTro.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace ThueTro.Controllers
{   [Authorize(Roles ="Admin")]
    public class QuanLyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NhaTro
        public ActionResult Index(int? page)
        {
            var total = db.NhaTros
                .Select(a => a.IDNha)
                .ToList().Count;
            ViewBag.total = total;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.NhaTros.ToList().OrderBy(n => n.IDNha).ToPagedList(pageNumber, pageSize));
        }

        // GET: NhaTro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaTro nhaTro = db.NhaTros.Find(id);
            if (nhaTro == null)
            {
                return HttpNotFound();
            }
            return View(nhaTro);
        }

        // GET: NhaTro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaTro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNha,Tenduong,DienTich,TenChuNha,SDT,CTNha,GioiThieu,Gia,image,image2,image3,ratting,IDQuann,DateTime")] NhaTro nhaTro)
        {
            if (ModelState.IsValid)
            {
                db.NhaTros.Add(nhaTro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaTro);
        }

        // GET: NhaTro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaTro nhaTro = db.NhaTros.Find(id);
            if (nhaTro == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuann = new SelectList(db.DiaDiems, "IDQuan", "TenQuan", nhaTro.IDQuann);
            return View(nhaTro);
        }

        // POST: NhaTro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNha,Tenduong,DienTich,TenChuNha,SDT,CTNha,GioiThieu,Gia,image,image2,image3,ratting,IDQuann,DateTime")] NhaTro nhatro, HttpPostedFileBase anh, HttpPostedFileBase anh2, HttpPostedFileBase anh3)
        {
            ViewBag.IDQuann = new SelectList(db.DiaDiems, "IDQuan", "TenQuan");
            //if (anh == null || anh2 == null || anh3 == null)
            //{
            //    ViewBag.Thongbao = "Bạn chưa chọn ảnh";
            //    return View();
            //}
            //else
            //{
            //    if (ModelState.IsValid)
            //    {

            //        var fileName = Path.GetFileName(anh.FileName);
            //        var path = Path.Combine(Server.MapPath("~/Imagess/Luanne/q1/"), fileName);

            //        var fileName2 = Path.GetFileName(anh.FileName);
            //        var path2 = Path.Combine(Server.MapPath("~/Imagess/Luanne/q1/"), fileName);

            //        var fileName3 = Path.GetFileName(anh.FileName);
            //        var path3 = Path.Combine(Server.MapPath("~/Imagess/Luanne/q1/"), fileName);
            //        if (System.IO.File.Exists(path)|| System.IO.File.Exists(path2)|| System.IO.File.Exists(path3))
            //        {
            //            ViewBag.Thongbao = "Hình ảnh đã tồn tại";
            //        }
            //        else
            //        {
            //            anh.SaveAs(path);
            //            anh2.SaveAs(path2);
            //            anh3.SaveAs(path3);
            //        }
            //        nhatro.image = fileName;
            //        nhatro.image2 = fileName2;
            //        nhatro.image3 = fileName3;
                    db.Entry(nhatro).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
            //    }
            //    return View(nhatro);
            //}
        }

        // GET: NhaTro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaTro nhaTro = db.NhaTros.Find(id);
            if (nhaTro == null)
            {
                return HttpNotFound();
            }
            return View(nhaTro);
        }

        // POST: NhaTro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhaTro nhaTro = db.NhaTros.Find(id);
            db.NhaTros.Remove(nhaTro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
