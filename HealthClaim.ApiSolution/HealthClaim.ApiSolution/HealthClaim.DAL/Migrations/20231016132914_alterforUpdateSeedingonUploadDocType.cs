using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterforUpdateSeedingonUploadDocType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5566));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.InsertData(
                table: "UplodDocType",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsBillable", "Name" },
                values: new object[,]
                {
                    { 10L, new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5629), "AdmissionAdviceUpload", true, true, "AdmissionAdviceUpload" },
                    { 11L, new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5632), "DischargeSummary", true, true, "DischargeSummary" },
                    { 12L, new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5634), "InvestigationReports", true, true, "InvestigationReports" },
                    { 13L, new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5636), "FinalHospitalBill", true, true, "FinalHospitalBill" },
                    { 14L, new DateTime(2023, 10, 16, 18, 59, 13, 935, DateTimeKind.Local).AddTicks(5638), "Diagnosis", true, true, "Diagnosis" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L);

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
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 17, 21, 36, 220, DateTimeKind.Local).AddTicks(9564));
        }
    }
}
