using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurora_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBikeBikeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BikeTypeId",
                table: "Bikes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bikes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_BikeTypeId",
                table: "Bikes",
                column: "BikeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_BikeTypes_BikeTypeId",
                table: "Bikes",
                column: "BikeTypeId",
                principalTable: "BikeTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_BikeTypes_BikeTypeId",
                table: "Bikes");

            migrationBuilder.DropIndex(
                name: "IX_Bikes_BikeTypeId",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "BikeTypeId",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bikes");
        }
    }
}
