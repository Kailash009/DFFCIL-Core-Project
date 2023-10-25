using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClaim.DAL.Migrations
{
    public partial class intialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeavingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpRelations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRelations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UplodDocType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBillable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UplodDocType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimStatusCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatusCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimStatusCategory_ClaimTypes_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimStatusCategory_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClaimStatusCategory_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpAccountDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IfscCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAccountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAccountDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAccountDetails_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAccountDetails_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSpecailDisease = table.Column<bool>(type: "bit", nullable: true),
                    HospitalTotalBill = table.Column<double>(type: "float", nullable: true),
                    ClaimRequetsDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClaimAmount = table.Column<double>(type: "float", nullable: true),
                    ClaimApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClaimApprovedAmount = table.Column<double>(type: "float", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeClaims_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeClaims_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    OrgPrimaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgUnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WrapperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostAssignedInWrapperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostAssignedInOrgUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarkingAbbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpLavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    ApplicabelDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportingOfficerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_ReportingOfficerId",
                        column: x => x.ReportingOfficerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpProfiles_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrgClaimLimits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    ApplicableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicableYear = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgClaimLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgClaimLimits_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgClaimLimits_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationId = table.Column<long>(type: "bigint", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFamilys_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpFamilys_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilys_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilys_EmpRelations_RelationId",
                        column: x => x.RelationId,
                        principalTable: "EmpRelations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UploadTypeDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UploadTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadTypeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadTypeDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadTypeDetails_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadTypeDetails_UplodDocType_UploadTypeId",
                        column: x => x.UploadTypeId,
                        principalTable: "UplodDocType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorReviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    AddmisionAdviseComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DischargeSummaryComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationReportComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSpecialDisease = table.Column<bool>(type: "bit", nullable: false),
                    Comment_1 = table.Column<bool>(type: "bit", nullable: true),
                    Comment_2 = table.Column<bool>(type: "bit", nullable: true),
                    Comment_3 = table.Column<bool>(type: "bit", nullable: true),
                    Comment_4 = table.Column<bool>(type: "bit", nullable: true),
                    Comment_5 = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReviews_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorReviews_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorReviews_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpClaimStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimTypeId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpClaimStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_ClaimStatusCategory_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ClaimStatusCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_ClaimTypes_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "ClaimTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimStatus_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeClaimBills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpClaimId = table.Column<long>(type: "bigint", nullable: false),
                    EmpId = table.Column<long>(type: "bigint", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    HospitalCompleteBill = table.Column<double>(type: "float", nullable: false),
                    MedicineBill = table.Column<double>(type: "float", nullable: false),
                    ConsultationBill = table.Column<double>(type: "float", nullable: false),
                    InvestigationBill = table.Column<double>(type: "float", nullable: false),
                    RoomRentBill = table.Column<double>(type: "float", nullable: false),
                    OthersBill = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeClaimBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_ClaimStatusCategory_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ClaimStatusCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_EmployeeClaims_EmpClaimId",
                        column: x => x.EmpClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeClaimBills_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpAdvances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmplId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    RequestSubmittedById = table.Column<long>(type: "bigint", nullable: false),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    RequestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvanceRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvanceAmount = table.Column<double>(type: "float", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAmount = table.Column<double>(type: "float", nullable: false),
                    ApprovedById = table.Column<long>(type: "bigint", nullable: true),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalRegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedAmount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAdvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpAdvances_EmpFamilys_PatientId",
                        column: x => x.PatientId,
                        principalTable: "EmpFamilys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpAdvances_EmployeeClaims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "EmployeeClaims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_EmplId",
                        column: x => x.EmplId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_RequestSubmittedById",
                        column: x => x.RequestSubmittedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpAdvances_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilyITRs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<long>(type: "bigint", nullable: false),
                    DocType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinancialYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountingYear = table.Column<long>(type: "bigint", nullable: false),
                    AnnualIncome = table.Column<double>(type: "float", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilyITRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFamilyITRs_EmpFamilys_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "EmpFamilys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpFamilyITRs_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilyITRs_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmpFamilyPANs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<long>(type: "bigint", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpFamilyPANs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpFamilyPANs_EmpFamilys_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "EmpFamilys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpFamilyPANs_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpFamilyPANs_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdvanceUploadClarificationforTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceUploadTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Clarification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    RecipientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvanceUploadClarificationforTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvanceUploadClarificationforTypes_UploadTypeDetails_AdvanceUploadTypeId",
                        column: x => x.AdvanceUploadTypeId,
                        principalTable: "UploadTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceUploadTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadDocuments_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadDocuments_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UploadDocuments_UploadTypeDetails_AdvanceUploadTypeId",
                        column: x => x.AdvanceUploadTypeId,
                        principalTable: "UploadTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpClaimNotInMailBills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpClaimBillId = table.Column<long>(type: "bigint", nullable: false),
                    BillType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpClaimNotInMailBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMailBills_EmployeeClaimBills_EmpClaimBillId",
                        column: x => x.EmpClaimBillId,
                        principalTable: "EmployeeClaimBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMailBills_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmpClaimNotInMailBills_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HospitalAccountDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpAdvanceId = table.Column<long>(type: "bigint", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IfscCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalAccountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalAccountDetails_EmpAdvances_EmpAdvanceId",
                        column: x => x.EmpAdvanceId,
                        principalTable: "EmpAdvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalAccountDetails_Employees_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HospitalAccountDetails_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ClaimTypes",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3187), "Advance", true, "Advance" },
                    { 2L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3197), "AdvanceClaim", true, "Advance Claim" },
                    { 3L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3198), "DirectClaim", true, "Direct Claim" }
                });

            migrationBuilder.InsertData(
                table: "EmpRelations",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3373), "Father", true, "Father" },
                    { 2L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3375), "Mother", true, "Mother" },
                    { 3L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3376), "Son", true, "Son" },
                    { 4L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3377), "Daughter", true, "Daughter" },
                    { 5L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3378), "Husband", true, "Husband" },
                    { 6L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3379), "Spouse", true, "Spouse" }
                });

            migrationBuilder.InsertData(
                table: "UplodDocType",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsBillable", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3404), "Medicine", true, true, "Medicine" },
                    { 2L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3406), "Medicine not in Final bill", true, true, "Medicine not in Final bill" },
                    { 3L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3407), "Consultation", true, true, "Consultation" },
                    { 4L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3408), "Room Rent", true, true, "Room Rent" },
                    { 5L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3409), "Investigation", true, false, "Investigation" },
                    { 6L, new DateTime(2023, 10, 15, 16, 5, 53, 907, DateTimeKind.Local).AddTicks(3410), "Other", true, true, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_AdvanceUploadTypeId",
                table: "AdvanceUploadClarificationforTypes",
                column: "AdvanceUploadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_CreatedBy",
                table: "AdvanceUploadClarificationforTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_RecipientId",
                table: "AdvanceUploadClarificationforTypes",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_SenderId",
                table: "AdvanceUploadClarificationforTypes",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvanceUploadClarificationforTypes_UpdatedBy",
                table: "AdvanceUploadClarificationforTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpId",
                table: "AspNetUsers",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusCategory_ClaimTypeId",
                table: "ClaimStatusCategory",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusCategory_CreatedBy",
                table: "ClaimStatusCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusCategory_UpdatedBy",
                table: "ClaimStatusCategory",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_ClaimId",
                table: "DoctorReviews",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_CreatedBy",
                table: "DoctorReviews",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReviews_UpdatedBy",
                table: "DoctorReviews",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAccountDetails_CreatedBy",
                table: "EmpAccountDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAccountDetails_EmpId",
                table: "EmpAccountDetails",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAccountDetails_UpdatedBy",
                table: "EmpAccountDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_ApprovedById",
                table: "EmpAdvances",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_ClaimId",
                table: "EmpAdvances",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_CreatedBy",
                table: "EmpAdvances",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_EmplId",
                table: "EmpAdvances",
                column: "EmplId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_PatientId",
                table: "EmpAdvances",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_RequestSubmittedById",
                table: "EmpAdvances",
                column: "RequestSubmittedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmpAdvances_UpdatedBy",
                table: "EmpAdvances",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMailBills_CreatedBy",
                table: "EmpClaimNotInMailBills",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMailBills_EmpClaimBillId",
                table: "EmpClaimNotInMailBills",
                column: "EmpClaimBillId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimNotInMailBills_UpdatedBy",
                table: "EmpClaimNotInMailBills",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_ClaimId",
                table: "EmpClaimStatus",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_CreatedBy",
                table: "EmpClaimStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_StatusId",
                table: "EmpClaimStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpClaimStatus_UpdatedBy",
                table: "EmpClaimStatus",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyITRs_CreatedBy",
                table: "EmpFamilyITRs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyITRs_FamilyId",
                table: "EmpFamilyITRs",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyITRs_UpdatedBy",
                table: "EmpFamilyITRs",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyPANs_CreatedBy",
                table: "EmpFamilyPANs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyPANs_FamilyId",
                table: "EmpFamilyPANs",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilyPANs_UpdatedBy",
                table: "EmpFamilyPANs",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_CreatedBy",
                table: "EmpFamilys",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_EmpId",
                table: "EmpFamilys",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_RelationId",
                table: "EmpFamilys",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpFamilys_UpdatedBy",
                table: "EmpFamilys",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_CreatedBy",
                table: "EmployeeClaimBills",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_EmpClaimId",
                table: "EmployeeClaimBills",
                column: "EmpClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_EmpId",
                table: "EmployeeClaimBills",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_StatusId",
                table: "EmployeeClaimBills",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaimBills_UpdatedBy",
                table: "EmployeeClaimBills",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaims_CreatedBy",
                table: "EmployeeClaims",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeClaims_UpdatedBy",
                table: "EmployeeClaims",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UpdatedBy",
                table: "Employees",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_CreatedBy",
                table: "EmpProfiles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_EmpId",
                table: "EmpProfiles",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_ReportingOfficerId",
                table: "EmpProfiles",
                column: "ReportingOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpProfiles_UpdatedBy",
                table: "EmpProfiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAccountDetails_CreatedBy",
                table: "HospitalAccountDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAccountDetails_EmpAdvanceId",
                table: "HospitalAccountDetails",
                column: "EmpAdvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAccountDetails_UpdatedBy",
                table: "HospitalAccountDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_CreatedBy",
                table: "OrgClaimLimits",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrgClaimLimits_UpdatedBy",
                table: "OrgClaimLimits",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_AdvanceUploadTypeId",
                table: "UploadDocuments",
                column: "AdvanceUploadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_CreatedBy",
                table: "UploadDocuments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadDocuments_UpdatedBy",
                table: "UploadDocuments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_CreatedBy",
                table: "UploadTypeDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_UpdatedBy",
                table: "UploadTypeDetails",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UploadTypeDetails_UploadTypeId",
                table: "UploadTypeDetails",
                column: "UploadTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvanceUploadClarificationforTypes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DoctorReviews");

            migrationBuilder.DropTable(
                name: "EmpAccountDetails");

            migrationBuilder.DropTable(
                name: "EmpClaimNotInMailBills");

            migrationBuilder.DropTable(
                name: "EmpClaimStatus");

            migrationBuilder.DropTable(
                name: "EmpFamilyITRs");

            migrationBuilder.DropTable(
                name: "EmpFamilyPANs");

            migrationBuilder.DropTable(
                name: "EmpProfiles");

            migrationBuilder.DropTable(
                name: "HospitalAccountDetails");

            migrationBuilder.DropTable(
                name: "OrgClaimLimits");

            migrationBuilder.DropTable(
                name: "UploadDocuments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EmployeeClaimBills");

            migrationBuilder.DropTable(
                name: "EmpAdvances");

            migrationBuilder.DropTable(
                name: "UploadTypeDetails");

            migrationBuilder.DropTable(
                name: "ClaimStatusCategory");

            migrationBuilder.DropTable(
                name: "EmpFamilys");

            migrationBuilder.DropTable(
                name: "EmployeeClaims");

            migrationBuilder.DropTable(
                name: "UplodDocType");

            migrationBuilder.DropTable(
                name: "ClaimTypes");

            migrationBuilder.DropTable(
                name: "EmpRelations");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
