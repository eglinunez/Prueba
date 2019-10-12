using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Mapster;
using PruebaMvc.Models;
using PruebaMvc.Vm;

namespace PruebaMvc.Controllers
{
    public class DocumentoController : Controller
    {
        private PruebaDBContext db = new PruebaDBContext();

        // GET: Documento
        public async Task<ActionResult> Index()
        {

            // return View(db.Clientes.ToList());

            var documentos = View( await db.Documentos.Join(db.Clientes,
                d => d.ClienteId,
                c => c.Id,
                (d, c) => new
                { c = c, d = d })
                .Select(s => new DocumentosClienteVm
                {
                    clientes = s.c,
                    documentos = s.d,
                }
                ).ToListAsync()
                
               );
          
            return documentos;
        }

        // GET: Documento/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            return View(documentos);
        }

        // GET: Documento/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: Documento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,ClienteId")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                documentos.Id = Guid.NewGuid();
                db.Documentos.Add(documentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", documentos.ClienteId);
            return View(documentos);
        }

        // GET: Documento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", documentos.ClienteId);
            return View(documentos);
        }

        // POST: Documento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,ClienteId")] Documentos documentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nombre", documentos.ClienteId);
            return View(documentos);
        }

        // GET: Documento/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentos documentos = db.Documentos.Find(id);
            if (documentos == null)
            {
                return HttpNotFound();
            }
            return View(documentos);
        }

        // POST: Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Documentos documentos = db.Documentos.Find(id);
            db.Documentos.Remove(documentos);
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
