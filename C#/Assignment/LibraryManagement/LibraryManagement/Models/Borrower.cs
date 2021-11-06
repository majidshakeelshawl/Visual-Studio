using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Borrower
    {   [Key]
        public int BorrowerId { get; set; }

        public string Occupation { get; set; }
        public string BorrowerName { get; set; }
        public int Phone { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Address { get; set; } 

    }
}