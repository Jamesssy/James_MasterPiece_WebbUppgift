using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace James_MasterPiece_WebbUppgift.Migrations
{
    public partial class change1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "Address",
                nullable: false,
                defaultValue: 0);
        }
    }
}
