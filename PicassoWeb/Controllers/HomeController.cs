using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicassoWeb.Models;
using System.Net.Mail;
using System.Net;

namespace PicassoWeb.Controllers
{
    public class HomeController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        public ActionResult Index()
        {
            ViewBag.esHome = true;
            ViewBag.fondoBody = "/Images/fondoINICIO.jpg";            
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
            ViewBag.MostrarFB = true;
            ViewBag.Message = "Informacion de la Empresa";
            ViewBag.fondoBody = "/Images/fondoEMPRESA.jpg";
            ViewBag.imagenFooter = "/Images/imagenContacto.jpg";           
            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Informacion de contacto";
            ViewBag.fondoBody = "/Images/fondoCONTACTO.jpg";
            ViewBag.imagenFooter = "/Images/imagenContacto.jpg";
            return View();
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

        public ActionResult Divisiones()
        {
            ViewBag.Message = "Divisiones";
            ViewBag.fondoBody = "/Images/fondoEMPRESA.jpg";
            ViewBag.imagenFooter = "/Images/imagenContacto.jpg";
            return View();
        }

        public ActionResult DivisionHogar()
        {
            return View();
        }

        public ActionResult DivisionEmpresa()
        {
            return View();
        }

        public ActionResult DivisionMayorista()
        {
            return View();
        }

        public ActionResult DivisionProfesional()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contacto(Contacto form)
        {
            //rasnch configuracion de salida smtp de picassopinturerias con user web. No cambiar la contraseña.
            using (var client = new SmtpClient {
                Host = "mail.picassopinturerias.com.ar",
                Port = 587,
                Credentials = new NetworkCredential("web@picassopinturerias.com.ar", "PicAss08p"), 
                DeliveryMethod = SmtpDeliveryMethod.Network})
            {
                var mail = new MailMessage();
                mail.To.Add("contacto@picassopinturerias.com.ar"); // email de contacto que van a manejar ellos
                mail.From = new MailAddress(form.Email, form.Nombre);
                mail.Subject = String.Format("Nuevo contacto de: {0}. Asunto: {1}", form.Nombre,form.Asunto);
                mail.Body = String.Format("Nombre: {0} \n email: {1} \n telefono: {5} \n Localidad: {2} \n Asunto: {3} \n Comentarios: {4}", form.Nombre, form.Email, form.Localidad, form.Asunto, form.Comentario, form.Telefono);
                mail.IsBodyHtml = false;
                try
                {            
                    client.Send(mail);
                    return Content("Su comentario fue enviado correctamente, nos contactaremos con usted a la brevedad. Muchas gracias.");
                }
                catch (Exception)
                {
                    return Content("Hubo un error, por favor intentelo de nuevo mas tarde.");
                    throw;
                }
            }
        }
    }
}
