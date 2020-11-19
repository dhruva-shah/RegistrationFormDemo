using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistrationFormDemo.Migrations
{
    public partial class KeysAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(maxLength: 100, nullable: true),
                    Position = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 200, nullable: true),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: true),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: true),
                    City = table.Column<string>(maxLength: 200, nullable: true),
                    Province = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(maxLength: 7, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 13, nullable: true),
                    Email = table.Column<string>(maxLength: 500, nullable: true),
                    IsFirstTime = table.Column<bool>(nullable: true),
                    SendConfirmationEmail = table.Column<bool>(nullable: true),
                    DateRegistered = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationEvent",
                columns: table => new
                {
                    RegistrationEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationEvent", x => x.RegistrationEventId);
                    table.ForeignKey(
                        name: "FK_RegistrationEvent_Events",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrationEvent_Registrations",
                        column: x => x.RegistrationId,
                        principalTable: "Registrations",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationEvent_EventId",
                table: "RegistrationEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationEvent_RegistrationId",
                table: "RegistrationEvent",
                column: "RegistrationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "RegistrationEvent");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Registrations");
        }
    }
}
