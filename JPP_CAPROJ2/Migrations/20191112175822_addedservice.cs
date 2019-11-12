using Microsoft.EntityFrameworkCore.Migrations;

namespace JPP_CAPROJ2.Migrations
{
    public partial class addedservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceTransID",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTransID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
