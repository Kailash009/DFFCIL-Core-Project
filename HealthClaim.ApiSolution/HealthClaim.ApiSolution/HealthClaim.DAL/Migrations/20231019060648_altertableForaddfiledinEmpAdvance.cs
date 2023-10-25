using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class altertableForaddfiledinEmpAdvance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinalHospitalBill",
                table: "EmpAdvances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7791));

            //migrationBuilder.InsertData(
            //    table: "UplodDocType",
            //    columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsBillable", "Name" },
            //    values: new object[,]
            //    {
            //        { 15L, new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7792), "PreHospitalizationExpensesMedicine", true, true, "PreHospitalizationExpensesMedicine" },
            //        { 16L, new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7793), "PreHospitalizationExpensesInvestigation", true, true, "PreHospitalizationExpensesInvestigation" },
            //        { 17L, new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7794), "PreHospitalizationExpensesOther", true, true, "PreHospitalizationExpensesOther" },
            //        { 18L, new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7795), "EstimateAmount", true, true, "EstimateAmount" },
            //        { 19L, new DateTime(2023, 10, 19, 11, 36, 47, 765, DateTimeKind.Local).AddTicks(7869), "PreHospitalizationExpensesConsultation", true, true, "PreHospitalizationExpensesConsultation" }
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DropColumn(
                name: "FinalHospitalBill",
                table: "EmpAdvances");

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9555));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 22, 43, 30, 220, DateTimeKind.Local).AddTicks(9782));
        }
    }
}
