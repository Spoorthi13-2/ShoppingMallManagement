namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedkeyqualifier : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReviewTs", "KeyQualifier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReviewTs", "KeyQualifier", c => c.String());
        }
    }
}
