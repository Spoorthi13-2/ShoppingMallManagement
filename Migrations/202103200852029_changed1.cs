namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReviewTs", "code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReviewTs", "code", c => c.String());
        }
    }
}
