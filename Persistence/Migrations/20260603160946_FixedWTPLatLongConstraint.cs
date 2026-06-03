using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixedWTPLatLongConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "WaterTreatmentPlants",
                type: "decimal(10,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "WaterTreatmentPlants",
                type: "decimal(10,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "WaterTreatmentPlants",
                type: "decimal(7,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "WaterTreatmentPlants",
                type: "decimal(7,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,5)");
        }
    }
}
