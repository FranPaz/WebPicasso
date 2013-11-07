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
    //rsanch: Controlador para los errores http que se definen en web.config
    public class ErroresController : Controller
    {
        public ViewResult Error404()
        {
            return View();
        }
        public ViewResult Error403() {
            return View();
        }
        public ViewResult Error500() {
            return View();
        }
    }
}