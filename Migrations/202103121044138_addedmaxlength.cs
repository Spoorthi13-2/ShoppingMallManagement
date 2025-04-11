namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmaxlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequestTables", "Remarks", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequestTables", "Remarks", c => c.String(nullable: false));
        }
    }
}
