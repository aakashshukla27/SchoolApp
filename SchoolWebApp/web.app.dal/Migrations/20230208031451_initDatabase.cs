using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.app.dal.Migrations
{
    /// <inheritdoc />
    public partial class initDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicant",
                columns: table => new
                {
                    applicantid = table.Column<int>(name: "applicant_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicantname = table.Column<string>(name: "applicant_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    applicantsurname = table.Column<string>(name: "applicant_surname", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    applicantbirthdate = table.Column<DateTime>(name: "applicant_birthdate", type: "datetime2", nullable: false),
                    contactemail = table.Column<string>(name: "contact_email", type: "nvarchar(250)", maxLength: 250, nullable: true),
                    contactnumber = table.Column<string>(name: "contact_number", type: "nvarchar(25)", maxLength: 25, nullable: false),
                    applicantcreationdate = table.Column<DateTime>(name: "applicant_creationdate", type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 8, 3, 14, 51, 25, DateTimeKind.Utc).AddTicks(6781)),
                    applicantmodifieddate = table.Column<DateTime>(name: "applicant_modifieddate", type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicant", x => x.applicantid);
                });

            migrationBuilder.CreateTable(
                name: "application_status",
                columns: table => new
                {
                    applicationstatusid = table.Column<int>(name: "application_status_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicationstatusname = table.Column<string>(name: "application_status_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    applicationstatuscreationdate = table.Column<DateTime>(name: "application_status_creationdate", type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 8, 3, 14, 51, 26, DateTimeKind.Utc).AddTicks(5834)),
                    applicationstatusmodifieddate = table.Column<DateTime>(name: "application_status_modifieddate", type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_status", x => x.applicationstatusid);
                });

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    gradeid = table.Column<int>(name: "grade_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gradename = table.Column<string>(name: "grade_name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gradenumber = table.Column<int>(name: "grade_number", type: "int", nullable: false),
                    gradecapacity = table.Column<int>(name: "grade_capacity", type: "int", nullable: false),
                    gradecreationdate = table.Column<DateTime>(name: "grade_creationdate", type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 8, 3, 14, 51, 27, DateTimeKind.Utc).AddTicks(6471)),
                    grademodifieddate = table.Column<DateTime>(name: "grade_modifieddate", type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.gradeid);
                });

            migrationBuilder.CreateTable(
                name: "application",
                columns: table => new
                {
                    applicationid = table.Column<int>(name: "application_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicantid = table.Column<int>(name: "applicant_id", type: "int", nullable: false),
                    gradeid = table.Column<int>(name: "grade_id", type: "int", nullable: false),
                    applicationstatusid = table.Column<int>(name: "application_status_id", type: "int", nullable: false),
                    applicationcreationdate = table.Column<DateTime>(name: "application_creationdate", type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 8, 3, 14, 51, 28, DateTimeKind.Utc).AddTicks(2735)),
                    applicationmodifieddate = table.Column<DateTime>(name: "application_modifieddate", type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    applicationschoolyear = table.Column<int>(name: "application_schoolyear", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application", x => x.applicationid);
                    table.ForeignKey(
                        name: "FK_application_applicant_applicant_id",
                        column: x => x.applicantid,
                        principalTable: "applicant",
                        principalColumn: "applicant_id");
                    table.ForeignKey(
                        name: "FK_application_application_status_application_status_id",
                        column: x => x.applicationstatusid,
                        principalTable: "application_status",
                        principalColumn: "application_status_id");
                    table.ForeignKey(
                        name: "FK_application_grade_grade_id",
                        column: x => x.gradeid,
                        principalTable: "grade",
                        principalColumn: "grade_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_application_applicant_id",
                table: "application",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_application_application_status_id",
                table: "application",
                column: "application_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_application_grade_id",
                table: "application",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_application_status_application_status_name",
                table: "application_status",
                column: "application_status_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_grade_grade_name",
                table: "grade",
                column: "grade_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_grade_grade_number",
                table: "grade",
                column: "grade_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application");

            migrationBuilder.DropTable(
                name: "applicant");

            migrationBuilder.DropTable(
                name: "application_status");

            migrationBuilder.DropTable(
                name: "grade");
        }
    }
}
