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
    public class PromoBancoController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /PromoBanco/

        public ViewResult Index()
        {
            return View(context.PromoBanco.Include(promobanco => promobanco.Banco).ToList());
        }

        //fpaz: controlador para la pagina de principal de promociones de bancos
        public ViewResult PromocionesDeBancos()
        {
            return View(context.PromoBanco.Include(promobanco => promobanco.Banco).ToList());
        }                

        //
        // GET: /PromoBanco/Details/5

        public ViewResult Details(int id)
        {
            PromoBanco promobanco = context.PromoBanco.Single(x => x.Id == id);
            return View(promobanco);
        }

        //
        // GET: /PromoBanco/Create

        public ActionResult Create()
        {
            ViewBag.PossibleBanco = context.Banco;
            return View();
        } 

        //
        // POST: /PromoBanco/Create

        [HttpPost]
        public ActionResult Create(PromoBanco promobanco)
        {
            if (ModelState.IsValid)
            {
                context.PromoBanco.Add(promobanco);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleBanco = context.Banco;
            return View(promobanco);
        }
        
        //
        // GET: /PromoBanco/Edit/5
 
        public ActionResult Edit(int id)
        {
            PromoBanco promobanco = context.PromoBanco.Single(x => x.Id == id);
            ViewBag.PossibleBanco = context.Banco;
            return View(promobanco);
        }

        //
        // POST: /PromoBanco/Edit/5

        [HttpPost]
        public ActionResult Edit(PromoBanco promobanco)
        {
            if (ModelState.IsValid)
            {
                context.Entry(promobanco).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleBanco = context.Banco;
            return View(promobanco);
        }

        //
        // GET: /PromoBanco/Delete/5
 
        public ActionResult Delete(int id)
        {
            PromoBanco promobanco = context.PromoBanco.Single(x => x.Id == id);
            return View(promobanco);
        }

        //
        // POST: /PromoBanco/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoBanco promobanco = context.PromoBanco.Single(x => x.Id == id);
            context.PromoBanco.Remove(promobanco);
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