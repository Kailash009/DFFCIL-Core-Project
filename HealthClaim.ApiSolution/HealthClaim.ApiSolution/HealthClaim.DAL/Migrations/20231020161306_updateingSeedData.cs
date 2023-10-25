using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class updateingSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "ClaimStatusCategory",
            //    columns: new[] { "Id", "ClaimTypeId", "CreatedDate", "Description", "IsActive", "Name" },
            //    values: new object[,]
            //    {
            //        { 1L, 1L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6166), "Claim Initiated", true, "Claim Initiated" },
            //        { 2L, 1L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6168), "Approved", true, "Approved" },
            //        { 3L, 1L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6170), "HR Processing", true, "HR Processing" },
            //        { 4L, 1L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6171), "Finance processing", true, "Finance processing" },
            //        { 5L, 1L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6172), "Under Doctor Processing", true, "Under Doctor Processing" },
            //        { 6L, 1L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6173), "Rejected", true, "Rejected" },
            //        { 7L, 2L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6174), "Claim Initiated", true, "Claim Initiated" },
            //        { 8L, 2L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6175), "Approved", true, "Approved" },
            //        { 9L, 2L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6177), "HR Processing", true, "HR Processing" },
            //        { 10L, 2L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6178), "Finance processing", true, "Finance processing" },
            //        { 12L, 2L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6179), "Under Doctor Processing", true, "Under Doctor Processing" },
            //        { 13L, 2L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6180), "Rejected", true, "Rejected" },
            //        { 14L, 3L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6181), "Claim Initiated", true, "Claim Initiated" },
            //        { 15L, 3L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6183), "Approved", true, "Approved" },
            //        { 16L, 3L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6184), "HR Processing", true, "HR Processing" },
            //        { 17L, 3L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6185), "Finance processing", true, "Finance processing" },
            //        { 18L, 3L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6186), "Under Doctor Processing", true, "Under Doctor Processing" },
            //        { 19L, 3L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6187), "Rejected", true, "Rejected" }
            //    });

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.InsertData(
                table: "ClaimTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[] { 4L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(5859), "Top Up Amount", true, "Top Up Amount" });

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6089));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6096));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6103));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6104), "PreHospitalizationExpensesConsultation", "PreHospitalizationExpensesConsultation" });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6105), "PreHospitalizationExpensesInvestigation", "PreHospitalizationExpensesInvestigation" });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6107), "PreHospitalizationExpensesOther", "PreHospitalizationExpensesOther" });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6108), "EstimateAmount", "EstimateAmount" });

            migrationBuilder.InsertData(
                table: "UplodDocType",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsBillable", "Name" },
                values: new object[] { 20L, new DateTime(2023, 10, 20, 21, 43, 5, 127, DateTimeKind.Local).AddTicks(6124), "ReviseEstimateFile", true, true, "ReviseEstimateFile" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "ClaimStatusCategory",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1085), "PreHospitalizationExpensesInvestigation", "PreHospitalizationExpensesInvestigation" });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1086), "PreHospitalizationExpensesOther", "PreHospitalizationExpensesOther" });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1087), "EstimateAmount", "EstimateAmount" });

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1088), "PreHospitalizationExpensesConsultation", "PreHospitalizationExpensesConsultation" });
        }
    }
}
