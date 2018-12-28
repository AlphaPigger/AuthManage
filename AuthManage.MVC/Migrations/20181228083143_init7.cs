using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthManage.MVC.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "ItemBaseOnHardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateTime",
                table: "ItemBaseOnHardwares",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "ItemBaseOnHardwares",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "ItemBaseOnHardwares");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "ItemBaseOnHardwares");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "ItemBaseOnHardwares");
        }
    }
}
