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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }


        public ActionResult IndexSlider() {
            return View();
        }  
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
