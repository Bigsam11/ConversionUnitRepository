using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConversionService.Core.Migrations
{
    public partial class MyConversionService1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDIT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    API = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RequestObject = table.Column<string>(type: "text", nullable: false),
                    ResponseObject = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONVERSIONACTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitCategory = table.Column<int>(type: "integer", nullable: false),
                    UnitNameOfOrigin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UnitNameOfDestination = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    valueToConvert = table.Column<float>(type: "real", nullable: false),
                    ValuePerUnit = table.Column<float>(type: "real", nullable: false),
                    ValueResult = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONVERSIONACTION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONVERSIONACTION_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONVERSIONUNIT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitCategory = table.Column<int>(type: "integer", nullable: false),
                    UnitNameOfOrigin = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UnitNameOfDestination = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ValuePerUnit = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONVERSIONUNIT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONVERSIONUNIT_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONVERSIONACTION_UserId",
                table: "CONVERSIONACTION",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CONVERSIONUNIT_UserId",
                table: "CONVERSIONUNIT",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT");

            migrationBuilder.DropTable(
                name: "CONVERSIONACTION");

            migrationBuilder.DropTable(
                name: "CONVERSIONUNIT");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
