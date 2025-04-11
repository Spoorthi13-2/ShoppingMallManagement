namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfilterlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilterLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Occupancy = c.String(),
                        Type = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FilterLists");
        }
    }
}
