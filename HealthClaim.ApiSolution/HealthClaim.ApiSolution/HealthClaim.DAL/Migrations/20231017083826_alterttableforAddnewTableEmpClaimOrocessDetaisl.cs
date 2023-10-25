using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class alterttableforAddnewTableEmpClaimOrocessDetaisl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ApprovedAmount",
                table: "EmpAdvances",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovalDate",
                table: "EmpAdvances",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "EmpClaimProcessDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpClaimProcessDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_Employees_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimProcessDetails_Employees_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(6833));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7103));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7174));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7176));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 17, 14, 8, 26, 310, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_ClaimId",
                table: "EmpClaimProcessDetails",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_ClaimTypeId",
                table: "EmpClaimProcessDetails",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_CreatedBy",
                table: "EmpClaimProcessDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_RecipientId",
                table: "EmpClaimProcessDetails",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimProcessDetails_SenderId",
                table: "EmpClaimProcessDetails",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpClaimProcessDetails");

            migrationBuilder.AlterColumn<double>(
                name: "ApprovedAmount",
                table: "EmpAdvances",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovalDate",
                table: "EmpAdvances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 16, 20, 24, 19, 43, DateTimeKind.Local).AddTicks(5304));
        }
    }
}
