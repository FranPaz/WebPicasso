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
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.Sucursal.ToList());
        }

        //fpaz: Agrego la accion sucursales que es la que voy a usar para mostrar el listado de sucursales al cliente
        public ViewResult Sucursales()
        {
            ViewBag.fondoBody = "/Images/fondoSUCURSALES.jpg";
            ViewBag.imagenFooter = "/Images/imagenproductos.png";    
            return View(context.Sucursal.ToList());
        }

        //
        // GET: /Sucursal/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int Id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.Id == Id);
            return View(sucursal);
        }


        // rsanch detalles de la sucursal que se muestra en el popup
        // GET: /Sucursal/SucursalDetalles/5
        public ViewResult DetallesSucursal(int Id) {
            Sucursal sucursal = context.Sucursal.Single(x => x.Id == Id);
            return View(sucursal);
        }


        //
        // GET: /Sucursal/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Sucursal());
        } 

        

        //
        // POST: /Sucursal/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Sucursal sucursal)
        {
            sucursal.Foto = UploadHandler.subir(Request.Files[0], "Sucursales", (context.Sucursal.Count() + 1) + "-" + sucursal.Nombre.Trim().Replace(" ", String.Empty),"");

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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.Id == Id);
            return View(sucursal);
        }

        //
        // POST: /Sucursal/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Sucursal sucursal)
        {
            Sucursal sucursalOriginal = context.Sucursal.Single(x => x.Id == sucursal.Id);
            sucursal.Foto = UploadHandler.subir(Request.Files[0], "Sucursal", sucursal.Id + "-" + sucursal.Nombre.Trim().Replace(" ", String.Empty), sucursalOriginal.Foto);

            if (ModelState.IsValid)
            {
                context.Entry(sucursalOriginal).CurrentValues.SetValues(sucursal);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sucursal);
        }

        //
        // GET: /Sucursal/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.Id == Id);
            return View(sucursal);
        }

        //
        // POST: /Sucursal/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Sucursal sucursal = context.Sucursal.Single(x => x.Id == Id);
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