namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmsg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PwResets", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PwResets", "Message");
        }
    }
}
