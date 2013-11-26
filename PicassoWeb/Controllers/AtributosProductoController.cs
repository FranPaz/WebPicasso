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
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.AtributosProducto.ToList());
        }

        //
        // GET: /AtributosProducto/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int Id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.Id == Id);
            return View(atributosproducto);
        }

        //
        // GET: /AtributosProducto/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.PossibleProducto = context.Producto;
            ViewBag.PossibleAtributo = context.Atributo;
            return View();
        } 

        //
        // POST: /AtributosProducto/Create
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.Id == Id);
            ViewBag.PossibleProducto = context.Producto;
            ViewBag.PossibleAtributo = context.Atributo;
            return View(atributosproducto);
        }

        //
        // POST: /AtributosProducto/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.Id == Id);
            return View(atributosproducto);
        }

        //
        // POST: /AtributosProducto/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            AtributosProducto atributosproducto = context.AtributosProducto.Single(x => x.Id == Id);
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