namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedshopdetailstbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shops", "UserId");
        }
    }
}
