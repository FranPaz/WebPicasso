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
    public class MarcaController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /Marca/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.Marca.Include(marca => marca.Productos).ToList());
        }

        //
        // GET: /Marca/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int id)
        {
            Marca marca = context.Marca.Single(x => x.Id == id);
            return View(marca);
        }

        //
        // GET: /Marca/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Marca());
        } 

        //
        // POST: /Marca/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                context.Marca.Add(marca);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(marca);
        }
        
        //
        // GET: /Marca/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Marca marca = context.Marca.Single(x => x.Id == id);
            return View(marca);
        }

        //
        // POST: /Marca/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Marca marca)
        {
            if (ModelState.IsValid)
            {
                context.Entry(marca).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        //
        // GET: /Marca/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Marca marca = context.Marca.Single(x => x.Id == id);
            return View(marca);
        }

        //
        // POST: /Marca/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Marca marca = context.Marca.Single(x => x.Id == id);
            context.Marca.Remove(marca);
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