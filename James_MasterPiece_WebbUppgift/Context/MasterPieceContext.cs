﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JMP_WU_Domain;

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



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
             "Server = (localdb)\\mssqllocaldb; Database = JMP_WebbUppgift; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<EmployeeProjects>().HasKey(employeeProjects => new { employeeProjects.EmployeeId, employeeProjects.ProjectId });
        }
    }
}