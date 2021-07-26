using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThueTro.Models;
using PagedList.Mvc;
using System.IO;

namespace ThueTro.Controllers
{
    public class NhaTroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NhaTroes
        [Authorize(Roles ="Admin")]

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

        // GET: NhaTroes/Details/5
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

        // GET: NhaTroes/Create
        public ActionResult Create()
        {
            ViewBag.DiaDiemIdQuan = new SelectList(db.DiaDiems, "IDQuan", "TenQuan");
            return View();
        }

        // POST: NhaTroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDNha,Tenduong,DienTich,TenChuNha,SDT,CTNha,GioiThieu,Gia,image,image2,image3,ratting,DiaDiemIdQuan,DateTime")] NhaTro nhaTro, HttpPostedFileBase[] anh)
        {
            //foreach (var file in anh)
            //{
            //    if (file == null)
            //    {
            //        ViewBag.Thongbao = "Bạn chưa chọn ảnh";
            //        return View();
            //    }
            //    else
            //    {
            if (ModelState.IsValid)
            {
                //            var fileName = Path.GetFileName(anh.FileName);
                //            var path = Path.Combine(Server.MapPath("~/Content/HinhAnh/"), fileName);
                //            if (System.IO.File.Exists(path))
                //            {
                //                ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                //            }
                //            else
                //            {
                //                anh.SaveAs(path);
                //            }
                //            nhaTro.image = fileName;
                    db.NhaTros.Add(nhaTro);
                    db.SaveChanges();
                //    }
                //}
                return RedirectToAction("Index");
            }
            ViewBag.DiaDiemIdQuan = new SelectList(db.DiaDiems, "IDQuan", "TenQuan", nhaTro.DiaDiemIdQuan);
            return View(nhaTro);
        }

        // GET: NhaTroes/Edit/5
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
            ViewBag.DiaDiemIdQuan = new SelectList(db.DiaDiems, "IDQuan", "TenQuan", nhaTro.DiaDiemIdQuan);
            return View(nhaTro);
        }

        // POST: NhaTroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNha,Tenduong,DienTich,TenChuNha,SDT,CTNha,GioiThieu,Gia,image,image2,image3,ratting,DiaDiemIdQuan,DateTime")] NhaTro nhaTro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaTro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiaDiemIdQuan = new SelectList(db.DiaDiems, "IDQuan", "TenQuan", nhaTro.DiaDiemIdQuan);
            return View(nhaTro);
        }

        // GET: NhaTroes/Delete/5
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

        // POST: NhaTroes/Delete/5
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
