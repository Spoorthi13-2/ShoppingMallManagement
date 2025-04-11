namespace ShoppingProjectA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ForgotIds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        ContactNumber = c.Int(nullable: false),
                        BirthCity = c.String(),
                        BestFriend = c.String(),
                        Strength = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ForgotIds");
        }
    }
}
