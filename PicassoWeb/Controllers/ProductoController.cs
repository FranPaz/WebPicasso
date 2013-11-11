using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicassoWeb.Models;
using System.Data.Entity.Infrastructure;

namespace PicassoWeb.Controllers
{   
    public class ProductoController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();


        public ActionResult getAtributosProducto(int id) {
            var lista = context.AtributosProducto.Where(a => a.ProductoID == id);
            int i = 0;
            object[] atributosJSON = new object[lista.Count()];
            foreach (var item in lista) {
                atributosJSON[i] = new { atributoID=item.AtributoID,nombre = item.atributo.nombre, valor = item.valor };
                i++;
            }
            return Json(atributosJSON, JsonRequestBehavior.AllowGet);
        }


        


        //
        // GET: /Producto/

        public ViewResult Index()
        {
            return View(context.Producto.ToList());
        }

        //
        // GET: /Producto/Details/5

        public ViewResult Details(int id)
        {
            Producto producto = context.Producto.Single(x => x.id == id);
            return View(producto);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            ViewBag.idProducto = "";
            return View();
        } 

        //
        // POST: /Producto/Create

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            if (producto.atributos != null) { 
                foreach (var item in producto.atributos) {
                    item.atributo = context.Atributo.Find(item.AtributoID);
                }
            }

            ModelState.Clear();
            TryValidateModel(producto); 

            if (ModelState.IsValid)
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }
        
        //
        // GET: /Producto/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.idProducto = id.ToString();
            

            Producto producto = context.Producto.Single(x => x.id == id);
            return View(producto);
        }

        

        // POST: /Producto/Edit/5
        [HttpPost]
        //public ActionResult Edit(IEnumerable <AtributosProducto> atributos)
        public ActionResult Edit(Producto producto, List<AtributosProducto> atribs) {
            Producto prodOriginal = context.Producto.Find(producto.id);
            var atribList = prodOriginal.atributos;
            context.AtributosProducto.RemoveRange(atribList);
            if (atribs != null) {
                if (prodOriginal.atributos != null) {
                    foreach (var a in atribs) {
                        a.atributo = context.Atributo.Find(a.AtributoID);
                        a.producto = context.Producto.Find(a.ProductoID);
                        context.AtributosProducto.Add(a);
                    }
                }
            } else {
                atribs = new List<AtributosProducto>();
            }

            ModelState.Clear();
            ValidateModel(producto);
            if (ModelState.IsValid) {
                context.Entry(prodOriginal).Property(p => p.descripcion).CurrentValue = producto.descripcion;
                context.Entry(prodOriginal).Property(p=> p.imagen).CurrentValue = producto.imagen;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            Producto prod = context.Producto.Single(x => x.id == atribs.First().ProductoID);
            return View(prod);

        }

        //
        // GET: /Producto/Delete/5
 
        public ActionResult Delete(int id)
        {
            Producto producto = context.Producto.Single(x => x.id == id);
            return View(producto);
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = context.Producto.Single(x => x.id == id);
            context.Producto.Remove(producto);
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