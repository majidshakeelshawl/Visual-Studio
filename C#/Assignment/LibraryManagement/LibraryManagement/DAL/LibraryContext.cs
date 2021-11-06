using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LibraryManagement.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LibraryManagement.DAL
{
    public class LibraryContext : DbContext
    {

        public LibraryContext() : base(@"data source=HPELITEBOOK\SQLEXPRESS;initial catalog=LibraryProjectContext;User id=sa;password=12345678;MultipleActiveResultSets=True")
        {
        }

        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Book> Books { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }








    }
}