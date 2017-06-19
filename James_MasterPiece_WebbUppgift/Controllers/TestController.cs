using James_MasterPiece_WebbUppgift.Context;
using JMP_WU_Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace James_MasterPiece_WebbUppgift.Controllers
{
    public class TestController : Controller
    {
        private readonly MasterPieceContext context;

        public TestController(MasterPieceContext c)
        {
            context = c;
        }

        public void InitDatabase()
        {
            context.Database.EnsureCreated();
            ClearDatabase();
            AddEmployeeWithAttributes();

        }

        public void AddEmployeeWithAttributes()
        {

            var employee = new Employee
            {
                FirstName = "Cesar",
                LastName = "Augustus",
                DateOfBirth = new DateTime(1985, 11, 23),
                EmployedSince = new DateTime(2015, 03, 05),
                PhoneNr = new PhoneNr { MainPhoneNr = "0708-9612345", AltPhoneNr1 = "1234567890" },
                Salary = new Salary { SalaryPerMonth = 31000 },
                Address = new Address { Street = "StorHetsGatan 22", City = "Gbg", ZipCode = 32145 },
                EmployeeProjects = new List<EmployeeProjects>
                {
                    new EmployeeProjects
                    {
                        Project = new Project
                        {
                            Name = "Exalibur",
                            Description = "Webbkurs uppgift",
                            ProjectNo = 123,
                            GoalCompletionDate = new DateTime(2018,10,02),
                            StartDate = new DateTime(2017,10,02),
                            Status = Status.Started
                        }
                    },

                },

            };
            var employee2 = new Employee
            {
                FirstName = "Peter",
                LastName = "Parker",
                DateOfBirth = new DateTime(1991, 11, 23),
                EmployedSince = new DateTime(2016, 03, 05),
                PhoneNr = new PhoneNr { MainPhoneNr = "0708-9667433", AltPhoneNr1 = "876422572" },
                Salary = new Salary { SalaryPerMonth = 29000 },
                Address = new Address { Street = "SpindelGatan 155", City = "Stockholm", ZipCode = 45831 },
                EmployeeProjects = new List<EmployeeProjects>
                {
                    new EmployeeProjects
                    {
                        Project = new Project
                        {
                            Name = "Web Shooters",
                            Description = "Webbkurs uppgift",
                            ProjectNo = 234,
                            GoalCompletionDate = new DateTime(2020,10,02),
                            StartDate = new DateTime(2017,10,02),
                            Status = Status.Unstarted
                        }
                    },

                },

            };

            var employee3 = new Employee
            {
                FirstName = "Doctor",
                LastName = "Octopuss",
                DateOfBirth = new DateTime(1975, 11, 23),
                EmployedSince = new DateTime(2012, 03, 05),
                PhoneNr = new PhoneNr { MainPhoneNr = "0708-1247278", AltPhoneNr1 = "129-098743" },
                Salary = new Salary { SalaryPerMonth = 24000 },
                Address = new Address { Street = "ImGrumpyGatan 155", City = "Helsingborg", ZipCode = 32355 },
                EmployeeProjects = new List<EmployeeProjects>
                {
                    new EmployeeProjects
                    {
                        Project = new Project
                        {
                            Name = "How to kill a spider",
                            Description = "Webbkurs uppgift",
                            ProjectNo = 1337,
                            GoalCompletionDate = new DateTime(2017,10,02),
                            StartDate = new DateTime(2017,03,02),
                            Status = Status.Finished
                        }
                    },

                },

            };



            var employee4 = new Employee
            {
                FirstName = "Harry",
                LastName = "Osborn",
                DateOfBirth = new DateTime(1991, 06, 15),
                EmployedSince = new DateTime(2017, 03, 05),
                PhoneNr = new PhoneNr { MainPhoneNr = "0706-1247278", AltPhoneNr1 = "134-098743" },
                Salary = new Salary { SalaryPerMonth = 150000 },
                Address = new Address { Street = "ImNotReallyPoorGatan 1", City = "Gbg", ZipCode = 32146 },


            };
            var employee5 = new Employee
            {
                FirstName = "Green",
                LastName = "Goblin",
                DateOfBirth = new DateTime(1976, 11, 23),
                EmployedSince = new DateTime(2013, 03, 05),
                PhoneNr = new PhoneNr { MainPhoneNr = "0708-1247238", AltPhoneNr1 = "129-098747" },
                Salary = new Salary { SalaryPerMonth = 28000 },
                Address = new Address { Street = "ImGrumpierGatan 157", City = "Helsingborg", ZipCode = 32354 },
                EmployeeProjects = new List<EmployeeProjects>
                {
                    new EmployeeProjects
                    {
                        Project = new Project
                        {
                            Name = "How to kill a spider2",
                            Description = "Webbkurs uppgift",
                            ProjectNo = 1338,
                            GoalCompletionDate = new DateTime(2018,10,02),
                            StartDate = new DateTime(2015,03,02),
                            Status = Status.Finished
                        }
                    },

                },

            };


            context.Employee.Add(employee);
            context.Employee.Add(employee2);
            context.Employee.Add(employee3);
            context.Employee.Add(employee4);
            context.Employee.Add(employee5);
            context.SaveChanges();

        }

        private void ClearDatabase()
        {


            context.Employee.RemoveRange(context.Employee);
            context.Project.RemoveRange(context.Project);
            context.SaveChanges();

        }
    }
}

