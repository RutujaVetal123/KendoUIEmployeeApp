using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KendoUIAppNew.Models
{
    public partial class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Account { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
