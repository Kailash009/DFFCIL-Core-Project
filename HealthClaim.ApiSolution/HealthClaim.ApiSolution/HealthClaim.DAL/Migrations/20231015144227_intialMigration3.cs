using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class intialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpClaimStatus_ClaimTypes_ClaimId",
                table: "EmpClaimStatus");

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 12, 26, 854, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_ClaimTypeId",
                table: "EmpClaimStatus",
                column: "ClaimTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpClaimStatus_ClaimTypes_ClaimTypeId",
                table: "EmpClaimStatus",
                column: "ClaimTypeId",
                principalTable: "ClaimTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpClaimStatus_ClaimTypes_ClaimTypeId",
                table: "EmpClaimStatus");

            migrationBuilder.DropIndex(
                name: "IX_EmpClaimStatus_ClaimTypeId",
                table: "EmpClaimStatus");

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 20, 7, 21, 578, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.AddForeignKey(
                name: "FK_EmpClaimStatus_ClaimTypes_ClaimId",
                table: "EmpClaimStatus",
                column: "ClaimId",
                principalTable: "ClaimTypes",
                principalColumn: "Id");
        }
    }
}
