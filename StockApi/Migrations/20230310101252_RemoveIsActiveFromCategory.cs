using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsActiveFromCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Categories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
