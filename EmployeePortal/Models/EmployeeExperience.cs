using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Models
{
    public class EmployeeExperience
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public int NumberOfYears { get; set; }
    }
}