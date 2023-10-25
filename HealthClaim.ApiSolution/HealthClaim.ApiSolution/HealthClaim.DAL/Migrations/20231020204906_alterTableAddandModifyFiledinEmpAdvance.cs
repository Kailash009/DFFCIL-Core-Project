using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterTableAddandModifyFiledinEmpAdvance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Declaration",
                table: "EmpAdvances",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1050));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(754));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(857));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(875));

            migrationBuilder.InsertData(
                table: "UplodDocType",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsBillable", "Name" },
                values: new object[,]
                {
                    { 21L, new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(927), "HospitalRegstrationDetailsFile", true, true, "HospitalRegstrationDetailsFile" },
                    { 22L, new DateTime(2023, 10, 20, 13, 49, 5, 301, DateTimeKind.Local).AddTicks(932), "HospitalIncomeTaxFile", true, true, "HospitalIncomeTaxFile" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DropColumn(
                name: "Declaration",
                table: "EmpAdvances");

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1736));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 11, 10, 53, 942, DateTimeKind.Local).AddTicks(1743));
        }
    }
}
