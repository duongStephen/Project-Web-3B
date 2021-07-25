using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThueTro.Models;

namespace ThueTro.Controllers
{
    public class NhaTroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NhaTroes
        public ActionResult Index()
        {
            return View(db.NhaTros.ToList());
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
            return View();
        }

        // POST: NhaTroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNha,Tenduong,DienTich,TenChuNha,SDT,CTNha,GioiThieu,Gia,image,ratting,IDQuann,DateTime")] NhaTro nhaTro)
        {
            if (ModelState.IsValid)
            {
                db.NhaTros.Add(nhaTro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(nhaTro);
        }

        // POST: NhaTroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNha,Tenduong,DienTich,TenChuNha,SDT,CTNha,GioiThieu,Gia,image,ratting,IDQuann,DateTime")] NhaTro nhaTro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaTro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
