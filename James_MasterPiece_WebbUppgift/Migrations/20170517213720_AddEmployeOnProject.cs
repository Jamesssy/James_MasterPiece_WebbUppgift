using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace James_MasterPiece_WebbUppgift.Migrations
{
    public partial class AddEmployeOnProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_EmployeeId",
                table: "Project",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employee_EmployeeId",
                table: "Project",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employee_EmployeeId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_EmployeeId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Project");
        }
    }
}
