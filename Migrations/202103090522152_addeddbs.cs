namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddbs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreDetails",
                c => new
                    {
                        StoreNo = c.String(nullable: false, maxLength: 128),
                        StoreSize = c.String(nullable: false),
                        StoreLocation = c.String(nullable: false),
                        Area = c.Int(nullable: false),
                        OccupancyStatus = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        ShopName = c.String(),
                        BusinessCategory = c.String(),
                        AgreementTenure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreDetails");
            DropTable("dbo.BusinessCategories");
        }
    }
}
