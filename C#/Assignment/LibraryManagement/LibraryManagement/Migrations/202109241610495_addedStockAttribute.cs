namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStockAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Stock");
        }
    }
}
