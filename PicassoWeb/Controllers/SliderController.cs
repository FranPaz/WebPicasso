using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PicassoWeb.Models;
using System.IO;

namespace PicassoWeb.Controllers
{   
    public class SliderController : Controller
    {
        private PicassoWebContext context = new PicassoWebContext();

        //
        // GET: /Slider/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(context.Slider.ToList());
        }

        //
        // GET: /Slider/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(int id)
        {
            Slider slider = context.Slider.Single(x => x.Id == id);
            return View(slider);
        }

        //
        // GET: /Slider/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Slider());
        }


        //
        // POST: /Slider/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Slider slider)
        {
            slider.Url = UploadHandler.subir(Request.Files[0], "Slider", (context.Slider.Count() + 1) + "-" + slider.Nombre.Trim().Replace(" ", String.Empty),"");

            if (ModelState.IsValid)
            {    
                context.Slider.Add(slider);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }
            slider.Url = "/Images/noPhoto.jpg";
            return View(slider);
        }
        
        //
        // GET: /Slider/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Slider slider = context.Slider.Single(x => x.Id == id);
            return View(slider);
        }

        //
        // POST: /Slider/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Slider slider)
        {
            Slider sliderOriginal = context.Slider.Single(x => x.Id == slider.Id);
            slider.Url = UploadHandler.subir(Request.Files[0], "Slider", slider.Id + "-" + slider.Nombre.Trim().Replace(" ", String.Empty), sliderOriginal.Url);


            if (ModelState.IsValid)
            {
                context.Entry(sliderOriginal).CurrentValues.SetValues(slider);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        //
        // GET: /Slider/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Slider slider = context.Slider.Single(x => x.Id == id);
            return View(slider);
        }

        //
        // POST: /Slider/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = context.Slider.Single(x => x.Id == id);
            context.Slider.Remove(slider);
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