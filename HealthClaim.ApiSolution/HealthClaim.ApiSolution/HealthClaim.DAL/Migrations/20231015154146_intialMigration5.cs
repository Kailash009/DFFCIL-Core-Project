using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class intialMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimStatusCategory_Employees_CreatedBy",
                table: "ClaimStatusCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimStatusCategory_Employees_UpdatedBy",
                table: "ClaimStatusCategory");

            migrationBuilder.DropIndex(
                name: "IX_ClaimStatusCategory_CreatedBy",
                table: "ClaimStatusCategory");

            migrationBuilder.DropIndex(
                name: "IX_ClaimStatusCategory_UpdatedBy",
                table: "ClaimStatusCategory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClaimStatusCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClaimStatusCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ClaimStatusCategory");

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 21, 11, 45, 694, DateTimeKind.Local).AddTicks(1908));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "ClaimStatusCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "ClaimStatusCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ClaimStatusCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 37, 8, 182, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusCategory_CreatedBy",
                table: "ClaimStatusCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusCategory_UpdatedBy",
                table: "ClaimStatusCategory",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimStatusCategory_Employees_CreatedBy",
                table: "ClaimStatusCategory",
                column: "CreatedBy",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimStatusCategory_Employees_UpdatedBy",
                table: "ClaimStatusCategory",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
