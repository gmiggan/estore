namespace estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "imageRef", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "imageRef");
        }
    }
}
