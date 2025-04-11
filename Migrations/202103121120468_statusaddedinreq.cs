namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusaddedinreq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shops", "Status");
        }
    }
}
