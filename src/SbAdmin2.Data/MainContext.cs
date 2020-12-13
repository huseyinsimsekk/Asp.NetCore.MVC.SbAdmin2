using Microsoft.EntityFrameworkCore;
using SbAdmin2.Core.Models;
using SbAdmin2.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SbAdmin2.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> dbContext) : base(dbContext) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
