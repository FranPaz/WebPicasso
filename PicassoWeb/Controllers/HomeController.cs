using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicassoWeb.Models;

namespace PicassoWeb.Controllers
{
    public class HomeController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IndexSlider() {
            return View();
        }  
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Empresa()
        {
            ViewBag.Message = "Informacion de la Empresa";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Informacion de contacto";

            return View();
        }
        
        //rasanch: producto destacado en el HOME
        public ActionResult getProductoDestacado()
        {
            int i = 0;
            var p = context.Producto.Find(1);
            object producto = new { imagen = p.imagen, nombre = p.descripcion};

            return Json(producto, JsonRequestBehavior.AllowGet);
        }
        //fpaz: action method para mostrar los datos de las promo bancos en la barra de promos del home
        public ActionResult jsonPromo()
        {
            int i = 0;
            object[] promoJson = new object[context.PromoBanco.Count()];
            foreach (var item in context.PromoBanco)
            {
                promoJson[i] = new { imagen = item.Banco.Imagen, descripcion = item.Descripcion, id = item.Id };
                i++;
            }

            return Json(promoJson, JsonRequestBehavior.AllowGet);
        }

        //fpaz: agrego el controlador para ir a la pagina del administrador
        [Authorize(Roles = "Admin")]
        public ActionResult Administrador()
        {
            return View();
        }

        //fpaz: para la promocion del intersitio
        public ActionResult jsonPromoIntersitio()
        {
            int i = 0;
            object[] promoJson = new object[context.PromoIntersitio.Count()];
            foreach (var item in context.PromoIntersitio)
            {
                if (item.Activo == true)
                {
                    promoJson[i] = new { imagen = item.DirImagen, descripcion = item.Descripcion, id = item.Id };
                    i++;    
                }                
            }
            return Json(promoJson, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopUpIntersitio()
        {            
            return PartialView();
        }
    }
}
