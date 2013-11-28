using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicassoWeb.Models;

namespace PicassoWeb.Controllers
{   
    public class BancoController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /Banco/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.Banco.Include(banco => banco.PromosBanco).ToList());
        }

        //
        // GET: /Banco/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int id)
        {
            Banco banco = context.Banco.Single(x => x.Id == id);
            return View(banco);
        }

        //
        // GET: /Banco/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Banco());
        } 

        //
        // POST: /Banco/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Banco banco)
        {
            banco.Imagen = UploadHandler.subir(Request.Files[0], "Bancos", (context.Banco.Count() + 1) + "-" + banco.Nombre.Trim().Replace(" ", String.Empty), "");
            if (ModelState.IsValid)
            {
                context.Banco.Add(banco);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(banco);
        }
        
        //
        // GET: /Banco/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Banco banco = context.Banco.Single(x => x.Id == id);
            return View(banco);
        }

        //
        // POST: /Banco/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Banco banco)
        {
            Banco bancoOriginal = context.Banco.Single(x => x.Id == banco.Id);
            banco.Imagen = UploadHandler.subir(Request.Files[0], "Banco", banco.Id + "-" + banco.Nombre.Trim().Replace(" ", String.Empty), bancoOriginal.Imagen);

            if (ModelState.IsValid) {
                context.Entry(bancoOriginal).CurrentValues.SetValues(banco);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banco);
        }

        //
        // GET: /Banco/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Banco banco = context.Banco.Single(x => x.Id == id);
            return View(banco);
        }

        //
        // POST: /Banco/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Banco banco = context.Banco.Single(x => x.Id == id);
            context.Banco.Remove(banco);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}