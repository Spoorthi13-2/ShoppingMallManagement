namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanged : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Registrations");
            AlterColumn("dbo.Registrations", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Registrations", "UserId");
            DropColumn("dbo.Registrations", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrations", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Registrations");
            AlterColumn("dbo.Registrations", "UserId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Registrations", "Id");
        }
    }
}
