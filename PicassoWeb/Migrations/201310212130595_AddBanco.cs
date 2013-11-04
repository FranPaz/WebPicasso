namespace PicassoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bancoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PromoBancoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descuento = c.String(),
                        Cuotas = c.String(),
                        Dias = c.String(),
                        CondicionesLegales = c.String(),
                        BancoID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancoes", t => t.BancoID, cascadeDelete: true)
                .Index(t => t.BancoID);
            
            CreateTable(
                "dbo.PromoIntersitios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DirImagen = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PromoBancoes", new[] { "BancoID" });
            DropForeignKey("dbo.PromoBancoes", "BancoID", "dbo.Bancoes");
            DropTable("dbo.PromoIntersitios");
            DropTable("dbo.PromoBancoes");
            DropTable("dbo.Bancoes");
        }
    }
}
