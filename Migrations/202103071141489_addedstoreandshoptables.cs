namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstoreandshoptables : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreDetails");
        }
    }
}
