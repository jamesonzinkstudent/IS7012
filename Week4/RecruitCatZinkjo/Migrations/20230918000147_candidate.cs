using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitCatZinkjo.Migrations
{
    /// <inheritdoc />
    public partial class candidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MinimumSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MinimumSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    TotalEmployees = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Performance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Industry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TargetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidate_Industry_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_JobTitle_TitleId",
                        column: x => x.TitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CompanyId",
                table: "Candidate",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_IndustryId",
                table: "Candidate",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_TitleId",
                table: "Candidate",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_IndustryId",
                table: "Company",
                column: "IndustryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "JobTitle");

            migrationBuilder.DropTable(
                name: "Industry");
        }
    }
}
