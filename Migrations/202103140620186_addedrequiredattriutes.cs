namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrequiredattriutes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "BirthCity", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "BestFriendName", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "Strength", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "Strength", c => c.String());
            AlterColumn("dbo.Registrations", "BestFriendName", c => c.String());
            AlterColumn("dbo.Registrations", "BirthCity", c => c.String());
        }
    }
}
