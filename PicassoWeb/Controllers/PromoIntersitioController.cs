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

        public ViewResult Index()
        {
            return View(context.PromoIntersitio.ToList());
        }       

        //
        // GET: /PromoIntersitio/Details/5

        public ViewResult Details(int id)
        {
            PromoIntersitio promointersitio = context.PromoIntersitio.Single(x => x.Id == id);
            return View(promointersitio);
        }

        //
        // GET: /PromoIntersitio/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PromoIntersitio/Create

        [HttpPost]
        public ActionResult Create(PromoIntersitio promointersitio)
        {
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
 
        public ActionResult Edit(int id)
        {
            PromoIntersitio promointersitio = context.PromoIntersitio.Single(x => x.Id == id);
            return View(promointersitio);
        }

        //
        // POST: /PromoIntersitio/Edit/5

        [HttpPost]
        public ActionResult Edit(PromoIntersitio promointersitio)
        {
            if (ModelState.IsValid)
            {
                context.Entry(promointersitio).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promointersitio);
        }

        //
        // GET: /PromoIntersitio/Delete/5
 
        public ActionResult Delete(int id)
        {
            PromoIntersitio promointersitio = context.PromoIntersitio.Single(x => x.Id == id);
            return View(promointersitio);
        }

        //
        // POST: /PromoIntersitio/Delete/5

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