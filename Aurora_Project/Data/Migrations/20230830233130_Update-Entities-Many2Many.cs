using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aurora_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesMany2Many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeOrder",
                columns: table => new
                {
                    BikesId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeOrder", x => new { x.BikesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_BikeOrder_Bikes_BikesId",
                        column: x => x.BikesId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BikeOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikeOrder_OrdersId",
                table: "BikeOrder",
                column: "OrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeOrder");
        }
    }
}
