using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSchemaConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Turbidity",
                table: "WaterTreatmentPlants",
                type: "decimal(8,3)",
                precision: 8,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceArea",
                table: "WaterTreatmentPlants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LName",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StreetSuffix",
                table: "Buildings",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Buildings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceArea",
                table: "Buildings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Buildings",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Buildings",
                type: "decimal(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "KingdomName",
                table: "Buildings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Buildings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BuildingType",
                table: "Buildings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_WaterTreatmentPlants_Turbidity_NonNegative",
                table: "WaterTreatmentPlants",
                sql: "[Turbidity] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_WaterTreatmentPlants_WaterVolumeCapacity_Positive",
                table: "WaterTreatmentPlants",
                sql: "[WaterVolumeCapacity] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_WaterMeters_MeterReading_NonNegative",
                table: "WaterMeters",
                sql: "[MeterReading] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Buildings_StreetNum_Positive",
                table: "Buildings",
                sql: "[StreetNum] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Buildings_ZipCode_Range",
                table: "Buildings",
                sql: "[ZipCode] >= 0 AND [ZipCode] <= 99999");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Billings_PriceRate_NonNegative",
                table: "Billings",
                sql: "[PriceRate] >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Billings_TotalAmountDue_NonNegative",
                table: "Billings",
                sql: "[TotalAmountDue] >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_WaterTreatmentPlants_Turbidity_NonNegative",
                table: "WaterTreatmentPlants");

            migrationBuilder.DropCheckConstraint(
                name: "CK_WaterTreatmentPlants_WaterVolumeCapacity_Positive",
                table: "WaterTreatmentPlants");

            migrationBuilder.DropCheckConstraint(
                name: "CK_WaterMeters_MeterReading_NonNegative",
                table: "WaterMeters");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Buildings_StreetNum_Positive",
                table: "Buildings");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Buildings_ZipCode_Range",
                table: "Buildings");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Billings_PriceRate_NonNegative",
                table: "Billings");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Billings_TotalAmountDue_NonNegative",
                table: "Billings");

            migrationBuilder.AlterColumn<decimal>(
                name: "Turbidity",
                table: "WaterTreatmentPlants",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,3)",
                oldPrecision: 8,
                oldScale: 3);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceArea",
                table: "WaterTreatmentPlants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "StreetSuffix",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceArea",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Buildings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)",
                oldPrecision: 9,
                oldScale: 6);

            migrationBuilder.AlterColumn<string>(
                name: "KingdomName",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "BuildingType",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
