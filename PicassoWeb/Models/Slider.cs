using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicassoWeb.Models
{
    public class Slider
    {
        public Slider() {
            this.Url = "/Images/noPhoto.jpg";
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
    }
}