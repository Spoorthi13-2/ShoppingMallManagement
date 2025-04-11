namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestTables", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestTables", "Message");
        }
    }
}
