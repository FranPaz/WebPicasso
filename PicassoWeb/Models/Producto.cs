using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PicassoWeb.Models {
    public class Producto {
        public Producto(){
            this.Activo = true;
            this.Imagen = "/Images/noPhoto.jpg";
        }
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        public string Video { get; set; }
        public bool Activo { get; set; }
        public virtual ICollection<AtributosProducto> Atributos{ get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int MarcaID { get; set; }
        public virtual Categoria Marca { get; set; }
    }

    public class AtributosProducto {
        public int Id { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }

        public int AtributoID { get; set; }
        public virtual Atributo Atributo { get; set; }
        public string Valor { get; set; }
        public int Orden { get; set; }
    }

    public class Atributo {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public bool Locked { get; set; }
    }

    public class Categoria {
        public Categoria(){
            this.Activo = true;
        }
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Activo { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }


    public class Marca {
        public Marca() {
            this.Activo = true;
        }
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Activo { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}