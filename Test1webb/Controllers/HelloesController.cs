using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test1webb.Models;

namespace Test1webb.Controllers
{
    public class HelloesController : Controller
    {
        private HelloDBcontext db = new HelloDBcontext();

        // GET: Helloes
        public ActionResult Index()
        {
            return View(db.Hellos.ToList());
        }

        // GET: Helloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hello hello = db.Hellos.Find(id);
            if (hello == null)
            {
                return HttpNotFound();
            }
            return View(hello);
        }

        // GET: Helloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Helloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,hej")] Hello hello)
        {
            if (ModelState.IsValid)
            {
                db.Hellos.Add(hello);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hello);
        }

        // GET: Helloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hello hello = db.Hellos.Find(id);
            if (hello == null)
            {
                return HttpNotFound();
            }
            return View(hello);
        }

        // POST: Helloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,hej")] Hello hello)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hello).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hello);
        }

        // GET: Helloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hello hello = db.Hellos.Find(id);
            if (hello == null)
            {
                return HttpNotFound();
            }
            return View(hello);
        }

        // POST: Helloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hello hello = db.Hellos.Find(id);
            db.Hellos.Remove(hello);
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
