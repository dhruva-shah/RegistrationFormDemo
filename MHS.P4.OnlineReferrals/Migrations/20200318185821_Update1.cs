using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MHS.P4.OnlineReferrals.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PocketReferrals",
                columns: table => new
                {
                    ReferralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferringPhysician = table.Column<string>(maxLength: 500, nullable: true),
                    ReferringPhysicianFax = table.Column<string>(maxLength: 15, nullable: true),
                    ReferringPhysicianCPSO = table.Column<string>(maxLength: 15, nullable: true),
                    InterpretingPhysician = table.Column<string>(maxLength: 500, nullable: true),
                    PatientName = table.Column<string>(maxLength: 500, nullable: true),
                    Gender = table.Column<string>(maxLength: 1, nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 150, nullable: true),
                    Province = table.Column<string>(maxLength: 150, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 7, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    PatientPhone = table.Column<string>(maxLength: 500, nullable: true),
                    PatientHealthCardNum = table.Column<string>(maxLength: 50, nullable: true),
                    PatientHealthCardVersion = table.Column<string>(maxLength: 10, nullable: true),
                    PatientCCName = table.Column<string>(maxLength: 500, nullable: true),
                    PatientCCFax = table.Column<string>(maxLength: 100, nullable: true),
                    PatientReasonForReferral = table.Column<string>(nullable: true),
                    PatientMedications = table.Column<string>(nullable: true),
                    isPacemaker = table.Column<bool>(nullable: true),
                    isDefibrillator = table.Column<bool>(nullable: true),
                    isTest2Weeks = table.Column<bool>(nullable: true),
                    isTestInconclusive = table.Column<bool>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    TestRequested = table.Column<string>(nullable: true),
                    InsuranceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PocketReferrals", x => x.ReferralId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PocketReferrals");
        }
    }
}
