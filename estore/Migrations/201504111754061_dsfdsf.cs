namespace estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfdsf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        billingaddress1 = c.String(),
                        billingaddress2 = c.String(),
                        billingaddress3 = c.String(),
                        postaladdress1 = c.String(),
                        postaladdress2 = c.String(),
                        postaladdress3 = c.String(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.OrderHistories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        product_ProductId = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.product_ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.product_ProductId)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.ReviewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rating = c.Int(nullable: false),
                        comment = c.String(),
                        product_ProductId = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.product_ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.product_ProductId)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewModels", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewModels", "product_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderHistories", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderHistories", "product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Customers", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ReviewModels", new[] { "user_Id" });
            DropIndex("dbo.ReviewModels", new[] { "product_ProductId" });
            DropIndex("dbo.OrderHistories", new[] { "user_Id" });
            DropIndex("dbo.OrderHistories", new[] { "product_ProductId" });
            DropIndex("dbo.Customers", new[] { "user_Id" });
            DropTable("dbo.ReviewModels");
            DropTable("dbo.OrderHistories");
            DropTable("dbo.Customers");
        }
    }
}
