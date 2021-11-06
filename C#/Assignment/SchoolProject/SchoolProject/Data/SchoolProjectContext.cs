using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolProject.Data
{
    public class SchoolProjectContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SchoolProjectContext() : base(@"data source=HPELITEBOOK\SQLEXPRESS;initial catalog=SchoolProjectContext;User id=sa;password=12345678;MultipleActiveResultSets=True")
        {
        }

        public System.Data.Entity.DbSet<SchoolProject.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<SchoolProject.Models.Student> Students { get; set; }
    }
}
