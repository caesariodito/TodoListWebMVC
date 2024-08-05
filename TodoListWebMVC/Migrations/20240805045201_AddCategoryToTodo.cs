using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Todo");
        }
    }
}
