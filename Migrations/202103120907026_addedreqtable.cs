namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreqtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestTables",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        StoreNo = c.String(nullable: false),
                        StoreLoc = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        ShopOwnerName = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        BusinessCategory = c.String(nullable: false),
                        AgreementTenure = c.Int(nullable: false),
                        Remarks = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RequestTables");
        }
    }
}
