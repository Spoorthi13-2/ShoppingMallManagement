namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class help : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        Issue = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateOfTicket = c.String(),
                        Status = c.String(),
                        Solution = c.String(),
                    })
                .PrimaryKey(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Helps");
        }
    }
}
