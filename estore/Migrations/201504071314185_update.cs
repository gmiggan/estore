namespace estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Name");
        }
    }
}
