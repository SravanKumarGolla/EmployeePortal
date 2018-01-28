using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string Name { get; set; }
        public string NameArabic { get; set; }

        [Range(20,45)]
        public int Age { get; set; }

        public DateTime DateOfJoin { get; set; }

        public IEnumerable<EmployeeAddress> LstAddress { get; set; }

        public IEnumerable<EmployeeExperience> LstExp { get; set; }
    }


    
}