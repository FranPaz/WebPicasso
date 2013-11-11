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
    public class AtributosProductoController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /AtributosProducto/

        public ViewResult Index()
        {
            return View(context.AtributosProducto.ToList());
        }

        //
        // GET: /AtributosProducto/Details/5

        public ViewResult Details(int id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.id == id);
            return View(atributosproducto);
        }

        //
        // GET: /AtributosProducto/Create

        public ActionResult Create()
        {
            ViewBag.PossibleProducto = context.Producto;
            ViewBag.PossibleAtributo = context.Atributo;
            return View();
        } 

        //
        // POST: /AtributosProducto/Create

        [HttpPost]
        public ActionResult Create(AtributosProducto atributosproducto)
        {
            if (ModelState.IsValid)
            {
                context.AtributosProducto.Add(atributosproducto);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleProducto = context.Producto;
            ViewBag.PossibleAtributo = context.Atributo;
            return View(atributosproducto);
        }
        
        //
        // GET: /AtributosProducto/Edit/5
 
        public ActionResult Edit(int id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.id == id);
            ViewBag.PossibleProducto = context.Producto;
            ViewBag.PossibleAtributo = context.Atributo;
            return View(atributosproducto);
        }

        //
        // POST: /AtributosProducto/Edit/5

        [HttpPost]
        public ActionResult Edit(AtributosProducto atributosproducto)
        {
            if (ModelState.IsValid)
            {
                context.Entry(atributosproducto).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleProducto = context.Producto;
            ViewBag.PossibleAtributo = context.Atributo;
            return View(atributosproducto);
        }

        //
        // GET: /AtributosProducto/Delete/5
 
        public ActionResult Delete(int id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.id == id);
            return View(atributosproducto);
        }

        //
        // POST: /AtributosProducto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.id == id);
            context.AtributosProducto.Remove(atributosproducto);
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