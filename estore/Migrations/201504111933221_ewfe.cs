namespace estore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ewfe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCards", "type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditCards", "type");
        }
    }
}
