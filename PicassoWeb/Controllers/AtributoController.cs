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
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.Atributo.Include(atributo => atributo.Productos).ToList());
        }

        //
        // GET: /Atributo/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int Id)
        {
            Atributo atributo = context.Atributo.Single(x => x.Id == Id);
            return View(atributo);
        }

        //
        // GET: /Atributo/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Atributo/Create
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            Atributo atributo = context.Atributo.Single(x => x.Id == Id);
            return View(atributo);
        }

        //
        // POST: /Atributo/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            Atributo atributo = context.Atributo.Single(x => x.Id == Id);
            return View(atributo);
        }

        //
        // POST: /Atributo/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Atributo atributo = context.Atributo.Single(x => x.Id == Id);
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