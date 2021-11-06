using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Teacher
    {
        public string Name { get; set; }

        [Key]
        public int TeacherId { get; set; }

        public int Salary { get; set; }

        public string PhoneNumber { get; set; }


        public virtual List<Student> Students { get; set; }
    }
}