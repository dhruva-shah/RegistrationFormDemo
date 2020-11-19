using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationFormDemo.Migrations
{
    public partial class DateCreatedColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RegistrationEvent",
                type: "datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RegistrationEvent");
        }
    }
}
