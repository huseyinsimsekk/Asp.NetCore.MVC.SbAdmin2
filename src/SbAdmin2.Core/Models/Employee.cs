using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SbAdmin2.Core.Models
{
    public class Employee : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public int Gender { get; set; }

    }
}
