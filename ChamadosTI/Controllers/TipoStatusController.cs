using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChamadosTI.Contexto;
using ChamadosTI.Models;

namespace ChamadosTI.Controllers
{
    public class TipoStatusController : Controller
    {
        private DBContext db = new DBContext();

        // GET: TipoStatus
        public ActionResult Index()
        {
            return View(db.Status.ToList());
        }

        // GET: TipoStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStatus tipoStatus = db.Status.Find(id);
            if (tipoStatus == null)
            {
                return HttpNotFound();
            }
            return View(tipoStatus);
        }

        // GET: TipoStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStatus,Descricao")] TipoStatus tipoStatus)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(tipoStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoStatus);
        }

        // GET: TipoStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStatus tipoStatus = db.Status.Find(id);
            if (tipoStatus == null)
            {
                return HttpNotFound();
            }
            return View(tipoStatus);
        }

        // POST: TipoStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStatus,Descricao")] TipoStatus tipoStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoStatus);
        }

        // GET: TipoStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStatus tipoStatus = db.Status.Find(id);
            if (tipoStatus == null)
            {
                return HttpNotFound();
            }
            return View(tipoStatus);
        }

        // POST: TipoStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoStatus tipoStatus = db.Status.Find(id);
            db.Status.Remove(tipoStatus);
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
