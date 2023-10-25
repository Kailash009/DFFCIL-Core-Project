using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class altertableEmpdAdvance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Claim_TypeId",
                table: "EmpAdvances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedDate", "IsBillable" },
                values: new object[] { new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9558), true });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9560));

            
            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_Claim_TypeId",
                table: "EmpAdvances",
                column: "Claim_TypeId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpAdvances_ClaimTypes_Claim_TypeId",
                table: "EmpAdvances");

            migrationBuilder.DropIndex(
                name: "IX_EmpAdvances_Claim_TypeId",
                table: "EmpAdvances");

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DropColumn(
                name: "Claim_TypeId",
                table: "EmpAdvances");

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedDate", "IsBillable" },
                values: new object[] { new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9503), false });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 15, 23, 21, 35, 876, DateTimeKind.Local).AddTicks(9504));
        }
    }
}
