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

        public ViewResult Index()
        {
            return View(context.Banco.Include(banco => banco.PromosBanco).ToList());
        }

        //
        // GET: /Banco/Details/5

        public ViewResult Details(int id)
        {
            Banco banco = context.Banco.Single(x => x.Id == id);
            return View(banco);
        }

        //
        // GET: /Banco/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Banco/Create

        [HttpPost]
        public ActionResult Create(Banco banco)
        {
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
 
        public ActionResult Edit(int id)
        {
            Banco banco = context.Banco.Single(x => x.Id == id);
            return View(banco);
        }

        //
        // POST: /Banco/Edit/5

        [HttpPost]
        public ActionResult Edit(Banco banco)
        {
            if (ModelState.IsValid)
            {
                context.Entry(banco).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banco);
        }

        //
        // GET: /Banco/Delete/5
 
        public ActionResult Delete(int id)
        {
            Banco banco = context.Banco.Single(x => x.Id == id);
            return View(banco);
        }

        //
        // POST: /Banco/Delete/5

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