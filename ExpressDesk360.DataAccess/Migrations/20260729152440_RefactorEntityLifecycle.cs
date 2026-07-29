using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressDesk360.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntityLifecycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "WarrantyType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "WarrantyType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "UserFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserFile");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserContact");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "UserContact");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserContact");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TicketStaff");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "TicketStaff");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketStaff");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TicketMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "TicketMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TicketMovementFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "TicketMovementFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketMovementFile");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TicketMessageFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "TicketMessageFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketMessageFile");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TicketFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "TicketFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketFile");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockTypeGroupMap");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockTypeGroupMap");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockTypeGroupMap");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockSerial");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockSerial");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockMovementStockSerialMap");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockMovementStockSerialMap");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockMovementStockSerialMap");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockGroupFaultTypeMap");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockGroupFaultTypeMap");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockGroupFaultTypeMap");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockGroupBrandMap");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockGroupBrandMap");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockGroupBrandMap");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockGroup");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockGroup");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockBrand");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "StockBrand");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ShippingType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "ShippingType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ShippingFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "ShippingFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShippingFile");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ProjectStaff");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "ProjectStaff");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectStaff");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ProjectMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "ProjectMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ProjectFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "ProjectFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectFile");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "InvoiceType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "InvoiceType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "FS_Folder");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "FS_Folder");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FS_Folder");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "FS_File");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "FS_File");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FS_File");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "FaultType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "FaultType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ContactType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "ContactType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CompanyProductStockSerialMap");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "CompanyProductStockSerialMap");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyProductStockSerialMap");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CompanyFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "CompanyFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyFile");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CompanyContact");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "CompanyContact");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompanyContact");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CargoCompany");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "CargoCompany");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "_TaskStaff");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "_TaskStaff");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "_TaskStaff");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "_TaskMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "_TaskMovementType");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "_TaskFile");

            migrationBuilder.DropColumn(
                name: "DeletedDateUtc",
                table: "_TaskFile");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "_TaskFile");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "WarrantyType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Warehouse",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "User",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Unit",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "TicketType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "TicketMovementType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StockType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StockSerial",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StockMovementType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StockGroup",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StockBrand",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Stock",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ShippingType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProjectMovementType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "InvoiceType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "FaultType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Currency",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ContactType",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Company",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "CargoCompany",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "_TaskMovementType",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StockSerialMovementType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StockSerialMovementType");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "WarrantyType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Warehouse",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "User",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Unit",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TicketType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TicketMovementType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "StockType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "StockSerial",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "StockMovementType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "StockGroup",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "StockBrand",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Stock",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ShippingType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ProjectMovementType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "InvoiceType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "FaultType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Currency",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ContactType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Company",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "CargoCompany",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "_TaskMovementType",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "WarrantyType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "WarrantyType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "Warehouse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "UserFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "UserFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "UserContact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "UserContact",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserContact",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Unit",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "Unit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TicketType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "TicketType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TicketStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "TicketStaff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketStaff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TicketMovementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "TicketMovementType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TicketMovementFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "TicketMovementFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketMovementFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TicketMessageFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "TicketMessageFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketMessageFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TicketFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "TicketFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockTypeGroupMap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockTypeGroupMap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockTypeGroupMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockSerial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockSerial",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockMovementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockMovementType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockMovementStockSerialMap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockMovementStockSerialMap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockMovementStockSerialMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockGroupFaultTypeMap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockGroupFaultTypeMap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockGroupFaultTypeMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockGroupBrandMap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockGroupBrandMap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockGroupBrandMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockGroup",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "StockBrand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "StockBrand",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "Stock",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ShippingType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "ShippingType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ShippingFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "ShippingFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShippingFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ProjectStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "ProjectStaff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectStaff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ProjectMovementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "ProjectMovementType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ProjectFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "ProjectFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "InvoiceType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "InvoiceType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "FS_Folder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "FS_Folder",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FS_Folder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "FS_File",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "FS_File",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FS_File",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "FaultType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "FaultType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "Currency",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ContactType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "ContactType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CompanyProductStockSerialMap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "CompanyProductStockSerialMap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyProductStockSerialMap",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CompanyFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "CompanyFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CompanyContact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "CompanyContact",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompanyContact",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "Company",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CargoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "CargoCompany",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "_TaskStaff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "_TaskStaff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "_TaskStaff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "_TaskMovementType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "_TaskMovementType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "_TaskFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDateUtc",
                table: "_TaskFile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "_TaskFile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });

            migrationBuilder.UpdateData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeletedBy", "DeletedDateUtc", "IsDeleted" },
                values: new object[] { null, null, false });
        }
    }
}
