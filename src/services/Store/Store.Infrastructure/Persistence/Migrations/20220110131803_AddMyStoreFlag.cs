using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Infrastructure.Persistence.Migrations
{
    public partial class AddMyStoreFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMyStore",
                table: "Stores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMyStore",
                table: "Stores");
        }
    }
}
