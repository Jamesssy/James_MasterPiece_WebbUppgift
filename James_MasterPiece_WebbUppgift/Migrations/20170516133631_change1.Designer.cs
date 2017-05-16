using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using James_MasterPiece_WebbUppgift.Context;
using JMP_WU_Domain;

namespace James_MasterPiece_WebbUppgift.Migrations
{
    [DbContext(typeof(MasterPieceContext))]
    [Migration("20170516133631_change1")]
    partial class change1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JMP_WU_Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("JMP_WU_Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime>("EmployedSince");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("JMP_WU_Domain.EmployeeProjects", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("ProjectId");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("JMP_WU_Domain.PhoneNr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AltPhoneNr1");

                    b.Property<string>("AltPhoneNr2");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("MainPhoneNr");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("PhoneNr");
                });

            modelBuilder.Entity("JMP_WU_Domain.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActualCompletionDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("GoalCompletionDate");

                    b.Property<string>("Name");

                    b.Property<int>("ProjectNo");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("JMP_WU_Domain.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("SalaryPerMonth");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("JMP_WU_Domain.Address", b =>
                {
                    b.HasOne("JMP_WU_Domain.Employee", "Employee")
                        .WithOne("Address")
                        .HasForeignKey("JMP_WU_Domain.Address", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JMP_WU_Domain.EmployeeProjects", b =>
                {
                    b.HasOne("JMP_WU_Domain.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JMP_WU_Domain.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JMP_WU_Domain.PhoneNr", b =>
                {
                    b.HasOne("JMP_WU_Domain.Employee", "Employee")
                        .WithOne("PhoneNr")
                        .HasForeignKey("JMP_WU_Domain.PhoneNr", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JMP_WU_Domain.Salary", b =>
                {
                    b.HasOne("JMP_WU_Domain.Employee", "Employee")
                        .WithOne("Salary")
                        .HasForeignKey("JMP_WU_Domain.Salary", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
