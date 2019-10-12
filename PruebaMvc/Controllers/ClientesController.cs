using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PruebaMvc.Models;
using PruebaMvc.Vm;

namespace PruebaMvc.Controllers
{
    public class ClientesController : Controller
    {
        private PruebaDBContext db = new PruebaDBContext();

        // GET: Clientes
        public async Task<ActionResult> Index(string User)
        {

            var usuario = new List<string>();

            var usuarios = await( from d in  db.Clientes
                           orderby d.Nombre
                           select d.Nombre).ToListAsync() ;

            usuario.AddRange(usuarios.Distinct());
            ViewBag.User = new SelectList(usuario);
            var usuriostodos = await (from m in  db.Clientes
                         select m ).ToListAsync();
            if (!string.IsNullOrEmpty(User))
            {
                usuriostodos = usuriostodos.Where(x => x.Nombre == User).ToList();
            }
            this.ControllerContext.HttpContext.Response.Cookies.Add(new HttpCookie("Cliente", JsonConvert.SerializeObject(usuriostodos) ));
            return View(usuriostodos.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(Guid id)
        {
            //var con = id.ToGuid();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }

            var res = HttpContext.Request.Cookies.Get("Cliente").Value;//.AllKeys.Contains("Cliente");

           var conver =  JsonConvert.DeserializeObject<List<Clientes>>(res);

            ClienteList clientesTodos = new ClienteList { Nombre = clientes.Nombre,Apellido= clientes.Apellido, Rtn = clientes.Rtn, Clienteslis = conver };

            return View(clientesTodos);


        }


        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Rtn")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                clientes.Id = Guid.NewGuid();
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Rtn")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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
