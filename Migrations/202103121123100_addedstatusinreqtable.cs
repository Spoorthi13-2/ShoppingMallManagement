namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatusinreqtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestTables", "Status", c => c.String());
            DropColumn("dbo.Shops", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shops", "Status", c => c.String());
            DropColumn("dbo.RequestTables", "Status");
        }
    }
}
