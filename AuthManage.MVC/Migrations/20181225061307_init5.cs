using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthManage.MVC.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Record",
                table: "ItemBaseOnHardwares",
                newName: "Remark");

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecordItem = table.Column<string>(nullable: true),
                    ItemBaseOnHardwareID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Records_ItemBaseOnHardwares_ItemBaseOnHardwareID",
                        column: x => x.ItemBaseOnHardwareID,
                        principalTable: "ItemBaseOnHardwares",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_ItemBaseOnHardwareID",
                table: "Records",
                column: "ItemBaseOnHardwareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "ItemBaseOnHardwares",
                newName: "Record");
        }
    }
}
