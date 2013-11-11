namespace PicassoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atributos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Atributoes", "Producto_id", "dbo.Productoes");
            DropIndex("dbo.Atributoes", new[] { "Producto_id" });
            CreateTable(
                "dbo.AtributosProductoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductoID = c.Int(nullable: false),
                        AtributoID = c.Int(nullable: false),
                        valor = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Atributoes", t => t.AtributoID, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoID, cascadeDelete: true)
                .Index(t => t.AtributoID)
                .Index(t => t.ProductoID);
            
            AddColumn("dbo.Productoes", "Atributo_id", c => c.Int());
            CreateIndex("dbo.Productoes", "Atributo_id");
            AddForeignKey("dbo.Productoes", "Atributo_id", "dbo.Atributoes", "id");
            DropColumn("dbo.Atributoes", "valor");
            DropColumn("dbo.Atributoes", "Producto_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Atributoes", "Producto_id", c => c.Int());
            AddColumn("dbo.Atributoes", "valor", c => c.String());
            DropForeignKey("dbo.AtributosProductoes", "ProductoID", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "Atributo_id", "dbo.Atributoes");
            DropForeignKey("dbo.AtributosProductoes", "AtributoID", "dbo.Atributoes");
            DropIndex("dbo.AtributosProductoes", new[] { "ProductoID" });
            DropIndex("dbo.Productoes", new[] { "Atributo_id" });
            DropIndex("dbo.AtributosProductoes", new[] { "AtributoID" });
            DropColumn("dbo.Productoes", "Atributo_id");
            DropTable("dbo.AtributosProductoes");
            CreateIndex("dbo.Atributoes", "Producto_id");
            AddForeignKey("dbo.Atributoes", "Producto_id", "dbo.Productoes", "id");
        }
    }
}
