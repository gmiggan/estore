namespace estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wgegr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cardNumber = c.String(),
                        expiryMonth = c.Int(nullable: false),
                        expiryYear = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CreditCards", new[] { "user_Id" });
            DropTable("dbo.CreditCards");
        }
    }
}
