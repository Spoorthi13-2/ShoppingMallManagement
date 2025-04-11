namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedstoreandshopdb : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Shops");
            DropTable("dbo.StoreDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StoreDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreNo = c.String(nullable: false),
                        StoreSize = c.String(nullable: false),
                        StoreLocation = c.String(nullable: false),
                        AreaOfStore = c.Int(nullable: false),
                        OccupancyStatus = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShopName = c.String(),
                        BusinessCategory = c.String(),
                        AgreementTenure = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        StoreNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
