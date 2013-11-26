﻿using System;
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
            ViewBag.fondoBody = "/Images/fondoinicio.jpg";
            //ViewBag.fondoBody = "/Images/bg-body.jpg";
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
            ViewBag.fondoBody = "/Images/fondoempresa.jpg";                        
            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Informacion de contacto";
            ViewBag.fondoBody = "/Images/fondocontacto.jpg";
            ViewBag.imagenFooter = "/Images/imagenContacto.jpg";
            return View();
        }
        
        //rasanch: producto destacado en el HOME
        public ActionResult getProductoDestacado()
        {
            //int i = 0;
            var p = context.Producto.First();
            object producto = new { imagen = p.Imagen, nombre = p.Nombre};

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
                    promoJson[i] = new { imagen = item.Imagen, descripcion = item.Descripcion, id = item.Id };
                    i++;    
                }                
            }
            return Json(promoJson, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopUpIntersitio()
        {            
            return PartialView();
        }

        //rsanch: action para la pagina de venta empresas
        public ActionResult VentaEmpresas()
        {
            return View();
        }

        //ivan: se define el "metodo de accion" para traer las imagenes del slider del home
        //
        public ActionResult jsonGetSlider() {
            int i = 0;
            object[] sliderJson = new object[context.Slider.Count()]; //trae una lista de objetos
            foreach (var item in context.Slider) {
                sliderJson[i] = new { url = item.Url };
                i++;
            }

            //OTRA FORMA DE HACER LO DE ARRIBA CON LINQ
            //var sliderJson = from s in context.Slider
            //                 select new { url = s.Url };

            return Json(sliderJson, JsonRequestBehavior.AllowGet);
        }
    }
}
