namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStockAttribute : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE BOOK SET Stock = 10 WHERE BookId = 1 ");
            Sql("UPDATE BOOK SET Stock = 2 WHERE BookId = 2 ");
            Sql("UPDATE BOOK SET Stock = 34 WHERE BookId = 3");
            Sql("UPDATE BOOK SET Stock = 16 WHERE BookId = 4 ");
        }
        
        public override void Down()
        {
        }
    }
}
