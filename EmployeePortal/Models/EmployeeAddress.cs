using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EmployeePortal.Models
{
    public class EmployeeAddress
    {
        public int AddressId { get; set; }
        [StringLength(200, ErrorMessage = "Name cannot be longer than 40 characters.")]
        public string Address { get; set; }

        public long MobileNumber { get; set; }
        public string Email { get; set; }
    }
}