using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthManage.MVC.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Projects_ProjectID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ProjectID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Hardware",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Hardware_Detail",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Hardware_Status",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Software",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Software_Detail",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Software_Status",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TempterTest",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TempterTest_Detail",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TempterTest_Status",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Test_Status",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Test_Detail",
                table: "Items",
                newName: "Record");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Items",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "CreateTime",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HardwareID",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hardwares",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<string>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    ProjectID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardwares", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hardwares_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_HardwareID",
                table: "Items",
                column: "HardwareID");

            migrationBuilder.CreateIndex(
                name: "IX_Hardwares_ProjectID",
                table: "Hardwares",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Hardwares_HardwareID",
                table: "Items",
                column: "HardwareID",
                principalTable: "Hardwares",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Hardwares_HardwareID",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Hardwares");

            migrationBuilder.DropIndex(
                name: "IX_Items_HardwareID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "HardwareID",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Items",
                newName: "ProjectID");

            migrationBuilder.RenameColumn(
                name: "Record",
                table: "Items",
                newName: "Test_Detail");

            migrationBuilder.AddColumn<string>(
                name: "Hardware",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hardware_Detail",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Hardware_Status",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Software",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Software_Detail",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Software_Status",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TempterTest",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TempterTest_Detail",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TempterTest_Status",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Test_Status",
                table: "Items",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProjectID",
                table: "Items",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Projects_ProjectID",
                table: "Items",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
