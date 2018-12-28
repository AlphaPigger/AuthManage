using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthManage.MVC.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Hardwares_HardwareID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_HardwareID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HardwareID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Record",
                table: "Items",
                newName: "CreateUser");

            migrationBuilder.AddColumn<string>(
                name: "CreateTime",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemBaseOnHardwares",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Record = table.Column<string>(nullable: true),
                    HardwareID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBaseOnHardwares", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemBaseOnHardwares_Hardwares_HardwareID",
                        column: x => x.HardwareID,
                        principalTable: "Hardwares",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemBaseOnHardwares_HardwareID",
                table: "ItemBaseOnHardwares",
                column: "HardwareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemBaseOnHardwares");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CreateUser",
                table: "Items",
                newName: "Record");

            migrationBuilder.AddColumn<int>(
                name: "HardwareID",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_HardwareID",
                table: "Items",
                column: "HardwareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Hardwares_HardwareID",
                table: "Items",
                column: "HardwareID",
                principalTable: "Hardwares",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
