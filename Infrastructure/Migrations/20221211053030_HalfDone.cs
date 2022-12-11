using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HalfDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesJobHistories",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesJobHistories", x => new { x.EmployeeId, x.Id });
                    table.ForeignKey(
                        name: "FK_EmployeesJobHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesJobHistories_JobHistories_Id",
                        column: x => x.Id,
                        principalTable: "JobHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobsEmployees",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsEmployees", x => new { x.JobId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_JobsEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobsEmployees_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobsJobsHistories",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsJobsHistories", x => new { x.JobId, x.Id });
                    table.ForeignKey(
                        name: "FK_JobsJobsHistories_JobHistories_Id",
                        column: x => x.Id,
                        principalTable: "JobHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobsJobsHistories_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesJobHistories_Id",
                table: "EmployeesJobHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_JobsEmployees_EmployeeId",
                table: "JobsEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsJobsHistories_Id",
                table: "JobsJobsHistories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesJobHistories");

            migrationBuilder.DropTable(
                name: "JobsEmployees");

            migrationBuilder.DropTable(
                name: "JobsJobsHistories");
        }
    }
}
