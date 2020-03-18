using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MHS.P4.OnlineReferrals.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Indication",
                columns: table => new
                {
                    IndicationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    HasNotes = table.Column<bool>(nullable: false),
                    NotesPrompt = table.Column<string>(maxLength: 10, nullable: true),
                    VisibilityStatusType = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indication", x => x.IndicationId);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    MedicationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    HasNotes = table.Column<bool>(nullable: false),
                    NotesPrompt = table.Column<string>(maxLength: 10, nullable: true),
                    VisibilityStatusType = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedicationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indication");

            migrationBuilder.DropTable(
                name: "Medication");
        }
    }
}
