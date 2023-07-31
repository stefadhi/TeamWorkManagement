using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWorkManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddTableEmployeeEmployeeAssigmentHistoryTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TasksToDo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksToDo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAssignmentHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAssignmentHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignmentHistories_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTaskToDo",
                columns: table => new
                {
                    EmployeesID = table.Column<int>(type: "int", nullable: false),
                    TasksToDoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaskToDo", x => new { x.EmployeesID, x.TasksToDoID });
                    table.ForeignKey(
                        name: "FK_EmployeeTaskToDo_Employees_EmployeesID",
                        column: x => x.EmployeesID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskToDo_TasksToDo_TasksToDoID",
                        column: x => x.TasksToDoID,
                        principalTable: "TasksToDo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                unique: true,
                filter: "[EmployeeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignmentHistories_EmployeeID",
                table: "EmployeeAssignmentHistories",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskToDo_TasksToDoID",
                table: "EmployeeTaskToDo",
                column: "TasksToDoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "EmployeeAssignmentHistories");

            migrationBuilder.DropTable(
                name: "EmployeeTaskToDo");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TasksToDo");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Users");
        }
    }
}
