namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtostring1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ForgotIds", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.ForgotIds", "ContactNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ForgotIds", "BirthCity", c => c.String(nullable: false));
            AlterColumn("dbo.ForgotIds", "BestFriend", c => c.String(nullable: false));
            AlterColumn("dbo.ForgotIds", "Strength", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ForgotIds", "Strength", c => c.String());
            AlterColumn("dbo.ForgotIds", "BestFriend", c => c.String());
            AlterColumn("dbo.ForgotIds", "BirthCity", c => c.String());
            AlterColumn("dbo.ForgotIds", "ContactNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.ForgotIds", "Email", c => c.String());
        }
    }
}
