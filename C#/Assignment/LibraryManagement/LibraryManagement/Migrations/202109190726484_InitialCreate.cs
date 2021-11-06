namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Author = c.String(),
                        BookAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Borrower",
                c => new
                    {
                        BorrowerId = c.Int(nullable: false, identity: true),
                        Occupation = c.String(),
                        BorrowerName = c.String(),
                        Phone = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.BorrowerId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrower", "BookId", "dbo.Book");
            DropIndex("dbo.Borrower", new[] { "BookId" });
            DropTable("dbo.Borrower");
            DropTable("dbo.Book");
        }
    }
}
