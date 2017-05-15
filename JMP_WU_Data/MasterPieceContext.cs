using System;
using Microsoft.EntityFrameworkCore;
using JMP_WU_Domain;

namespace JMP_WU_Data
{
    public class MasterPieceContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<EmployeeProjects> EmployeeProjects { get; set; }
        public DbSet<PhoneNr> PhoneNr { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Salary> Salary { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
             "Server = (localdb)\\mssqllocaldb; Database = JMP_WebbUppgift; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<EmployeeProjects>().HasKey(employeeProjects => new { employeeProjects.EmployeeId, employeeProjects.ProjectId});
        }
    }
}
