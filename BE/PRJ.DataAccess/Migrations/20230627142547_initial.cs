using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRJ.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARRIERS",
                columns: table => new
                {
                    carrier_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carrier_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    carrier_mode = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARRIERS", x => x.carrier_id);
                });

            migrationBuilder.CreateTable(
                name: "SHIPMENT_RATES",
                columns: table => new
                {
                    shipment_rate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shipment_rate_class = table.Column<string>(type: "varchar(10)", nullable: false),
                    shipment_rate_description = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPMENT_RATES", x => x.shipment_rate_id);
                });

            migrationBuilder.CreateTable(
                name: "SHIPPERS",
                columns: table => new
                {
                    shipper_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shipper_name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPERS", x => x.shipper_id);
                });

            migrationBuilder.CreateTable(
                name: "SHIPMENTS",
                columns: table => new
                {
                    shipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shipment_description = table.Column<string>(type: "varchar(100)", nullable: false),
                    shipment_weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    shipper_id = table.Column<int>(type: "int", nullable: false),
                    shipment_rate_id = table.Column<int>(type: "int", nullable: false),
                    carrier_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPMENTS", x => x.shipment_id);
                    table.ForeignKey(
                        name: "FK_SHIPMENTS_CARRIERS_carrier_id",
                        column: x => x.carrier_id,
                        principalTable: "CARRIERS",
                        principalColumn: "carrier_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHIPMENTS_SHIPMENT_RATES_shipment_rate_id",
                        column: x => x.shipment_rate_id,
                        principalTable: "SHIPMENT_RATES",
                        principalColumn: "shipment_rate_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SHIPMENTS_SHIPPERS_shipper_id",
                        column: x => x.shipper_id,
                        principalTable: "SHIPPERS",
                        principalColumn: "shipper_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENTS_carrier_id",
                table: "SHIPMENTS",
                column: "carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENTS_shipment_rate_id",
                table: "SHIPMENTS",
                column: "shipment_rate_id");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENTS_shipper_id",
                table: "SHIPMENTS",
                column: "shipper_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SHIPMENTS");

            migrationBuilder.DropTable(
                name: "CARRIERS");

            migrationBuilder.DropTable(
                name: "SHIPMENT_RATES");

            migrationBuilder.DropTable(
                name: "SHIPPERS");
        }
    }
}
