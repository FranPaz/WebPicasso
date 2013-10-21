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
    public class SucursalController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /Sucursal/

        public ViewResult Index()
        {
            return View(context.Sucursal.ToList());
        }

        //fpaz: Agrego la accion sucursales que es la que voy a usar para mostrar el listado de sucursales al cliente
        public ViewResult Sucursales()
        {
            return View(context.Sucursal.ToList());
        }

        //
        // GET: /Sucursal/Details/5

        public ViewResult Details(int id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.id == id);
            return View(sucursal);
        }

        //
        // GET: /Sucursal/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Sucursal/Create

        [HttpPost]
        public ActionResult Create(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                context.Sucursal.Add(sucursal);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(sucursal);
        }
        
        //
        // GET: /Sucursal/Edit/5
 
        public ActionResult Edit(int id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.id == id);
            return View(sucursal);
        }

        //
        // POST: /Sucursal/Edit/5

        [HttpPost]
        public ActionResult Edit(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                context.Entry(sucursal).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sucursal);
        }

        //
        // GET: /Sucursal/Delete/5
 
        public ActionResult Delete(int id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.id == id);
            return View(sucursal);
        }

        //
        // POST: /Sucursal/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.id == id);
            context.Sucursal.Remove(sucursal);
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


        public ActionResult mapasjson() {
            List<Sucursal> sucursalesmap = new List<Sucursal>();
            foreach (var item in context.Sucursal) {
                sucursalesmap.Add(item);
            }

            //var sucursalmap = ejemplo();
            return Json(sucursalesmap, JsonRequestBehavior.AllowGet);
        }
    }
}