using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using JMP_WU_Domain;
using James_MasterPiece_WebbUppgift.Context;

namespace James_MasterPiece_WebbUppgift
{
    public class Startup


    {

        MasterPieceContext context = new MasterPieceContext();


        public Startup(IHostingEnvironment env)
        {
            //ClearDatabase();
            //AddEmployeeWithAttributes();


            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });



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
                            Status = Status.Unstarted
                        }
                    },

                },

            };

            context.Employee.Add(employee);
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


