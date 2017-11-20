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
    public class TipoChamadoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: TipoChamado
        public ActionResult Index()
        {
            return View(db.TipoChamado.ToList());
        }

        // GET: TipoChamado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoChamado tipoChamado = db.TipoChamado.Find(id);
            if (tipoChamado == null)
            {
                return HttpNotFound();
            }
            return View(tipoChamado);
        }

        // GET: TipoChamado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoChamado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoChamado,Descricao")] TipoChamado tipoChamado)
        {
            if (ModelState.IsValid)
            {
                db.TipoChamado.Add(tipoChamado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoChamado);
        }

        // GET: TipoChamado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoChamado tipoChamado = db.TipoChamado.Find(id);
            if (tipoChamado == null)
            {
                return HttpNotFound();
            }
            return View(tipoChamado);
        }

        // POST: TipoChamado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoChamado,Descricao")] TipoChamado tipoChamado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoChamado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoChamado);
        }

        // GET: TipoChamado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoChamado tipoChamado = db.TipoChamado.Find(id);
            if (tipoChamado == null)
            {
                return HttpNotFound();
            }
            return View(tipoChamado);
        }

        // POST: TipoChamado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoChamado tipoChamado = db.TipoChamado.Find(id);
            db.TipoChamado.Remove(tipoChamado);
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
