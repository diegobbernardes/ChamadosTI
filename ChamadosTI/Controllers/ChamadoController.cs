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
    public class ChamadoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Chamado
        public ActionResult Index()
        {
            var chamados = db.Chamados.Include(c => c.Requisitante).Include(c => c.Responsavel).Include(c => c.Status).Include(c => c.TipoChamado);
            return View(chamados.ToList());
        }

        // GET: Chamado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // GET: Chamado/Create
        public ActionResult Create()
        {
            ViewBag.IdRequisitante = new SelectList(db.Usuarios, "IdUsuario", "Nome");
            ViewBag.IdResponsavel = new SelectList(db.Usuarios, "IdUsuario", "Nome");
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "Descricao");
            ViewBag.IdTipoChamado = new SelectList(db.TipoChamado, "IdTipoChamado", "Descricao");
            return View();
        }

        // POST: Chamado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChamado,Descricao,Pa,IdTipoChamado,IdRequisitante,IdResponsavel,IdStatus")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Chamados.Add(chamado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRequisitante = new SelectList(db.Usuarios, "IdUsuario", "Nome", chamado.IdRequisitante);
            ViewBag.IdResponsavel = new SelectList(db.Usuarios, "IdUsuario", "Nome", chamado.IdResponsavel);
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "Descricao", chamado.IdStatus);
            ViewBag.IdTipoChamado = new SelectList(db.TipoChamado, "IdTipoChamado", "Descricao", chamado.IdTipoChamado);
            return View(chamado);
        }

        // GET: Chamado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRequisitante = new SelectList(db.Usuarios, "IdUsuario", "Nome", chamado.IdRequisitante);
            ViewBag.IdResponsavel = new SelectList(db.Usuarios, "IdUsuario", "Nome", chamado.IdResponsavel);
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "Descricao", chamado.IdStatus);
            ViewBag.IdTipoChamado = new SelectList(db.TipoChamado, "IdTipoChamado", "Descricao", chamado.IdTipoChamado);
            return View(chamado);
        }

        // POST: Chamado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdChamado,Descricao,Pa,IdTipoChamado,IdRequisitante,IdResponsavel,IdStatus")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRequisitante = new SelectList(db.Usuarios, "IdUsuario", "Nome", chamado.IdRequisitante);
            ViewBag.IdResponsavel = new SelectList(db.Usuarios, "IdUsuario", "Nome", chamado.IdResponsavel);
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "Descricao", chamado.IdStatus);
            ViewBag.IdTipoChamado = new SelectList(db.TipoChamado, "IdTipoChamado", "Descricao", chamado.IdTipoChamado);
            return View(chamado);
        }

        // GET: Chamado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.Chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // POST: Chamado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chamado chamado = db.Chamados.Find(id);
            db.Chamados.Remove(chamado);
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
