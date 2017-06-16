using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JMP_WU_Domain;
using James_MasterPiece_WebbUppgift.ViewModels;

namespace James_MasterPiece_WebbUppgift.Context
{
    public class MasterPieceContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<EmployeeProjects> EmployeeProjects { get; set; }
        public DbSet<PhoneNr> PhoneNr { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Salary> Salary { get; set; }
        
        public MasterPieceContext(DbContextOptions<MasterPieceContext> options) : base(options)
        {

        }

     


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //     "Server = (localdb)\\mssqllocaldb; Database = TEST_JMP_WebbUppgift; Trusted_Connection = True; ");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<EmployeeProjects>().HasKey(employeeProjects => new { employeeProjects.EmployeeId, employeeProjects.ProjectId });
        }
    }
}
