using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDesk360.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStockSerialMovement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockSerialMovementType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSerialMovementType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockSerialMovement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSerialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSerialMovementTypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    CompanyProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FaultTypeId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSerialMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockSerialMovement_CompanyProduct_CompanyProductId",
                        column: x => x.CompanyProductId,
                        principalTable: "CompanyProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSerialMovement_FaultType_FaultTypeId",
                        column: x => x.FaultTypeId,
                        principalTable: "FaultType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSerialMovement_StockSerialMovementType_StockSerialMovementTypeId",
                        column: x => x.StockSerialMovementTypeId,
                        principalTable: "StockSerialMovementType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSerialMovement_StockSerial_StockSerialId",
                        column: x => x.StockSerialId,
                        principalTable: "StockSerial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSerialMovement_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSerialMovement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockSerialMovement_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockSerialMovement_CompanyProductId",
                table: "StockSerialMovement",
                column: "CompanyProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSerialMovement_FaultTypeId",
                table: "StockSerialMovement",
                column: "FaultTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSerialMovement_StockSerialId",
                table: "StockSerialMovement",
                column: "StockSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSerialMovement_StockSerialMovementTypeId",
                table: "StockSerialMovement",
                column: "StockSerialMovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSerialMovement_TicketId",
                table: "StockSerialMovement",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSerialMovement_UserId",
                table: "StockSerialMovement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSerialMovement_WarehouseId",
                table: "StockSerialMovement",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockSerialMovement");

            migrationBuilder.DropTable(
                name: "StockSerialMovementType");
        }
    }
}
