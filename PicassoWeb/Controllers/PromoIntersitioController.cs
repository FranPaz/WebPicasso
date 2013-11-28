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
    public class PromoIntersitioController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /PromoIntersitio/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.PromoIntersitio.ToList());
        }       

        //
        // GET: /PromoIntersitio/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int id)
        {
            PromoIntersitio promointersitio = context.PromoIntersitio.Single(x => x.Id == id);
            return View(promointersitio);
        }

        //
        // GET: /PromoIntersitio/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new PromoIntersitio());
        } 

        //
        // POST: /PromoIntersitio/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(PromoIntersitio promointersitio)
        {
            promointersitio.Imagen = UploadHandler.subir(Request.Files[0], "PromoIntersitio", (context.PromoIntersitio.Count() + 1) + "-" + promointersitio.Nombre.Trim().Replace(" ", String.Empty),"");

            if (ModelState.IsValid)
            {
                context.PromoIntersitio.Add(promointersitio);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(promointersitio);
        }
        
        //
        // GET: /PromoIntersitio/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            PromoIntersitio promointersitio = context.PromoIntersitio.Single(x => x.Id == id);
            return View(promointersitio);
        }

        //
        // POST: /PromoIntersitio/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(PromoIntersitio promointersitio)
        {
            PromoIntersitio promointersitioOriginal = context.PromoIntersitio.Single(x => x.Id == promointersitio.Id);
            promointersitio.Imagen = UploadHandler.subir(Request.Files[0], "PromoIntersitio", promointersitio.Id + "-" + promointersitio.Nombre.Trim().Replace(" ", String.Empty), promointersitioOriginal.Imagen);

            if (ModelState.IsValid)
            {
                context.Entry(promointersitioOriginal).CurrentValues.SetValues(promointersitio);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promointersitio);
        }

        //
        // GET: /PromoIntersitio/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            PromoIntersitio promointersitio = context.PromoIntersitio.Single(x => x.Id == id);
            return View(promointersitio);
        }

        //
        // POST: /PromoIntersitio/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoIntersitio promointersitio = context.PromoIntersitio.Single(x => x.Id == id);
            context.PromoIntersitio.Remove(promointersitio);
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