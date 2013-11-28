using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PicassoWeb.Models
{
    public class Banco
    {
	public Banco() {
            this.Imagen = "/Images/noPhoto.jpg";
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        
        public ICollection<PromoBanco> PromosBanco { get; set; }
    }
}