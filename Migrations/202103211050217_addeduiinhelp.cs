namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduiinhelp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Helps", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Helps", "UserId");
        }
    }
}
