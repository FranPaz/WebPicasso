namespace PicassoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSucursalfoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sucursals", "foto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sucursals", "foto");
        }
    }
}
