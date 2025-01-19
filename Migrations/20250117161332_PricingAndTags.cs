using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameDevResources.Migrations
{
    /// <inheritdoc />
    public partial class PricingAndTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pricing",
                table: "Resource",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Resource",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pricing",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Resource");
        }
    }
}
