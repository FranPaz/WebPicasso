namespace PicassoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atributoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        valor = c.String(),
                        Producto_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Productoes", t => t.Producto_id)
                .Index(t => t.Producto_id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        imagen = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atributoes", "Producto_id", "dbo.Productoes");
            DropIndex("dbo.Atributoes", new[] { "Producto_id" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Atributoes");
        }
    }
}
