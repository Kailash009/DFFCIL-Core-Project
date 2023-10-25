using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class addNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpAdvanceTopUp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpAdvanceId = table.Column<long>(type: "bigint", nullable: false),
                    ReviseEstimentedAmount = table.Column<double>(type: "float", nullable: false),
                    TopRequiredAmount = table.Column<double>(type: "float", nullable: false),
                    TopApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    PayTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IfscCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAdvanceTopUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_EmpAdvances_EmpAdvanceId",
                        column: x => x.EmpAdvanceId,
                        principalTable: "EmpAdvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUp_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpAdvanceTopUpUpload",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpAdvanceTopUpId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAdvanceTopUpUpload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUpUpload_EmpAdvanceTopUp_EmpAdvanceTopUpId",
                        column: x => x.EmpAdvanceTopUpId,
                        principalTable: "EmpAdvanceTopUp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUpUpload_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvanceTopUpUpload_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_ApprovedById",
                table: "EmpAdvanceTopUp",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_CreatedBy",
                table: "EmpAdvanceTopUp",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_EmpAdvanceId",
                table: "EmpAdvanceTopUp",
                column: "EmpAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUp_UpdatedBy",
                table: "EmpAdvanceTopUp",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUpUpload_CreatedBy",
                table: "EmpAdvanceTopUpUpload",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUpUpload_EmpAdvanceTopUpId",
                table: "EmpAdvanceTopUpUpload",
                column: "EmpAdvanceTopUpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvanceTopUpUpload_UpdatedBy",
                table: "EmpAdvanceTopUpUpload",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpAdvanceTopUpUpload");

            migrationBuilder.DropTable(
                name: "EmpAdvanceTopUp");

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "ClaimTypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "EmpRelations",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 16L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 17L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 18L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "UplodDocType",
                keyColumn: "Id",
                keyValue: 19L,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 19, 13, 5, 34, 452, DateTimeKind.Local).AddTicks(2529));
        }
    }
}
