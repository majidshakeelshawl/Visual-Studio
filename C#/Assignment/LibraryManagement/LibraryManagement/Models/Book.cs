using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Book
    {

        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }

        // this should be hidden from UI
        public bool BookAvailable { get; set; }


        public int Stock { get; set; }



        
      

    }
}