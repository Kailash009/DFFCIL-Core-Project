using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTaxable",
                table: "EmployeeClaims",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxableByHr",
                table: "EmployeeClaims",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmpAdvanceTopId",
                table: "EmpClaimStatus",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment_5",
                table: "DoctorReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment_4",
                table: "DoctorReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment_3",
                table: "DoctorReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment_2",
                table: "DoctorReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment_1",
                table: "DoctorReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxable",
                table: "DoctorReviews",
                type: "bit",
                nullable: true);

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
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1087));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 18, 43, 605, DateTimeKind.Local).AddTicks(1088));

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_EmpAdvanceTopId",
                table: "EmpClaimStatus",
                column: "EmpAdvanceTopId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpClaimStatus_EmpAdvanceTopUp_EmpAdvanceTopId",
                table: "EmpClaimStatus",
                column: "EmpAdvanceTopId",
                principalTable: "EmpAdvanceTopUp",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpClaimStatus_EmpAdvanceTopUp_EmpAdvanceTopId",
                table: "EmpClaimStatus");

            migrationBuilder.DropIndex(
                name: "IX_EmpClaimStatus_EmpAdvanceTopId",
                table: "EmpClaimStatus");

            migrationBuilder.DropColumn(
                name: "IsTaxable",
                table: "EmployeeClaims");

            migrationBuilder.DropColumn(
                name: "IsTaxableByHr",
                table: "EmployeeClaims");

            migrationBuilder.DropColumn(
                name: "EmpAdvanceTopId",
                table: "EmpClaimStatus");

            migrationBuilder.DropColumn(
                name: "IsTaxable",
                table: "DoctorReviews");

            migrationBuilder.AlterColumn<bool>(
                name: "Comment_5",
                table: "DoctorReviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Comment_4",
                table: "DoctorReviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Comment_3",
                table: "DoctorReviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Comment_2",
                table: "DoctorReviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Comment_1",
                table: "DoctorReviews",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1176));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1185));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 20, 16, 13, 40, 112, DateTimeKind.Local).AddTicks(1196));
        }
    }
}
