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
        public Sucursal() {
            this.Foto = "/Images/noPhoto.jpg";
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Horarios { get; set; }
        public string Foto { get; set; }

        public double Lat { get; set; } //rsanch: lat y lon agregado para mostrar sucursal en el mapa
        public double Lon { get; set; }

        public bool Activo { get; set; }
        
    }

    

}