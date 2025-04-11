namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewTs", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewTs", "code");
        }
    }
}
