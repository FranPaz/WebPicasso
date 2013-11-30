using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PicassoWeb.Models
{
    public class PicassoWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<PicassoWeb.Models.PicassoWebContext>());

        public DbSet<PicassoWeb.Models.Sucursal> Sucursal { get; set; }

        public DbSet<PicassoWeb.Models.Banco> Banco { get; set; }

        public DbSet<PicassoWeb.Models.PromoIntersitio> PromoIntersitio { get; set; }

        public DbSet<PicassoWeb.Models.PromoBanco> PromoBanco { get; set; }

        public DbSet<PicassoWeb.Models.Producto> Producto { get; set; }

        public DbSet<PicassoWeb.Models.Atributo> Atributo { get; set; }

        public DbSet<PicassoWeb.Models.AtributosProducto> AtributosProducto { get; set; }

        public DbSet<PicassoWeb.Models.Categoria> Categoria { get; set; }

        public DbSet<PicassoWeb.Models.Marca> Marca { get; set; }

        public DbSet<PicassoWeb.Models.Slider> Slider { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Producto>()
            .HasRequired(p => p.Marca)
            .WithMany(m => m.Productos)
            .HasForeignKey(p => p.MarcaID)
            .WillCascadeOnDelete(false);

        }

    }
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<PicassoWebContext> {
        protected override void Seed(PicassoWebContext context) {
            //  This method will be called after migrating to the latest version.

            context.Atributo.AddRange(new List<Atributo>{
                new Atributo { Nombre = "Colores" },
                new Atributo { Nombre = "Presentaciones" },
                new Atributo { Nombre = "Usos" },
                new Atributo { Nombre = "Secado" },
                new Atributo { Nombre = "Rendimiento" },
                new Atributo { Nombre = "N° de manos" },
                new Atributo { Nombre = "Observaciones" },
                new Atributo { Nombre = "Relacion de Mezcla" },
                new Atributo { Nombre = "N° de Componentes" },
                new Atributo { Nombre = "Tiempo de prerreaccion" },
                new Atributo { Nombre = "Dosis Recomendada" }
                }
                );
            context.Categoria.AddRange(new List<Categoria>{
                new Categoria { Nombre = "SINTETICOS", Activo = true, Imagen = "/Images/noPhoto.jpg" },
                new Categoria { Nombre = "AEROSOLES", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "LÁTEX", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "AEROSOLES", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "MADERAS", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "ESPECIALES", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "ACCESORIOS LÁTEX", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "ACCESORIOS", Activo = true, Imagen = "/Images/noPhoto.jpg"  },                
                new Categoria { Nombre = "SELLADORES", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "AUTOMOTOR", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "INDUSTRIA", Activo = true, Imagen = "/Images/noPhoto.jpg"  },
                new Categoria { Nombre = "PINTURA EN POLVO", Activo = true, Imagen = "/Images/noPhoto.jpg"  }
                }
                );

            context.Sucursal.AddRange(new List<Sucursal>{
                new Sucursal { Nombre = "Casa Central", Direccion = "Av. Belgrano 669", Lat = -27.73764, Lon = -64.2462, Mail = "", Foto = "/Images/noPhoto.jpg" , Telefono = "", Horarios = "", Activo = true },
                new Sucursal { Nombre = "Santiago 1", Direccion = "Aguirre esq Alsina", Lat = -27.80489, Lon = -64.27037, Mail = "", Foto = "/Images/noPhoto.jpg" , Telefono = "", Horarios = "", Activo = true },
                new Sucursal { Nombre = "Santiago 2", Direccion = "Libertad 2511", Lat = -27.7971, Lon = -64.27597, Mail = "", Foto = "/Images/noPhoto.jpg" , Telefono = "", Horarios = "", Activo = true },                
                new Sucursal { Nombre = "La Banda 2", Direccion = "Aristóbulo del Valle 221", Lat = -27.73283, Lon = -64.23623, Mail = "", Foto = "/Images/noPhoto.jpg" , Telefono = "", Horarios = "", Activo = true },
                new Sucursal { Nombre = "Fernandez", Direccion = "Av San Martín 123", Lat = -27.92369, Lon = -63.89674, Mail = "", Foto = "/Images/noPhoto.jpg" , Telefono = "", Horarios = "", Activo = true }
            }
                );

            //context.Banco.Add(
            //    new Banco { Nombre = "Tarjeta Naranja", Imagen = "/Images/noPhoto.jpg" }
            //    );

            context.Marca.Add(
                new Marca { Nombre = "Tersuave", Activo = true, Imagen = "/Images/noPhoto.jpg"  }
                );

            
            
        }
    }
}