﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SbAdmin2.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
