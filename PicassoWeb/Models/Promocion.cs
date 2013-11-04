using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PicassoWeb.Models
{
    public abstract class Promocion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class PromoIntersitio:Promocion
    {
        public string DirImagen { get; set; }
        public bool Activo { get; set; }
    }

    public class PromoBanco:Promocion
    {
        public string Descuento { get; set; }
        public string Cuotas { get; set; }
        public string Dias { get; set; }
        public string CondicionesLegales { get; set; }

        public int BancoID { get; set; }
        public virtual Banco Banco { get; set; }
    }
}