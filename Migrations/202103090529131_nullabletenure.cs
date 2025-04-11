namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabletenure : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StoreDetails", "AgreementTenure", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StoreDetails", "AgreementTenure", c => c.Int(nullable: false));
        }
    }
}
