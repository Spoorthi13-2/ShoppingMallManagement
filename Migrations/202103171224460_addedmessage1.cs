namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmessage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ForgotIds", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ForgotIds", "Message");
        }
    }
}
