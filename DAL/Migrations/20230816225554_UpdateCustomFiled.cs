using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class UpdateCustomFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CustomFieldDatas_CustomFieldDataId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomFieldDataId",
                table: "CustomFields");

            migrationBuilder.AlterColumn<int>(
                name: "CustomFieldDataId",
                table: "CustomFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomFieldDataId",
                table: "CustomFields",
                column: "CustomFieldDataId",
                unique: true,
                filter: "[CustomFieldDataId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CustomFieldDatas_CustomFieldDataId",
                table: "CustomFields",
                column: "CustomFieldDataId",
                principalTable: "CustomFieldDatas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_CustomFieldDatas_CustomFieldDataId",
                table: "CustomFields");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_CustomFieldDataId",
                table: "CustomFields");

            migrationBuilder.AlterColumn<int>(
                name: "CustomFieldDataId",
                table: "CustomFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_CustomFieldDataId",
                table: "CustomFields",
                column: "CustomFieldDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_CustomFieldDatas_CustomFieldDataId",
                table: "CustomFields",
                column: "CustomFieldDataId",
                principalTable: "CustomFieldDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
