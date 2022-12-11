using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversionService.Core.Migrations
{
    public partial class MyConversionService2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CONVERSIONACTION_user_UserId",
                table: "CONVERSIONACTION");

            migrationBuilder.DropForeignKey(
                name: "FK_CONVERSIONUNIT_user_UserId",
                table: "CONVERSIONUNIT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CONVERSIONUNIT",
                table: "CONVERSIONUNIT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CONVERSIONACTION",
                table: "CONVERSIONACTION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AUDIT",
                table: "AUDIT");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "CONVERSIONUNIT",
                newName: "ConversionUnit");

            migrationBuilder.RenameTable(
                name: "CONVERSIONACTION",
                newName: "ConversionAction");

            migrationBuilder.RenameTable(
                name: "AUDIT",
                newName: "Audit");

            migrationBuilder.RenameIndex(
                name: "IX_CONVERSIONUNIT_UserId",
                table: "ConversionUnit",
                newName: "IX_ConversionUnit_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CONVERSIONACTION_UserId",
                table: "ConversionAction",
                newName: "IX_ConversionAction_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversionUnit",
                table: "ConversionUnit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversionAction",
                table: "ConversionAction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audit",
                table: "Audit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversionAction_User_UserId",
                table: "ConversionAction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversionUnit_User_UserId",
                table: "ConversionUnit",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversionAction_User_UserId",
                table: "ConversionAction");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversionUnit_User_UserId",
                table: "ConversionUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversionUnit",
                table: "ConversionUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversionAction",
                table: "ConversionAction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audit",
                table: "Audit");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "ConversionUnit",
                newName: "CONVERSIONUNIT");

            migrationBuilder.RenameTable(
                name: "ConversionAction",
                newName: "CONVERSIONACTION");

            migrationBuilder.RenameTable(
                name: "Audit",
                newName: "AUDIT");

            migrationBuilder.RenameIndex(
                name: "IX_ConversionUnit_UserId",
                table: "CONVERSIONUNIT",
                newName: "IX_CONVERSIONUNIT_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversionAction_UserId",
                table: "CONVERSIONACTION",
                newName: "IX_CONVERSIONACTION_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONVERSIONUNIT",
                table: "CONVERSIONUNIT",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CONVERSIONACTION",
                table: "CONVERSIONACTION",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AUDIT",
                table: "AUDIT",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CONVERSIONACTION_user_UserId",
                table: "CONVERSIONACTION",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CONVERSIONUNIT_user_UserId",
                table: "CONVERSIONUNIT",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
