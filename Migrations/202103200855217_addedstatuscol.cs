namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatuscol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewTs", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewTs", "Status");
        }
    }
}
