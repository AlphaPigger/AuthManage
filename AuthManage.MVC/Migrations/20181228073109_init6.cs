using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthManage.MVC.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "ItemBaseOnHardwares");

            migrationBuilder.RenameColumn(
                name: "RecordItem",
                table: "Records",
                newName: "UpdateUser");

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Records",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateTime",
                table: "Records",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "UpdateUser",
                table: "Records",
                newName: "RecordItem");

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "ItemBaseOnHardwares",
                nullable: true);
        }
    }
}
