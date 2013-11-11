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
    public class AtributoController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /Atributo/

        public ViewResult Index()
        {
            return View(context.Atributo.Include(atributo => atributo.productos).ToList());
        }

        //
        // GET: /Atributo/Details/5

        public ViewResult Details(int id)
        {
            Atributo atributo = context.Atributo.Single(x => x.id == id);
            return View(atributo);
        }

        //
        // GET: /Atributo/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Atributo/Create

        [HttpPost]
        public ActionResult Create(Atributo atributo)
        {
            if (ModelState.IsValid)
            {
                context.Atributo.Add(atributo);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(atributo);
        }
        
        //
        // GET: /Atributo/Edit/5
 
        public ActionResult Edit(int id)
        {
            Atributo atributo = context.Atributo.Single(x => x.id == id);
            return View(atributo);
        }

        //
        // POST: /Atributo/Edit/5

        [HttpPost]
        public ActionResult Edit(Atributo atributo)
        {
            if (ModelState.IsValid)
            {
                context.Entry(atributo).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atributo);
        }

        //
        // GET: /Atributo/Delete/5
 
        public ActionResult Delete(int id)
        {
            Atributo atributo = context.Atributo.Single(x => x.id == id);
            return View(atributo);
        }

        //
        // POST: /Atributo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Atributo atributo = context.Atributo.Single(x => x.id == id);
            context.Atributo.Remove(atributo);
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