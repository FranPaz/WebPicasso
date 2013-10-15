using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PicassoWeb.Models
{
    public class Sucursal
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string dir { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }
        public string horarios { get; set; }
        
    }

    

}