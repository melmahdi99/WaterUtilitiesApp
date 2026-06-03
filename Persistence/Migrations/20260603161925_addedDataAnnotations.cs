using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedDataAnnotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Buildings",
                type: "decimal(10,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Buildings",
                type: "decimal(10,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)");
        }
    }
}
