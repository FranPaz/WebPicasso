using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicassoWeb.Models;
using System.Data.Entity.Infrastructure;
using System.IO;
using PagedList; //fpaz: agregado para apaginacion

namespace PicassoWeb.Controllers
{   
    public class ProductoController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();


        public ActionResult getAtributosProducto(int Id) {
            var lista = context.AtributosProducto.Where(a => a.ProductoID == Id);
            int i = 0;
            object[] atributosJSON = new object[lista.Count()];
            foreach (var item in lista) {
                atributosJSON[i] = new { atributoID=item.AtributoID,nombre = item.Atributo.Nombre, valor = item.Valor };
                i++;
            }
            return Json(atributosJSON, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Producto/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.Producto.ToList());
        }

        //
        // GET: /Producto/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int Id)
        {
            Producto Producto = context.Producto.Single(x => x.Id == Id);
            return View(Producto);
        }

        //
        // GET: /Producto/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.PossibleCategoria = context.Categoria;
            ViewBag.PossibleMarca = context.Marca;

            ViewBag.idProducto = "";
            return View(new Producto());
        } 

        //
        // POST: /Producto/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Producto producto, List<AtributosProducto> atribs)
        {
            producto.Imagen = UploadHandler.subir(Request.Files[0], "Productos", (context.Producto.Count() + 1) + "-" + producto.Nombre.Trim().Replace(" ", String.Empty),"");

            if (atribs != null) {
                foreach (var a in atribs) {
                    a.Atributo = context.Atributo.Find(a.AtributoID);
                    a.Producto = context.Producto.Find(a.ProductoID);
                    context.AtributosProducto.Add(a);
                }
            } else {
                atribs = new List<AtributosProducto>();
            }

            //ModelState.Clear();
            //TryValidateModel(Producto); 

            if (ModelState.IsValid)
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleCategoria = context.Categoria;
            ViewBag.PossibleMarca = context.Marca;
            return View(producto);
        }
        
        //
        // GET: /Producto/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            ViewBag.idProducto = Id.ToString();
            ViewBag.PossibleCategoria = context.Categoria;
            ViewBag.PossibleMarca = context.Marca;

            Producto Producto = context.Producto.Single(x => x.Id == Id);
            return View(Producto);
        }


        [Authorize(Roles = "Admin")]
        // POST: /Producto/Edit/5
        [HttpPost]
        //public ActionResult Edit(IEnumerable <AtributosProducto> atributos)
        public ActionResult Edit(Producto producto, List<AtributosProducto> atribs) {
            Producto prodOriginal = context.Producto.Find(producto.Id);

            producto.Imagen = UploadHandler.subir(Request.Files[0], "Productos", (context.Producto.Count() + 1) + "-" + producto.Nombre.Trim().Replace(" ", String.Empty), prodOriginal.Imagen);

            var atribList = prodOriginal.Atributos;
            context.AtributosProducto.RemoveRange(atribList);
            if (atribs != null) {
                if (prodOriginal.Atributos != null) {
                    foreach (var a in atribs) {
                        a.Atributo = context.Atributo.Find(a.AtributoID);
                        a.Producto = context.Producto.Find(a.ProductoID);
                        context.AtributosProducto.Add(a);
                    }
                }
            } else {
                atribs = new List<AtributosProducto>();
            }

            if (ModelState.IsValid) {
                context.Entry(prodOriginal).Property(p => p.Nombre).CurrentValue = producto.Nombre;
                context.Entry(prodOriginal).Property(p=> p.Imagen).CurrentValue = producto.Imagen;
                context.Entry(prodOriginal).Property(p => p.Activo).CurrentValue = producto.Activo;
                context.Entry(prodOriginal).Property(p => p.Video).CurrentValue = producto.Video;
                context.Entry(prodOriginal).Property(p => p.Descripcion).CurrentValue = producto.Descripcion;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleCategoria = context.Categoria;
            ViewBag.PossibleMarca = context.Marca;
            return View(producto);

        }

        //
        // GET: /Producto/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            Producto Producto = context.Producto.Single(x => x.Id == Id);
            return View(Producto);
        }

        //
        // POST: /Producto/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Producto Producto = context.Producto.Single(x => x.Id == Id);
            context.Producto.Remove(Producto);
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

        //fpaz: action method para mostrar la pagina de catalogo de productos
        public ViewResult Catalogo() {
            ViewBag.fondoBody = "/Images/fondoPRODUCTOS.jpg";
            ViewBag.imagenFooter = "/Images/imagenContacto.jpg";
            return View(context.Categoria.ToList());
        }

        public ActionResult _ListadoProductos(int prmCategoria, string sortOrder, string currentFilter, string searchString, int? page)
        {
            //rsanch: simulando tiempo para probar el loading
            //System.Threading.Thread.Sleep(1000);

            //fpaz: guardo en el viewbag una lista con todos los productos de una categoria
            ViewBag.categoriaId = prmCategoria;

            //rsanch: Nombre de la categoria para mostrar
            ViewBag.categoriaId = context.Categoria.Find(prmCategoria).Nombre;

            var productos = from p in context.Producto
                                     where p.CategoriaID == prmCategoria
                                     select p;
            productos = productos.OrderBy(p => p.Id);
            //fpaz: para paginacion
            int pageSize = 6;
            int pageNumber = (page ?? 1);


            //fpaz: nombre de la vista parcial de catalogo de productos
            
            return PartialView(productos.ToPagedList(pageNumber,pageSize));
        }

        //fpaz: action para mostrar el detalle de un producto seleccionado del catalogo
        public ActionResult DetalleProducto(int prmId)
        {
            //fpaz: guardo en una variable del viewbag toda la info del producto           
            ViewBag.ProductoId = prmId ;

            var infoProducto = (from p in context.Producto
                            where p.Id == prmId
                            select p).First();           
            return PartialView(infoProducto);
        }        

        //fpaz: action method para mostrar los datos de las promo bancos en la barra de promos del home
        public ActionResult jsonAtributosProducto(int prmId )
        {
            //fpaz: guardo en una variable del viewbag toda la info del producto           
            var atributosProducto = from a in context.AtributosProducto
                                where a.ProductoID == prmId
                                select new { nombre = (from at in context.Atributo
                                                       where at.Id == a.AtributoID
                                                       select at.Nombre).FirstOrDefault(),
                                valor = a.Valor};          

            return Json(atributosProducto, JsonRequestBehavior.AllowGet);
        }

        
    }
}