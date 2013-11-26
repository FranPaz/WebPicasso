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
    public class CategoriaController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /Categoria/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.Categoria.Include(categoria => categoria.Productos).ToList());
        }

        //
        // GET: /Categoria/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int Id)
        {
            Categoria categoria = context.Categoria.Single(x => x.Id == Id);
            return View(categoria);
        }

        //
        // GET: /Categoria/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Categoria());
        } 

        //
        // POST: /Categoria/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Categoria categoria,string url)
        {
            if (ModelState.IsValid)
            {
                context.Categoria.Add(categoria);
                context.SaveChanges();
                return RedirectToAction("Index","Categoria");  
            }

            return View(categoria);
        }
        
        //
        // GET: /Categoria/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            Categoria categoria = context.Categoria.Single(x => x.Id == Id);
            return View(categoria);
        }

        //
        // POST: /Categoria/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index", "Categoria");  
            }
            return View(categoria);
        }

        //
        // GET: /Categoria/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            Categoria categoria = context.Categoria.Single(x => x.Id == Id);
            return View(categoria);
        }

        //
        // POST: /Categoria/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Categoria categoria = context.Categoria.Single(x => x.Id == Id);
            context.Categoria.Remove(categoria);
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