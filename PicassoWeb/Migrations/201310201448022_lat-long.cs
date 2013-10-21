namespace PicassoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latlong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sucursals", "lat", c => c.Double(nullable: false));
            AddColumn("dbo.Sucursals", "lon", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sucursals", "lon");
            DropColumn("dbo.Sucursals", "lat");
        }
    }
}
