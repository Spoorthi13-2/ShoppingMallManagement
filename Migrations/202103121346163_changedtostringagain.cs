namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtostringagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequestTables", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequestTables", "Status", c => c.Boolean(nullable: false));
        }
    }
}
