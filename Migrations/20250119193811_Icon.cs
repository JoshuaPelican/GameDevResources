using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDevResources.Migrations
{
    /// <inheritdoc />
    public partial class Icon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Resource",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Resource");
        }
    }
}
