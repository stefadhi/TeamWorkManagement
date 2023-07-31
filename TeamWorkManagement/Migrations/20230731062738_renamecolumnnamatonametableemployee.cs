using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamWorkManagement.Migrations
{
    /// <inheritdoc />
    public partial class renamecolumnnamatonametableemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nama",
                table: "Employees",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "Nama");
        }
    }
}
