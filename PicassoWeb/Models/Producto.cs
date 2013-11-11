using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PicassoWeb.Models {
    public class Producto {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public virtual ICollection<AtributosProducto> atributos{ get; set; }
    }

    public class AtributosProducto {
        public int id { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto producto { get; set; }
        public int AtributoID { get; set; }
        [Required]
        public virtual Atributo atributo { get; set; }
        public string valor { get; set; }
    }

    public class Atributo {
        public int id { get; set; }
        public string nombre { get; set; }
        public ICollection<Producto> productos { get; set; }
    }
}